/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_InboundOrderOuterListController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.Inbound.IServices;
namespace VOL.Albert.Inbound.Controllers
{
    [Route("api/Albert_InboundOrderOuterList")]
    [PermissionTable(Name = "Albert_InboundOrderOuterList")]
    public partial class Albert_InboundOrderOuterListController : ApiBaseController<IAlbert_InboundOrderOuterListService>
    {
        public Albert_InboundOrderOuterListController(IAlbert_InboundOrderOuterListService service)
        : base(service)
        {
        }
    }
}

