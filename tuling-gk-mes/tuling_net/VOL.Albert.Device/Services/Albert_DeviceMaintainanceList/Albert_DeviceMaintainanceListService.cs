/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_DeviceMaintainanceListService与IAlbert_DeviceMaintainanceListService中编写
 */
using VOL.Albert.Device.IRepositories;
using VOL.Albert.Device.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Device.Services
{
    public partial class Albert_DeviceMaintainanceListService : ServiceBase<Albert_DeviceMaintainanceList, IAlbert_DeviceMaintainanceListRepository>
    , IAlbert_DeviceMaintainanceListService, IDependency
    {
    public Albert_DeviceMaintainanceListService(IAlbert_DeviceMaintainanceListRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_DeviceMaintainanceListService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_DeviceMaintainanceListService>(); } }
    }
 }
