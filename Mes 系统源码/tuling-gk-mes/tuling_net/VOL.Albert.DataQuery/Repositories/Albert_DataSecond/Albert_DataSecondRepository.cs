/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Albert_DataSecondRepository编写代码
 */
using VOL.Albert.DataQuery.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.DataQuery.Repositories
{
    public partial class Albert_DataSecondRepository : RepositoryBase<Albert_DataSecond> , IAlbert_DataSecondRepository
    {
    public Albert_DataSecondRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IAlbert_DataSecondRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IAlbert_DataSecondRepository>(); } }
    }
}
