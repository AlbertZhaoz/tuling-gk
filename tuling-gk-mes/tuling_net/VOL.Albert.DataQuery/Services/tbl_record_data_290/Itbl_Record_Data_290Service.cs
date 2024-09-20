/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下tbl_record_data_290_viewService与Itbl_record_data_290_viewService中编写
 */
using VOL.Albert.DataQuery.IRepositories;
using VOL.Albert.DataQuery.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.DataQuery.Services
{
    public partial class Itbl_Record_Data_290Service : ServiceBase<tbl_record_data_290, Itbl_record_data_290Repository>
    , Itbl_record_data_290Service, IDependency
    {
    public Itbl_Record_Data_290Service(Itbl_record_data_290Repository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static Itbl_record_data_290Service Instance
    {
      get { return AutofacContainerModule.GetService<Itbl_record_data_290Service>(); } }
    }
 }
