/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Albert_PdmWorkorderRepository编写代码
 */
using VOL.Albert.ProductionManager.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.ProductionManager.Repositories
{
    public partial class Albert_PdmWorkorderRepository : RepositoryBase<Albert_PdmWorkorder> , IAlbert_PdmWorkorderRepository
    {
    public Albert_PdmWorkorderRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IAlbert_PdmWorkorderRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IAlbert_PdmWorkorderRepository>(); } }
    }
}
