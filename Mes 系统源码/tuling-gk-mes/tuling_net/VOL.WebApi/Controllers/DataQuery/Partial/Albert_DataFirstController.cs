/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Albert_DataFirst",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VOL.Albert.DataQuery.IServices;
using VOL.Core.Utilities;
using AutoMapper;

namespace VOL.Albert.DataQuery.Controllers
{
    public partial class Albert_DataFirstController
    {
        private readonly IAlbert_DataFirstService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        private WebResponseContent webResponse = null;

        [ActivatorUtilitiesConstructor]
        public Albert_DataFirstController(
            IAlbert_DataFirstService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 获取最后一站移动步数
        /// </summary>
        /// <param name="reworkNumber"></param>
        /// <param name="productCode"></param>
        /// <returns></returns>
        [HttpGet("GetLastStation")]
        public async Task<WebResponseContent> GetLastStation(int reworkNumber, string productCode)
        {
            webResponse = await _service.GetLastStationAsync(reworkNumber, productCode);

            return webResponse;
        }

        /// <summary>
        /// 提交进行变更，修改原始表最终站结果，并将其当时一站的数据插入到返工表数据库中
        /// </summary>
        /// <param name="reworkNumber"></param>
        /// <param name="productCode"></param>
        /// <returns></returns>
        [HttpGet("SendLastStation")]
        public async Task<WebResponseContent> SendLastStation(int reworkNumber, string productCode, string lastStepName)
        {
            webResponse = await _service.UpdateLastStationAsync(reworkNumber, productCode, lastStepName);

            return webResponse;
        }
    }
}
