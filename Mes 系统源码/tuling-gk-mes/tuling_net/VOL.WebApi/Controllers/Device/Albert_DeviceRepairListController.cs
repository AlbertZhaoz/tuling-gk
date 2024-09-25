/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_DeviceRepairListController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.Device.IServices;
namespace VOL.Albert.Device.Controllers
{
    [Route("api/Albert_DeviceRepairList")]
    [PermissionTable(Name = "Albert_DeviceRepairList")]
    public partial class Albert_DeviceRepairListController : ApiBaseController<IAlbert_DeviceRepairListService>
    {
        public Albert_DeviceRepairListController(IAlbert_DeviceRepairListService service)
        : base(service)
        {
        }
    }
}

