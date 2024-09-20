/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹Albert_DeviceDBRequestTypeRepository编写代码
 */
using VOL.Albert.Device.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.Device.Repositories
{
    public partial class Albert_DeviceDBRequestTypeRepository : RepositoryBase<Albert_DeviceDBRequestType> , IAlbert_DeviceDBRequestTypeRepository
    {
    public Albert_DeviceDBRequestTypeRepository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static IAlbert_DeviceDBRequestTypeRepository Instance
    {
      get {  return AutofacContainerModule.GetService<IAlbert_DeviceDBRequestTypeRepository>(); } }
    }
}
