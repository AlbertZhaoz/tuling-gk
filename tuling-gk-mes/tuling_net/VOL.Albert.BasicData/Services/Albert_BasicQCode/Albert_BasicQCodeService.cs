/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_BasicQCodeService与IAlbert_BasicQCodeService中编写
 */
using VOL.Albert.BasicData.IRepositories;
using VOL.Albert.BasicData.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.BasicData.Services
{
    public partial class Albert_BasicQCodeService : ServiceBase<Albert_BasicQCode, IAlbert_BasicQCodeRepository>
    , IAlbert_BasicQCodeService, IDependency
    {
    public Albert_BasicQCodeService(IAlbert_BasicQCodeRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_BasicQCodeService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_BasicQCodeService>(); } }
    }
 }
