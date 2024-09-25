/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_PdmCraftDeviceController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.ProductionManager.IServices;
namespace VOL.Albert.ProductionManager.Controllers
{
    [Route("api/Albert_PdmCraftDevice")]
    [PermissionTable(Name = "Albert_PdmCraftDevice")]
    public partial class Albert_PdmCraftDeviceController : ApiBaseController<IAlbert_PdmCraftDeviceService>
    {
        public Albert_PdmCraftDeviceController(IAlbert_PdmCraftDeviceService service)
        : base(service)
        {
        }
    }
}

