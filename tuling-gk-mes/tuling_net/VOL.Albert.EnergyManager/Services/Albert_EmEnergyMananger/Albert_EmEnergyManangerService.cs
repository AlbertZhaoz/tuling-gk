/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_EmEnergyManangerService与IAlbert_EmEnergyManangerService中编写
 */
using VOL.Albert.EnergyManager.IRepositories;
using VOL.Albert.EnergyManager.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.EnergyManager.Services
{
    public partial class Albert_EmEnergyManangerService : ServiceBase<Albert_EmEnergyMananger, IAlbert_EmEnergyManangerRepository>
    , IAlbert_EmEnergyManangerService, IDependency
    {
    public Albert_EmEnergyManangerService(IAlbert_EmEnergyManangerRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_EmEnergyManangerService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_EmEnergyManangerService>(); } }
    }
 }
