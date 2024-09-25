/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_DataSecondService与IAlbert_DataSecondService中编写
 */
using VOL.Albert.DataQuery.IRepositories;
using VOL.Albert.DataQuery.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.CacheManager;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.DataQuery.Services
{
    public partial class Albert_DataSecondService : ServiceBase<Albert_DataSecond, IAlbert_DataSecondRepository>
    , IAlbert_DataSecondService, IDependency
    {
    public Albert_DataSecondService(IAlbert_DataSecondRepository repository, ICacheService cacheService, Itbl_record_data_230Service tb230Service)
    : base(repository)
    {
        _tb230Service = tb230Service;
        _cacheService = cacheService;
        Init(repository);
    }
    public static IAlbert_DataSecondService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_DataSecondService>(); } }
    }
 }
