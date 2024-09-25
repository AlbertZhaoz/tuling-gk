/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_CraftParamController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.ProductionManager.IServices;
namespace VOL.Albert.ProductionManager.Controllers
{
    [Route("api/Albert_CraftParam")]
    [PermissionTable(Name = "Albert_CraftParam")]
    public partial class Albert_CraftParamController : ApiBaseController<IAlbert_CraftParamService>
    {
        public Albert_CraftParamController(IAlbert_CraftParamService service)
        : base(service)
        {
        }
    }
}

