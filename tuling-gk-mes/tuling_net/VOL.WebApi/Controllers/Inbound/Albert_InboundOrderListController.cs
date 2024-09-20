/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_InboundOrderListController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.Inbound.IServices;
namespace VOL.Albert.Inbound.Controllers
{
    [Route("api/Albert_InboundOrderList")]
    [PermissionTable(Name = "Albert_InboundOrderList")]
    public partial class Albert_InboundOrderListController : ApiBaseController<IAlbert_InboundOrderListService>
    {
        public Albert_InboundOrderListController(IAlbert_InboundOrderListService service)
        : base(service)
        {
        }
    }
}

