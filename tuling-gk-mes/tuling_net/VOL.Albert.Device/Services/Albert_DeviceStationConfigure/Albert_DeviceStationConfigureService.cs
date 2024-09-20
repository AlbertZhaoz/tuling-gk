/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_DeviceStationConfigureService与IAlbert_DeviceStationConfigureService中编写
 */
using VOL.Albert.Device.IRepositories;
using VOL.Albert.Device.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Device.Services
{
    public partial class Albert_DeviceStationConfigureService : ServiceBase<Albert_DeviceStationConfigure, IAlbert_DeviceStationConfigureRepository>
    , IAlbert_DeviceStationConfigureService, IDependency
    {
    public Albert_DeviceStationConfigureService(IAlbert_DeviceStationConfigureRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_DeviceStationConfigureService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_DeviceStationConfigureService>(); } }
    }
 }
