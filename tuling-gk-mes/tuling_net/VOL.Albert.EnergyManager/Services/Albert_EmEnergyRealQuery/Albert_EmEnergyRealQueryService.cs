/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_EmEnergyRealQueryService与IAlbert_EmEnergyRealQueryService中编写
 */
using VOL.Albert.EnergyManager.IRepositories;
using VOL.Albert.EnergyManager.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.EnergyManager.Services
{
    public partial class Albert_EmEnergyRealQueryService : ServiceBase<Albert_EmEnergyRealQuery, IAlbert_EmEnergyRealQueryRepository>
    , IAlbert_EmEnergyRealQueryService, IDependency
    {
    public Albert_EmEnergyRealQueryService(IAlbert_EmEnergyRealQueryRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_EmEnergyRealQueryService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_EmEnergyRealQueryService>(); } }
    }
 }
