using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VOL.Albert.Device.IRepositories;
using VOL.Albert.ProductionManager.IRepositories;
using VOL.Core.Utilities;
using System.Threading.Tasks;
using VOL.Albert.EnergyManager.IRepositories;
using VOL.Core.CacheManager;

namespace VOL.WebApi.Controllers.KanBan
{
    [AllowAnonymous]
    [Route("api/Albert_DeviceMonitor")]
    public class Albert_DeviceMonitorController : BaseKanbanController
    {
        private readonly IAlbert_PdmWorkorderRepository albert_PdmWorkorderRepository;// 工单
        private readonly IAlbert_EmEnergyRealQueryRepository albert_emEnergyRealQueryRepo; // 能耗仓储
        private WebResponseContent webResponse = new();

        public Albert_DeviceMonitorController(
            IAlbert_DeviceConfigureRepository albert_DeviceConfigureRepository,
            IAlbert_PdmWorkorderRepository albert_PdmWorkorderRepository,
            IAlbert_PdmProductRepository albert_PdmProductRepository,
            IAlbert_CraftRepository albert_CraftRepository,
            IAlbert_PdmCraftDeviceRepository albert_PdmCraftDeviceRepository,
            IAlbert_EmEnergyRealQueryRepository albert_emEnergyRealQueryRepo,
            ICacheService cacheService):
            base(albert_PdmProductRepository,
                albert_CraftRepository,
                albert_PdmCraftDeviceRepository,
                albert_DeviceConfigureRepository,
                cacheService)
        {
            this.albert_PdmWorkorderRepository = albert_PdmWorkorderRepository;
            this.albert_emEnergyRealQueryRepo = albert_emEnergyRealQueryRepo;
        }

        #region 新看板接口 DeviceMonitor
        /// <summary>
        /// 获取在制工单：工单号、计划产量、实际产量、合格产量
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPdmWorkOrder")]
        public async Task<WebResponseContent> GetPdmWorkOrder()
        {
            // 1.在制工单（获取在制产品型号）
            var workOrder = await albert_PdmWorkorderRepository.FindFirstAsync(x=>x.WorkorderStatus == "开始");

            webResponse = new WebResponseContent();
            webResponse.Data = workOrder;

            return webResponse.OK();
        }

        /// <summary>
        /// 能耗统计
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEmenergyQuery")]
        public WebResponseContent GetEmenergyQuery()
        {
            // 能耗
            var emenergyList = this.albert_emEnergyRealQueryRepo.Find(x => x.EmEnergyRealQueryPkInt > 0).ToList();

            webResponse = new WebResponseContent();
            webResponse.Data = emenergyList;

            return webResponse.OK();
        }

        /// <summary>
        /// 【新设备看板】在制工艺下的工站：Y,N
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetOperation")]
        public async Task<WebResponseContent> GetOperationAsync()
        {
            // 在制工艺-对应所有工站
            var craft = await GetCraftAsync();
            var stationList = (await GetPdmCraftStationListApi())
                .GroupBy(x => x.DeviceDBStatus)
                .Select(g => new
                {
                    EquipmentStatus = g.Key,
                    EquipmentCount = g.Count()
                }).ToList();
            webResponse = new WebResponseContent();
            webResponse.Data = stationList;

            return webResponse.OK();
        }
        #endregion
    }
}
