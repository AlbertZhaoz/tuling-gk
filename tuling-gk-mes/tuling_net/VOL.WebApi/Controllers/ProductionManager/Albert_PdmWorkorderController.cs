/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_PdmWorkorderController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.ProductionManager.IServices;
namespace VOL.Albert.ProductionManager.Controllers
{
    [Route("api/Albert_PdmWorkorder")]
    [PermissionTable(Name = "Albert_PdmWorkorder")]
    public partial class Albert_PdmWorkorderController : ApiBaseController<IAlbert_PdmWorkorderService>
    {
        public Albert_PdmWorkorderController(IAlbert_PdmWorkorderService service)
        : base(service)
        {
        }
    }
}

