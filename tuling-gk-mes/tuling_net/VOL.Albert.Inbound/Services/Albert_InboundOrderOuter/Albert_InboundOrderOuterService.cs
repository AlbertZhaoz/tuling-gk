/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_InboundOrderOuterService与IAlbert_InboundOrderOuterService中编写
 */
using VOL.Albert.Inbound.IRepositories;
using VOL.Albert.Inbound.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Inbound.Services
{
    public partial class Albert_InboundOrderOuterService : ServiceBase<Albert_InboundOrderOuter, IAlbert_InboundOrderOuterRepository>
    , IAlbert_InboundOrderOuterService, IDependency
    {
    public Albert_InboundOrderOuterService(IAlbert_InboundOrderOuterRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_InboundOrderOuterService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_InboundOrderOuterService>(); } }
    }
 }
