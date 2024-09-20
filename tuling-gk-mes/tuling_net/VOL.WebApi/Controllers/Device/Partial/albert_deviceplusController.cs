/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("albert_deviceplus",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VOL.Entity.DomainModels;
using VOL.Tuling.Device.IServices;
using VOL.Core.Utilities;
using VOL.Tuling.Device.IRepositories;
using Microsoft.AspNetCore.Authorization;

namespace VOL.Tuling.Device.Controllers
{
    public partial class albert_deviceplusController
    {
        private readonly Ialbert_deviceplusService _service;//访问业务代码
        private readonly Ialbert_deviceplusRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private WebResponseContent webResponse = new WebResponseContent();

        [ActivatorUtilitiesConstructor]
        public albert_deviceplusController(
            Ialbert_deviceplusService service,
            IHttpContextAccessor httpContextAccessor, Ialbert_deviceplusRepository repo)
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _repo = repo;
        }

        [AllowAnonymous]
        [HttpGet("GetTulingDevicePlus")]
        public async Task<WebResponseContent> GetTulingDevicePlus(string deviceName)
        {
            webResponse.Data = await _repo.FindAsync(x=>x.DeviceName == deviceName);
            webResponse.Message = "数据获取成功";

            return webResponse.OK();
        }
    }
}
