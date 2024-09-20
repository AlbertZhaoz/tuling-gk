/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *Repository提供数据库操作，如果要增加数据库操作请在当前目录下Partial文件夹tbl_record_data_300_viewRepository编写代码
 */
using VOL.Albert.DataQuery.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.DataQuery.Repositories
{
    public partial class Itbl_Record_Data_300Repository : RepositoryBase<tbl_record_data_300> , Itbl_record_data_300Repository
    {
    public Itbl_Record_Data_300Repository(VOLContext dbContext)
    : base(dbContext)
    {

    }
    public static Itbl_record_data_300Repository Instance
    {
      get {  return AutofacContainerModule.GetService<Itbl_record_data_300Repository>(); } }
    }
}
