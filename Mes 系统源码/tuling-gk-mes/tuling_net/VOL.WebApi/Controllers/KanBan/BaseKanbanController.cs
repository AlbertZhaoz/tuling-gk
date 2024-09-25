using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VOL.Albert.Device.IRepositories;
using VOL.Albert.ProductionManager.IRepositories;
using VOL.Core.CacheManager;
using VOL.Core.Utilities;
using VOL.Entity.DomainModels;
using VOL.WebApi.Const;

namespace VOL.WebApi.Controllers.KanBan
{
    [AllowAnonymous]
    [Route("api/BaseKanban")]
    public class BaseKanbanController: Controller
    {
        public readonly IAlbert_PdmProductRepository albert_PdmProductRepository; // 产品型号
        public readonly IAlbert_CraftRepository albert_CraftRepository; // 工艺
        public readonly IAlbert_PdmCraftDeviceRepository albert_PdmCraftDeviceRepository; // 工艺工站
        public readonly IAlbert_DeviceConfigureRepository albert_DeviceConfigureRepository; // plc 
        public ICacheService _cacheService; // 缓存，如果 Redis 启动则直接使用 Redis
        private WebResponseContent webResponse = new();

        public BaseKanbanController(
            IAlbert_PdmProductRepository albert_PdmProductRepository,
            IAlbert_CraftRepository albert_CraftRepository,
            IAlbert_PdmCraftDeviceRepository albert_PdmCraftDeviceRepository,
            IAlbert_DeviceConfigureRepository albert_DeviceConfigureRepository,
            ICacheService cacheService
            )
        {
            this.albert_PdmProductRepository = albert_PdmProductRepository;
            this.albert_CraftRepository = albert_CraftRepository;
            this.albert_PdmCraftDeviceRepository = albert_PdmCraftDeviceRepository;
            this.albert_DeviceConfigureRepository = albert_DeviceConfigureRepository;
            this._cacheService = cacheService;
        }

        /// <summary>
        /// 获取在制工艺工站列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPdmCraftStationList")]
        public async Task<WebResponseContent> GetPdmCraftStationList()
        {
            webResponse = new WebResponseContent();
            webResponse.Data = await GetPdmCraftStationListApi();

            return webResponse.OK();
        }

        /// <summary>
        /// 获取产品型号
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductModel")]
        public async Task<WebResponseContent> GetProductModel()
        {
            var pdmProduct = await GetPdmProductAsync();
            webResponse = new WebResponseContent();
            webResponse.Data = pdmProduct;

            return webResponse.OK();
        }


        /// <summary>
        /// 获取在制产品
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPdmProductAsync")]
        public async Task<Albert_PdmProduct> GetPdmProductAsync()
        {
            // 1.获取在制产品型号
            var pdmProduct = _cacheService.Get<Albert_PdmProduct>(CacheConst.PdmProduct);

            if (pdmProduct == null)
            {
                // 1.如果缓存中没有，则直接拿第一件产品作为默认的型号 2.设置缓存
                pdmProduct = await albert_PdmProductRepository
                    .FindFirstAsync(x => x.ProductPkInt == 1);
                _cacheService.AddObject(CacheConst.PdmProduct, pdmProduct);
            }

            return pdmProduct;
        }

        /// <summary>
        /// 根据在制产品型号获取使用的工艺
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCraftAsync")]
        public async Task<Albert_Craft> GetCraftAsync()
        {
            var craft = _cacheService.Get<Albert_Craft>(CacheConst.Craft);

            if (craft == null)
            {
                // 1.获取在制产品型号
                var pdmProduct = await GetPdmProductAsync();

                // 2.根据产品型号获取工艺，即为在制工艺
                craft = await albert_CraftRepository.FindFirstAsync(x => x.CraftPkInt == pdmProduct.CraftPkInt);
                _cacheService.AddObject(CacheConst.Craft, craft);
            }

            return craft;
        }

        /// <summary>
        /// 获取所有 Plc
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPdmDeviceListApi")]
        public async Task<List<Albert_DeviceConfigure>> GetPdmDeviceListApi()
        {
            // 1. 从缓存中获取所有 PLC
            var deviceList = _cacheService.Get<List<Albert_DeviceConfigure>>(CacheConst.DeviceList);

            if (deviceList == null)
            {
                deviceList = albert_DeviceConfigureRepository
                    .FindAsIQueryable(x => x.DeviceIsUse == "Y")
                    .OrderBy(x => x.DeviceSort)
                    .ToList();
                _cacheService.AddObject(CacheConst.DeviceList, deviceList);
            }

            return deviceList;
        }

        /// <summary>
        /// 获取在制工艺下的所有工站
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPdmCraftStationListApi")]
        public async Task<List<Albert_PdmCraftDevice>> GetPdmCraftStationListApi()
        {
            // 在制工艺-对应所有设备
            var craft = await GetCraftAsync();

            if (craft == null)
            {
                return null;
            }
            else
            {
                var craftStationList = _cacheService.Get<List<Albert_PdmCraftDevice>>(CacheConst.CraftStationList);

                if (craftStationList == null)
                {
                    craftStationList = albert_PdmCraftDeviceRepository
                        .FindAsIQueryable(x => x.CraftPkInt == craft.CraftPkInt && x.DeviceDBIsUse == "Y")
                        .OrderBy(x => x.CraftSort)
                        .ToList();

                    // 将对应的所有工站放入 Redis 中
                    _cacheService.AddObject(CacheConst.CraftStationList, craftStationList);
                }

                return craftStationList;
            }
        }

        /// <summary>
        /// 获取在制工艺下的所有工站（用于界面调试)
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetStationListForRfid")]
        public async Task<WebResponseContent> GetStationListForRfid()
        {
            webResponse = new WebResponseContent();

            // 在制工艺-对应所有设备
            var craft = await GetCraftAsync();

            if (craft == null)
            {
                return null;
            }
            else
            {
                var craftStationList = _cacheService.Get<List<Albert_PdmCraftDevice>>(CacheConst.CraftStationList);

                if (craftStationList == null)
                {
                    craftStationList = albert_PdmCraftDeviceRepository
                        .FindAsIQueryable(x => x.CraftPkInt == craft.CraftPkInt && x.DeviceDBIsUse == "Y")
                        .OrderBy(x => x.CraftSort)
                        .ToList();

                    // 将对应的所有工站放入 Redis 中
                    _cacheService.AddObject(CacheConst.CraftStationList, craftStationList);
                }

                webResponse.Data = craftStationList;
                webResponse.OK();

                return webResponse;
            }
        }
    }
}
