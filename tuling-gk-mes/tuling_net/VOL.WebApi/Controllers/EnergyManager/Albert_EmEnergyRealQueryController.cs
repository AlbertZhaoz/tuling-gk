/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_EmEnergyRealQueryController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.EnergyManager.IServices;
namespace VOL.Albert.EnergyManager.Controllers
{
    [Route("api/Albert_EmEnergyRealQuery")]
    [PermissionTable(Name = "Albert_EmEnergyRealQuery")]
    public partial class Albert_EmEnergyRealQueryController : ApiBaseController<IAlbert_EmEnergyRealQueryService>
    {
        public Albert_EmEnergyRealQueryController(IAlbert_EmEnergyRealQueryService service)
        : base(service)
        {
        }
    }
}

