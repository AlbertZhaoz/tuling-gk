using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using VOL.Albert.DataQuery.IRepositories;
using VOL.Albert.Device.IRepositories;
using VOL.Albert.ProductionManager.IRepositories;
using VOL.Core.Utilities;
using VOL.Entity.DomainModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using VOL.WebApi.Controllers.Hubs;
using Microsoft.AspNetCore.SignalR;
using VOL.Core.CacheManager;
using VOL.WebApi.Const;

namespace VOL.WebApi.Controllers.KanBan
{
    [AllowAnonymous]
    [Route("api/Albert_Kanban")]
    public class Albert_KanbanController : BaseKanbanController
    {
        private readonly IAlbert_PdmWorkorderRepository albert_PdmWorkorderRepository;
        private readonly IAlbert_AlarmRepository albert_AlarmRepository;
        private readonly IAlbert_DataFirstRepository albert_DataFirstRepository;
        private readonly IAlbert_DataSecondRepository albert_DataSecondRepository;
        private readonly IAlbert_DeviceStationConfigureRepository albert_DeviceStationConfigureRepository;
        private readonly ICacheService _cacheService;
        //private readonly IHubContext<HomePageMessageHub> homePageMessageHub;
        private WebResponseContent webResponse = new();

        public Albert_KanbanController(
            IAlbert_DeviceConfigureRepository albert_DeviceConfigureRepository,
            IAlbert_PdmWorkorderRepository albert_PdmWorkorderRepository,
            IAlbert_PdmProductRepository albert_PdmProductRepository,
            IAlbert_CraftRepository albert_CraftRepository,
            IAlbert_PdmCraftDeviceRepository albert_PdmCraftDeviceRepository,
            IAlbert_AlarmRepository albert_AlarmRepository,
            IAlbert_DataFirstRepository albert_DataFirstRepository,
            IAlbert_DataSecondRepository albert_DataSecondRepository,
            IAlbert_DeviceStationConfigureRepository albert_DeviceStationConfigureRepository,
            IHubContext<HomePageMessageHub> homePageMessageHub,
            ICacheService cacheService
            ):base(albert_PdmProductRepository,
            albert_CraftRepository, 
            albert_PdmCraftDeviceRepository, 
            albert_DeviceConfigureRepository,
            cacheService)
        {
            this.albert_PdmWorkorderRepository = albert_PdmWorkorderRepository;
            this.albert_AlarmRepository = albert_AlarmRepository;
            this.albert_DataFirstRepository = albert_DataFirstRepository;
            this.albert_DataSecondRepository = albert_DataSecondRepository;
            this.albert_DeviceStationConfigureRepository = albert_DeviceStationConfigureRepository;
            this._cacheService = cacheService;
            //this.homePageMessageHub = homePageMessageHub;
        }

        /// <summary>
        /// 【生产看板-左上】每天小时产量 Hour ProductCount
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetHourQuantity")]
        public WebResponseContent GetHourQuantity()
        {
            var currentDate = DateTime.Now.Date;
            var lastDate = DateTime.Now.AddDays(-7).Date;

            // 这边必须写成 x.CreateDate.Hour 而不能写成 x.CreateDate.Date.Hour
            // 否则会造成 GroupBy 错误
            try
            {
                var hourlyData = albert_DataFirstRepository
                    .FindAsIQueryable(x => x.DataPkInt > 0 && x.OpFinalDate >= currentDate)
                    .GroupBy(x => ((DateTime)x.OpFinalDate).Hour)
                    .Select(g => new { Hour = g.Key, ProductCount = g.Count() })
                    .ToList();

                // 如果没有数据则直接查询前 10 条数据
                if (hourlyData.Count<1)
                {
                    hourlyData = albert_DataFirstRepository
                        .FindAsIQueryable(x => x.DataPkInt > 0 && x.OpFinalDate >= (lastDate))
                        .GroupBy(x => ((DateTime)x.OpFinalDate).Hour)
                        .Select(g => new { Hour = g.Key, ProductCount = g.Count() })
                        .ToList();
                }

                webResponse = new WebResponseContent();
                webResponse.Data = hourlyData;

                return webResponse.OK();
            }
            catch (Exception ex)
            {
                return webResponse.Error("无合格数据");
            }
        }
        
        /// <summary>
        /// 插入随机数据到 albert_datafirst 表中
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [HttpGet("InsertRandomData")]
        public WebResponseContent InsertRandomData()
        {
            try
            {
                var random = new Random();
                var dataList = albert_DataFirstRepository.Find(x=>x.DataPkInt>0)
                    .GetRange(1,10)
                    .ToList();
                    
                // 更新 OpFinalDate = opFinalDat
                dataList.ForEach(x=>x.OpFinalDate = DateTime.Now.AddHours(-random.Next(0, 24 * 7)));
                
                // 更新到数据库
                albert_DataFirstRepository.UpdateRange(dataList);
                albert_DataFirstRepository.SaveChanges();

                return new WebResponseContent().OK("数据插入成功");
            }
            catch (Exception ex)
            {
                return new WebResponseContent().Error("数据插入失败: " + ex.Message);
            }
        }


        /// <summary>
        /// 【生产看板-左下角】获取看板展示的所有设备
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDeviceList")]
        public async Task<WebResponseContent> GetDeviceList()
        {
            // 1. 从缓存中获取所有 PLC
            var deviceList = GetPdmDeviceListApi();
            webResponse = new WebResponseContent();
            webResponse.Data = deviceList;

            return webResponse.OK();
        }

        /// <summary>
        /// 【生产看板-中上角】
        /// 获取计划产量和实际产量, 计划产量字段：WorkorderPlan，实际产量字段：WorkorderActual，完成率：WorkorderSchedule
        /// 获取合格数和不合格数, 合格数：WorkorderOK，不合格数：WorkorderNG，完成率：WorkorderPassRate
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetQuantity")]
        public WebResponseContent GetQuantity()
        {
            var workOrder = albert_PdmWorkorderRepository
                .FindAsIQueryable(x => x.WorkorderStatus == "开始")
                .OrderByDescending(x => x.WorkorderActualStartDate)
                .FirstOrDefault();
            webResponse = new WebResponseContent();

            if (workOrder != null)
            {
                webResponse.Data = workOrder;

                return webResponse.OK();
            }
            else
            {
                return webResponse.Error("查询不到工单");
            }
        }

        /// <summary>
        /// 【生产看板-中中角】获取当前警报工站
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAlarm")]
        public WebResponseContent GetAlarm()
        {
            var alarmDevice = albert_AlarmRepository
                .FindAsIQueryable(x => x.AlarmStatus == "警告")
                .ToList();
            webResponse = new WebResponseContent();
            webResponse.Data = alarmDevice;

            return webResponse.OK();
        }

        /// <summary>
        /// 【生产看板-中下角】获取看板展示的所有工站【产线所有工站】/分页查询
        /// </summary>
        /// <param name="pageNumber">每页条数</param>
        /// <param name="pageSize">多少页</param>
        /// <returns></returns>
        [HttpGet("GetStationListByPageAsync")]
        public async Task<WebResponseContent> GetStationListByPageAsync(int pageNumber, int pageSize)
        {
            // 在制工艺-对应所有设备
            var craftStationList = await GetPdmCraftStationListApi();

            int totalRows = craftStationList.Count();
            int totalPages = (totalRows + pageSize - 1) / pageSize;
            int currentPage = Math.Min(totalPages, pageNumber);

            webResponse = new WebResponseContent();

            // 返回总工站数+总工站列表
            webResponse.Data = new
            {
                StationCount = totalRows,
                StationList = craftStationList
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
        };

            return webResponse.OK();
        }

        /// <summary>
        /// 获取历史数据 环形 1 线查询最新 10 条数据，环形 2 线查询最新 10 条数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetHistoryData")]
        public WebResponseContent GetHistoryData()
        {
            try
            {
                var firstData = albert_DataFirstRepository
                    .Find(x => x.DataPkInt > 0)
                    .OrderByDescending(x => x.OpFinalDate)
                    .Select(d => new
                    {
                        d.ProductCode,
                        d.OpFinalResult
                    })
                    .Take(20);

                var secondData = albert_DataSecondRepository
                    .Find(x => x.DataPkInt > 0)
                    .OrderByDescending(x => x.OpFinalDate)
                    .Select(d => new
                    {
                        ProductCode = d.ShellCode,
                        d.OpFinalResult
                    })
                    .Take(20);

                var totalData = firstData.Concat(secondData);

                webResponse = new WebResponseContent();
                webResponse.Data = totalData;

                return webResponse.OK();
            }
            catch (Exception e)
            {
                webResponse.Data = null;
                return webResponse.Error();
            }
            
        }

        /// <summary>
        /// 根据工单获取产品型号，进而获取使用的工艺
        /// 如果没有在制工单，默认选取
        /// </summary>
        /// <returns></returns>
        private async Task<Albert_Craft> GetCraftAsync()
        {
            var craft = _cacheService.Get<Albert_Craft>(CacheConst.Craft);

            if (craft == null)
            {
                // 1.获取在制产品型号
                var product = _cacheService.Get<Albert_PdmProduct>(CacheConst.PdmProduct);

                if (product == null)
                {
                    // 1.如果缓存中没有，则直接拿第一件产品作为默认的型号
                    product = await albert_PdmProductRepository
                        .FindFirstAsync(x => x.ProductPkInt == 1);

                    // 2.设置缓存
                    _cacheService.AddObject(CacheConst.PdmProduct, product);
                }

                // 3.根据产品型号获取工艺，即为在制工艺
                craft = await albert_CraftRepository.FindFirstAsync(x => x.CraftPkInt == product.CraftPkInt);
                _cacheService.AddObject(CacheConst.Craft, craft);
            }

            return craft;
        }

        [HttpGet("GetStationListByDevicePkIntAsync")]
        public async Task<WebResponseContent> GetStationListByDevicePkIntAsync(int devicePkInt)
        {
            var stationList = albert_DeviceStationConfigureRepository
                 .FindAsIQueryable(x => x.DevicePkInt == devicePkInt && x.DeviceDBIsUse == "Y")
                 .OrderBy(x => x.DeviceDBSort);
            webResponse = new WebResponseContent();
            webResponse.Data = stationList;

            return webResponse.OK();
        }

        //[HttpGet("TestHub")]
        //public void TestHub()
        //{
        //    // https://learn.microsoft.com/zh-cn/aspnet/core/signalr/dotnet-client?view=aspnetcore-7.0&tabs=visual-studio
        //    homePageMessageHub.Clients.All.SendAsync("ReceiveHomePageMessage", new
        //    {
        //        //   username,
        //        title = "fdaf",
        //        message = "fdafasf",
        //        date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss")
        //    });
        //}
    }
}
