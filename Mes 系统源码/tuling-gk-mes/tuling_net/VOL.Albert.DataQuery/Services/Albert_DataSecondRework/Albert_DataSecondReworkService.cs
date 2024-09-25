/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_DataSecondReworkService与IAlbert_DataSecondReworkService中编写
 */
using VOL.Albert.DataQuery.IRepositories;
using VOL.Albert.DataQuery.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.DataQuery.Services
{
    public partial class Albert_DataSecondReworkService : ServiceBase<Albert_DataSecondRework, IAlbert_DataSecondReworkRepository>
    , IAlbert_DataSecondReworkService, IDependency
    {
    public Albert_DataSecondReworkService(IAlbert_DataSecondReworkRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_DataSecondReworkService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_DataSecondReworkService>(); } }
    }
 }
