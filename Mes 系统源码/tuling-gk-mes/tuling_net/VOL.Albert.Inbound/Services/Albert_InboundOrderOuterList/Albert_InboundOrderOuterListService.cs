/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_InboundOrderOuterListService与IAlbert_InboundOrderOuterListService中编写
 */
using VOL.Albert.Inbound.IRepositories;
using VOL.Albert.Inbound.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Inbound.Services
{
    public partial class Albert_InboundOrderOuterListService : ServiceBase<Albert_InboundOrderOuterList, IAlbert_InboundOrderOuterListRepository>
    , IAlbert_InboundOrderOuterListService, IDependency
    {
    public Albert_InboundOrderOuterListService(IAlbert_InboundOrderOuterListRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_InboundOrderOuterListService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_InboundOrderOuterListService>(); } }
    }
 }
