/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_BasicWorkshopController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.BasicData.IServices;
namespace VOL.Albert.BasicData.Controllers
{
    [Route("api/Albert_BasicWorkshop")]
    [PermissionTable(Name = "Albert_BasicWorkshop")]
    public partial class Albert_BasicWorkshopController : ApiBaseController<IAlbert_BasicWorkshopService>
    {
        public Albert_BasicWorkshopController(IAlbert_BasicWorkshopService service)
        : base(service)
        {
        }
    }
}

