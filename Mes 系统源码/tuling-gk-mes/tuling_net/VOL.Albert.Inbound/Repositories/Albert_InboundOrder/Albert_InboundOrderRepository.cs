/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Albert_InboundOrderRepository编写代码
 */
using VOL.Albert.Inbound.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Inbound.Repositories
{
    public partial class Albert_InboundOrderRepository : RepositoryBase<Albert_InboundOrder> , IAlbert_InboundOrderRepository
    {
    public Albert_InboundOrderRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IAlbert_InboundOrderRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IAlbert_InboundOrderRepository>(); } }
    }
}
