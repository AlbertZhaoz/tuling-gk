/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_CraftController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.ProductionManager.IServices;
namespace VOL.Albert.ProductionManager.Controllers
{
    [Route("api/Albert_Craft")]
    [PermissionTable(Name = "Albert_Craft")]
    public partial class Albert_CraftController : ApiBaseController<IAlbert_CraftService>
    {
        public Albert_CraftController(IAlbert_CraftService service)
        : base(service)
        {
        }
    }
}

