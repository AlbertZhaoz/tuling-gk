/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_InboundOrderController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.Inbound.IServices;
namespace VOL.Albert.Inbound.Controllers
{
    [Route("api/Albert_InboundOrder")]
    [PermissionTable(Name = "Albert_InboundOrder")]
    public partial class Albert_InboundOrderController : ApiBaseController<IAlbert_InboundOrderService>
    {
        public Albert_InboundOrderController(IAlbert_InboundOrderService service)
        : base(service)
        {
        }
    }
}

