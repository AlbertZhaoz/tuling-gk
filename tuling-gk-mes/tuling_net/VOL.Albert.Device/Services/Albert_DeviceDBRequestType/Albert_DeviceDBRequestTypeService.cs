/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_DeviceDBRequestTypeService与IAlbert_DeviceDBRequestTypeService中编写
 */
using VOL.Albert.Device.IRepositories;
using VOL.Albert.Device.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Device.Services
{
    public partial class Albert_DeviceDBRequestTypeService : ServiceBase<Albert_DeviceDBRequestType, IAlbert_DeviceDBRequestTypeRepository>
    , IAlbert_DeviceDBRequestTypeService, IDependency
    {
    public Albert_DeviceDBRequestTypeService(IAlbert_DeviceDBRequestTypeRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_DeviceDBRequestTypeService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_DeviceDBRequestTypeService>(); } }
    }
 }
