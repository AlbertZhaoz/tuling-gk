/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_DeviceRepairService与IAlbert_DeviceRepairService中编写
 */
using VOL.Albert.Device.IRepositories;
using VOL.Albert.Device.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Device.Services
{
    public partial class Albert_DeviceRepairService : ServiceBase<Albert_DeviceRepair, IAlbert_DeviceRepairRepository>
    , IAlbert_DeviceRepairService, IDependency
    {
    public Albert_DeviceRepairService(IAlbert_DeviceRepairRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_DeviceRepairService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_DeviceRepairService>(); } }
    }
 }
