/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Albert_EmEnergyRealQuery",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VOL.Entity.DomainModels;
using VOL.Albert.EnergyManager.IServices;
using VOL.Core.Utilities;
using VOL.Albert.EnergyManager.IRepositories;
using VOL.Albert.EnergyManager.Repositories;
using System.Linq;
using VOL.Core.Extensions;

namespace VOL.Albert.EnergyManager.Controllers
{
    public partial class Albert_EmEnergyRealQueryController
    {
        private readonly IAlbert_EmEnergyRealQueryService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAlbert_EmEnergyRealQueryRepository _albert_EmEnergyRealQueryRepository;
        private WebResponseContent webResponse = null;

        [ActivatorUtilitiesConstructor]
        public Albert_EmEnergyRealQueryController(
            IAlbert_EmEnergyRealQueryService service,
            IHttpContextAccessor httpContextAccessor,
            IAlbert_EmEnergyRealQueryRepository albert_EmEnergyRealQueryRepository
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _albert_EmEnergyRealQueryRepository = albert_EmEnergyRealQueryRepository;
        }

        [HttpGet("GetEletricityRealData")]
        public WebResponseContent GetEletricityRealData()
        {
            webResponse = new WebResponseContent();

            //    var firstData = albert_DataFirstRepository
            //        .FindAsIQueryable(x => x.DataPkInt > 0)
            //        .Where(x => x.CreateDate <= DateTime.Now && x.CreateDate > DateTime.Now.AddDays(-7)&&x.OpFinalResult == "OK")
            //        .GroupBy(x => x.CreateDate)
            //        .Select(g => new { CreateDate = g.Key, ProductCount = g.Count() })
            //        .OrderBy(x => x.CreateDate);

            var list = _albert_EmEnergyRealQueryRepository.Find(x => x.ElectricOrGas == "气表")
                .Where(x => x.ActualTime >= DateTime.Now.AddDays(-7) && x.ActualTime <= DateTime.Now)
                // 根据日期和上午/下午进行分组
                .GroupBy(x => new { x.ActualTime.Value.Day, Period = (x.ActualTime.Value.Hour < 12) ? "0" : "1" })
                .Select(g => new
                 {
                     DateDay = g.Key.Day,
                     Period = g.Key.Period,
                     ActualSumValue = g.Sum(x => x.ActualValue)
                })
                .OrderBy(x => x.DateDay)
                .ThenBy(x => x.Period)
                .ToList();

            webResponse.Data = list;

            return webResponse.OK();
        }

        [HttpGet("GetGasRealData")]
        public WebResponseContent GetGasRealData()
        {
            webResponse = new WebResponseContent();

            //    var firstData = albert_DataFirstRepository
            //        .FindAsIQueryable(x => x.DataPkInt > 0)
            //        .Where(x => x.CreateDate <= DateTime.Now && x.CreateDate > DateTime.Now.AddDays(-7)&&x.OpFinalResult == "OK")
            //        .GroupBy(x => x.CreateDate)
            //        .Select(g => new { CreateDate = g.Key, ProductCount = g.Count() })
            //        .OrderBy(x => x.CreateDate);

            var list = _albert_EmEnergyRealQueryRepository.Find(x => x.ElectricOrGas == "电表")
                .Where(x => x.ActualTime >= DateTime.Now.AddDays(-7) && x.ActualTime <= DateTime.Now)
                // 根据日期和上午/下午进行分组
                .GroupBy(x => new { x.ActualTime.Value.Day, Period = (x.ActualTime.Value.Hour < 12) ? "0" : "1" })
                .Select(g => new
                {
                    DateDay = g.Key.Day,
                    Period = g.Key.Period,
                    ActualSumValue = g.Sum(x => x.ActualValue)
                })
                .OrderBy(x => x.DateDay)
                .ThenBy(x => x.Period)
                .ToList();

            webResponse.Data = list;

            return webResponse.OK();
        }
    }
}
