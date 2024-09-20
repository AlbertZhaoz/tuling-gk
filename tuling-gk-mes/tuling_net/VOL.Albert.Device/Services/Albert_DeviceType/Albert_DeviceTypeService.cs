/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_DeviceTypeService与IAlbert_DeviceTypeService中编写
 */
using VOL.Albert.Device.IRepositories;
using VOL.Albert.Device.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Device.Services
{
    public partial class Albert_DeviceTypeService : ServiceBase<Albert_DeviceType, IAlbert_DeviceTypeRepository>
    , IAlbert_DeviceTypeService, IDependency
    {
    public Albert_DeviceTypeService(IAlbert_DeviceTypeRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_DeviceTypeService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_DeviceTypeService>(); } }
    }
 }
