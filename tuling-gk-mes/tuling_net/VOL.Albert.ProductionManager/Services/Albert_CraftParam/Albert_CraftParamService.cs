/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_CraftParamService与IAlbert_CraftParamService中编写
 */
using VOL.Albert.ProductionManager.IRepositories;
using VOL.Albert.ProductionManager.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.ProductionManager.Services
{
    public partial class Albert_CraftParamService : ServiceBase<Albert_CraftParam, IAlbert_CraftParamRepository>
    , IAlbert_CraftParamService, IDependency
    {
    public Albert_CraftParamService(IAlbert_CraftParamRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_CraftParamService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_CraftParamService>(); } }
    }
 }
