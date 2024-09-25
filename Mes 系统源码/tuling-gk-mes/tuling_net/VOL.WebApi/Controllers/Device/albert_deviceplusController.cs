/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹albert_deviceplusController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Tuling.Device.IRepositories;
using VOL.Tuling.Device.IServices;
namespace VOL.Tuling.Device.Controllers
{
    [Route("api/albert_deviceplus")]
    [PermissionTable(Name = "albert_deviceplus")]
    public partial class albert_deviceplusController : ApiBaseController<Ialbert_deviceplusService>
    {
        public albert_deviceplusController(Ialbert_deviceplusService service, Ialbert_deviceplusRepository repo)
        : base(service)
        {
            _repo = repo;
        }
    }
}

