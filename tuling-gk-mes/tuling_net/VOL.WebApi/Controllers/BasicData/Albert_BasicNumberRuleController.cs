/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_BasicNumberRuleController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.BasicData.IServices;
namespace VOL.Albert.BasicData.Controllers
{
    [Route("api/Albert_BasicNumberRule")]
    [PermissionTable(Name = "Albert_BasicNumberRule")]
    public partial class Albert_BasicNumberRuleController : ApiBaseController<IAlbert_BasicNumberRuleService>
    {
        public Albert_BasicNumberRuleController(IAlbert_BasicNumberRuleService service)
        : base(service)
        {
        }
    }
}

