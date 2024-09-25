/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹albert_deviceplusRepository编写代码
 */
using VOL.Tuling.Device.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Tuling.Device.Repositories
{
    public partial class albert_deviceplusRepository : RepositoryBase<albert_deviceplus> , Ialbert_deviceplusRepository
    {
    public albert_deviceplusRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static Ialbert_deviceplusRepository Instance
    {
      get {  return AutofacContainerModule.GetService<Ialbert_deviceplusRepository>(); } }
    }
}
