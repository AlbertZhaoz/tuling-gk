/*
 *Author：jxx
 *Contact：283591387@qq.com
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_BasicWorkshopService与IAlbert_BasicWorkshopService中编写
 */
using VOL.Albert.BasicData.IRepositories;
using VOL.Albert.BasicData.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.BasicData.Services
{
    public partial class Albert_BasicWorkshopService : ServiceBase<Albert_BasicWorkshop, IAlbert_BasicWorkshopRepository>
    , IAlbert_BasicWorkshopService, IDependency
    {
    public Albert_BasicWorkshopService(IAlbert_BasicWorkshopRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_BasicWorkshopService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_BasicWorkshopService>(); } }
    }
 }
