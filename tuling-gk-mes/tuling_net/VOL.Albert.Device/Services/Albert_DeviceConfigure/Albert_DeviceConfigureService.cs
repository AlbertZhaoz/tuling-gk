/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_DeviceConfigureService与IAlbert_DeviceConfigureService中编写
 */
using VOL.Albert.Device.IRepositories;
using VOL.Albert.Device.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Device.Services
{
    public partial class Albert_DeviceConfigureService : ServiceBase<Albert_DeviceConfigure, IAlbert_DeviceConfigureRepository>
    , IAlbert_DeviceConfigureService, IDependency
    {
    public Albert_DeviceConfigureService(IAlbert_DeviceConfigureRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_DeviceConfigureService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_DeviceConfigureService>(); } }
    }
 }
