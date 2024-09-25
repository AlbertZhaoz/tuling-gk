/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹albert_dataerrorController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.DataQuery.IServices;
namespace VOL.Albert.DataQuery.Controllers
{
    [Route("api/albert_dataerror")]
    [PermissionTable(Name = "albert_dataerror")]
    public partial class albert_dataerrorController : ApiBaseController<Ialbert_dataerrorService>
    {
        public albert_dataerrorController(Ialbert_dataerrorService service)
        : base(service)
        {
        }
    }
}

