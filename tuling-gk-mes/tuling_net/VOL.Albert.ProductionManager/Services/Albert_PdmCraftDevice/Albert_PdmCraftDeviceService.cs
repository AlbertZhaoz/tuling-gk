/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_PdmCraftDeviceService与IAlbert_PdmCraftDeviceService中编写
 */
using VOL.Albert.ProductionManager.IRepositories;
using VOL.Albert.ProductionManager.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.ProductionManager.Services
{
    public partial class Albert_PdmCraftDeviceService : ServiceBase<Albert_PdmCraftDevice, IAlbert_PdmCraftDeviceRepository>
    , IAlbert_PdmCraftDeviceService, IDependency
    {
    public Albert_PdmCraftDeviceService(IAlbert_PdmCraftDeviceRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_PdmCraftDeviceService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_PdmCraftDeviceService>(); } }
    }
 }
