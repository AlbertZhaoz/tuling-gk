/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_DeviceMaintainanceService与IAlbert_DeviceMaintainanceService中编写
 */
using VOL.Albert.Device.IRepositories;
using VOL.Albert.Device.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Device.Services
{
    public partial class Albert_DeviceMaintainanceService : ServiceBase<Albert_DeviceMaintainance, IAlbert_DeviceMaintainanceRepository>
    , IAlbert_DeviceMaintainanceService, IDependency
    {
    public Albert_DeviceMaintainanceService(IAlbert_DeviceMaintainanceRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_DeviceMaintainanceService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_DeviceMaintainanceService>(); } }
    }
 }
