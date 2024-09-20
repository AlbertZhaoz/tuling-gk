/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下albert_dataerrorService与Ialbert_dataerrorService中编写
 */
using VOL.Albert.DataQuery.IRepositories;
using VOL.Albert.DataQuery.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.DataQuery.Services
{
    public partial class albert_dataerrorService : ServiceBase<albert_dataerror, Ialbert_dataerrorRepository>
    , Ialbert_dataerrorService, IDependency
    {
    public albert_dataerrorService(Ialbert_dataerrorRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static Ialbert_dataerrorService Instance
    {
      get { return AutofacContainerModule.GetService<Ialbert_dataerrorService>(); } }
    }
 }
