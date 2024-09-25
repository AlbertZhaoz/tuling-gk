/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Albert_RFID",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VOL.Entity.DomainModels;
using VOL.Albert.DataQuery.IServices;
using System.Net;
using Newtonsoft.Json;
using SqlSugar.IOC;
using VOL.Albert.DataQuery.IRepositories;
using VOL.Core.Utilities;
using VOL.Core.CacheManager;
using VOL.WebApi.Const;

namespace VOL.Albert.DataQuery.Controllers
{
    public partial class Albert_RFIDController
    {
        private readonly IAlbert_RFIDService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAlbert_RFIDRepository _rfidRepository;
        public ICacheService _cacheService;
        private WebResponseContent webResponse = new();

        [ActivatorUtilitiesConstructor]
        public Albert_RFIDController(
            IAlbert_RFIDService service,
            IHttpContextAccessor httpContextAccessor,
            IAlbert_RFIDRepository rfidRepository,
            ICacheService cacheService
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _rfidRepository = rfidRepository;
            _cacheService = cacheService;
        }

        /// <summary>
        /// 获取当前工站上升沿情况
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPlcSignal")]
        public async Task<WebResponseContent> GetPlcSignalAsync(string stationName)
        {
            webResponse = new WebResponseContent();

            try
            {
                var plcSignal = _cacheService.GetList(CacheConst.PlcMes);
                var plcSignalFilter = plcSignal.Where(a => a.Contains(stationName)).Take(10);
                webResponse.Data = plcSignalFilter;

                return webResponse.OK();
            }
            catch (Exception ex)
            {
               return webResponse.Error();
            }
        }

        /// <summary>
        /// 清除所有 MES-PLC 交互缓存
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetClearPlcSignal")]
        public async Task<WebResponseContent> GetClearPlcSignalAsync()
        {
            webResponse = new WebResponseContent();
            try
            {
                _cacheService.Remove(CacheConst.PlcMes);
                return webResponse.OK();
            }
            catch (Exception)
            {
                return webResponse.Error();
            }
            
        }

        /// <summary>
        /// 从缓存中获取所有托盘
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllRfidFromCache")]
        public async Task<WebResponseContent> GetAllRfidFromCacheAsync(int lineId)
        {
            webResponse = new WebResponseContent();
            try
            {
                List<Albert_RFID> rfidList = null;

                if (lineId == 1)
                {
                    rfidList = _rfidRepository.Find(x => x.RFIDPkInt > 0&&x.RFIDPkInt<32);
                }
                else
                {
                    rfidList = _rfidRepository.Find(x => x.RFIDPkInt > 31 && x.RFIDPkInt < 100);
                }
                
                var rfidModelList = new List<Albert_RFID>();


                foreach (var rfid in rfidList)
                {
                    if(_cacheService.Exists($"RFID{rfid.RFID}"))
                    {
                        var rfidModel = _cacheService.Get<Albert_RFID>($"RFID{rfid.RFID}");
                        rfidModelList.Add(rfidModel);
                    }
                }

                webResponse.Data = rfidModelList;
                
                return webResponse.OK();
            }
            catch (Exception e)
            {
                return webResponse.Error();
            }
        }
        
        /// <summary>
        /// 解除所有托盘占用
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetResetRfidIsUse")]
        public async Task<WebResponseContent> GetResetRfidIsUseAsync()
        {
            webResponse = new WebResponseContent();
            try
            {
                var rfidList = _rfidRepository.Find(x => x.RFIDPkInt > 0);

                foreach (var rfid in rfidList)
                {
                    if (_cacheService.Exists($"RFID{rfid.RFID}"))
                    {
                        var rfidModel = _cacheService.Get<Albert_RFID>($"RFID{rfid.RFID}");

                        if (rfidModel != null)
                        {
                            rfidModel.RFIDIsUse = 0;
                            _cacheService.AddObject($"RFID{rfid.RFID}", rfidModel);
                        }
                    }
                }
                
                return webResponse.OK();
            }
            catch (Exception e)
            {
                return webResponse.Error();
            }
        }

        /// <summary>
        /// 根据托盘 ID 解除所有托盘占用
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        [HttpGet("GetResetSingleRfidIsUse")]
        public async Task<WebResponseContent> GetResetSingleRfidIsUseAsync(int rfidNumber)
        {
            webResponse = new WebResponseContent();
            try
            {
                var rfidModel = _cacheService.Get<Albert_RFID>($"RFID{rfidNumber}");

                if (rfidModel != null)
                {
                    rfidModel.RFIDIsUse = 0;
                    _cacheService.AddObject($"RFID{rfidNumber}", rfidModel);
                }
                return webResponse.OK();
            }
            catch (Exception e)
            {
                return webResponse.Error();
            }
        }
    }
}
