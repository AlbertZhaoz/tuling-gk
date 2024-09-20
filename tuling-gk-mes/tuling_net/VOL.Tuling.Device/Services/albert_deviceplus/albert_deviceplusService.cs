/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下albert_deviceplusService与Ialbert_deviceplusService中编写
 */
using VOL.Tuling.Device.IRepositories;
using VOL.Tuling.Device.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Tuling.Device.Services
{
    public partial class albert_deviceplusService : ServiceBase<albert_deviceplus, Ialbert_deviceplusRepository>
    , Ialbert_deviceplusService, IDependency
    {
    public albert_deviceplusService(Ialbert_deviceplusRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static Ialbert_deviceplusService Instance
    {
      get { return AutofacContainerModule.GetService<Ialbert_deviceplusService>(); } }
    }
 }
