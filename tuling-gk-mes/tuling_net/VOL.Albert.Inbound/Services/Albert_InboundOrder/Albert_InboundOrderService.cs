/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_InboundOrderService与IAlbert_InboundOrderService中编写
 */
using VOL.Albert.Inbound.IRepositories;
using VOL.Albert.Inbound.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Inbound.Services
{
    public partial class Albert_InboundOrderService : ServiceBase<Albert_InboundOrder, IAlbert_InboundOrderRepository>
    , IAlbert_InboundOrderService, IDependency
    {
    public Albert_InboundOrderService(IAlbert_InboundOrderRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_InboundOrderService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_InboundOrderService>(); } }
    }
 }
