/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_BasicQCodeController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.BasicData.IServices;
namespace VOL.Albert.BasicData.Controllers
{
    [Route("api/Albert_BasicQCode")]
    [PermissionTable(Name = "Albert_BasicQCode")]
    public partial class Albert_BasicQCodeController : ApiBaseController<IAlbert_BasicQCodeService>
    {
        public Albert_BasicQCodeController(IAlbert_BasicQCodeService service)
        : base(service)
        {
        }
    }
}

