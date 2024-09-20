/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_InboundOrderOuterController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.Inbound.IServices;
namespace VOL.Albert.Inbound.Controllers
{
    [Route("api/Albert_InboundOrderOuter")]
    [PermissionTable(Name = "Albert_InboundOrderOuter")]
    public partial class Albert_InboundOrderOuterController : ApiBaseController<IAlbert_InboundOrderOuterService>
    {
        public Albert_InboundOrderOuterController(IAlbert_InboundOrderOuterService service)
        : base(service)
        {
        }
    }
}

