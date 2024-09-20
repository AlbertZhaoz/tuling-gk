/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_InboundOrderListService与IAlbert_InboundOrderListService中编写
 */
using VOL.Albert.Inbound.IRepositories;
using VOL.Albert.Inbound.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Inbound.Services
{
    public partial class Albert_InboundOrderListService : ServiceBase<Albert_InboundOrderList, IAlbert_InboundOrderListRepository>
    , IAlbert_InboundOrderListService, IDependency
    {
    public Albert_InboundOrderListService(IAlbert_InboundOrderListRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_InboundOrderListService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_InboundOrderListService>(); } }
    }
 }
