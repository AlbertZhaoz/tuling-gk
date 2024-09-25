/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_PdmWorkorderService与IAlbert_PdmWorkorderService中编写
 */
using VOL.Albert.ProductionManager.IRepositories;
using VOL.Albert.ProductionManager.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.ProductionManager.Services
{
    public partial class Albert_PdmWorkorderService : ServiceBase<Albert_PdmWorkorder, IAlbert_PdmWorkorderRepository>
    , IAlbert_PdmWorkorderService, IDependency
    {
    public Albert_PdmWorkorderService(IAlbert_PdmWorkorderRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_PdmWorkorderService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_PdmWorkorderService>(); } }
    }
 }
