/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_PdmCraftParamHistoryController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.ProductionManager.IServices;
namespace VOL.Albert.ProductionManager.Controllers
{
    [Route("api/Albert_PdmCraftParamHistory")]
    [PermissionTable(Name = "Albert_PdmCraftParamHistory")]
    public partial class Albert_PdmCraftParamHistoryController : ApiBaseController<IAlbert_PdmCraftParamHistoryService>
    {
        public Albert_PdmCraftParamHistoryController(IAlbert_PdmCraftParamHistoryService service)
        : base(service)
        {
        }
    }
}

