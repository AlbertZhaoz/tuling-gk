/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_DeviceConfigureController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.Device.IServices;
namespace VOL.Albert.Device.Controllers
{
    [Route("api/Albert_DeviceConfigure")]
    [PermissionTable(Name = "Albert_DeviceConfigure")]
    public partial class Albert_DeviceConfigureController : ApiBaseController<IAlbert_DeviceConfigureService>
    {
        public Albert_DeviceConfigureController(IAlbert_DeviceConfigureService service)
        : base(service)
        {
        }
    }
}

