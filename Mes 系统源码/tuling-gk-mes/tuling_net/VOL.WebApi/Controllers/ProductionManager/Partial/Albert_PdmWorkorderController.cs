/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Albert_PdmWorkorder",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VOL.Entity.DomainModels;
using VOL.Albert.ProductionManager.IServices;

namespace VOL.Albert.ProductionManager.Controllers
{
    public partial class Albert_PdmWorkorderController
    {
        private readonly IAlbert_PdmWorkorderService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Albert_PdmWorkorderController(
            IAlbert_PdmWorkorderService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
