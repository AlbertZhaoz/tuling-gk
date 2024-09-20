/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹tbl_record_data_240Repository编写代码
 */
using VOL.Albert.DataQuery.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.DataQuery.Repositories
{
    public partial class tbl_record_data_240Repository : RepositoryBase<tbl_record_data_240> , Itbl_record_data_240Repository
    {
    public tbl_record_data_240Repository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static Itbl_record_data_240Repository Instance
    {
      get {  return AutofacContainerModule.GetService<Itbl_record_data_240Repository>(); } }
    }
}
