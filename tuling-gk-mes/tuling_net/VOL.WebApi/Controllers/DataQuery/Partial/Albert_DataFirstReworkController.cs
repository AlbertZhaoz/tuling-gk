/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Albert_DataFirstRework",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VOL.Albert.DataQuery.IServices;

namespace VOL.Albert.DataQuery.Controllers
{
    public partial class Albert_DataFirstReworkController
    {
        private readonly IAlbert_DataFirstReworkService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;

        [ActivatorUtilitiesConstructor]
        public Albert_DataFirstReworkController(
            IAlbert_DataFirstReworkService service,
            IHttpContextAccessor httpContextAccessor
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

    }
}
