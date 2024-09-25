/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Albert_InboundOrderOuterListRepository编写代码
 */
using VOL.Albert.Inbound.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Inbound.Repositories
{
    public partial class Albert_InboundOrderOuterListRepository : RepositoryBase<Albert_InboundOrderOuterList> , IAlbert_InboundOrderOuterListRepository
    {
    public Albert_InboundOrderOuterListRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IAlbert_InboundOrderOuterListRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IAlbert_InboundOrderOuterListRepository>(); } }
    }
}
