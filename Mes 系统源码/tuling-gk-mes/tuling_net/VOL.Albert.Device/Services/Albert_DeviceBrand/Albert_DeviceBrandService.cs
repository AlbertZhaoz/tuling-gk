/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_DeviceBrandService与IAlbert_DeviceBrandService中编写
 */
using VOL.Albert.Device.IRepositories;
using VOL.Albert.Device.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Device.Services
{
    public partial class Albert_DeviceBrandService : ServiceBase<Albert_DeviceBrand, IAlbert_DeviceBrandRepository>
    , IAlbert_DeviceBrandService, IDependency
    {
    public Albert_DeviceBrandService(IAlbert_DeviceBrandRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_DeviceBrandService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_DeviceBrandService>(); } }
    }
 }
