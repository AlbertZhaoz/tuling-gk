/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_EmEnergyManangerController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.EnergyManager.IServices;
namespace VOL.Albert.EnergyManager.Controllers
{
    [Route("api/Albert_EmEnergyMananger")]
    [PermissionTable(Name = "Albert_EmEnergyMananger")]
    public partial class Albert_EmEnergyManangerController : ApiBaseController<IAlbert_EmEnergyManangerService>
    {
        public Albert_EmEnergyManangerController(IAlbert_EmEnergyManangerService service)
        : base(service)
        {
        }
    }
}

