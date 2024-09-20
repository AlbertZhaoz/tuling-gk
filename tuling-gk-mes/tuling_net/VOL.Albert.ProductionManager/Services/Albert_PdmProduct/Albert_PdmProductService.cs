/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_PdmProductService与IAlbert_PdmProductService中编写
 */
using VOL.Albert.ProductionManager.IRepositories;
using VOL.Albert.ProductionManager.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.ProductionManager.Services
{
    public partial class Albert_PdmProductService : ServiceBase<Albert_PdmProduct, IAlbert_PdmProductRepository>
    , IAlbert_PdmProductService, IDependency
    {
    public Albert_PdmProductService(IAlbert_PdmProductRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_PdmProductService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_PdmProductService>(); } }
    }
 }
