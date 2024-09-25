/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下tbl_record_data_250_viewService与Itbl_record_data_250_viewService中编写
 */
using VOL.Albert.DataQuery.IRepositories;
using VOL.Albert.DataQuery.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.DataQuery.Services
{
    public partial class Itbl_Record_Data_250Service : ServiceBase<tbl_record_data_250, Itbl_record_data_250Repository>
    , Itbl_record_data_250Service, IDependency
    {
    public Itbl_Record_Data_250Service(Itbl_record_data_250Repository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static Itbl_record_data_250Service Instance
    {
      get { return AutofacContainerModule.GetService<Itbl_record_data_250Service>(); } }
    }
 }
