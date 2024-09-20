/*
 *Author：AlbertZhao
 *Contact：15505240996
 *代码由框架生成,此处任何更改都可能导致被代码生成器覆盖
 *所有业务编写全部应在Partial文件夹下Albert_BasicNumberRuleService与IAlbert_BasicNumberRuleService中编写
 */
using VOL.Albert.BasicData.IRepositories;
using VOL.Albert.BasicData.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Albert.BasicData.Services
{
    public partial class Albert_BasicNumberRuleService : ServiceBase<Albert_BasicNumberRule, IAlbert_BasicNumberRuleRepository>
    , IAlbert_BasicNumberRuleService, IDependency
    {
    public Albert_BasicNumberRuleService(IAlbert_BasicNumberRuleRepository repository)
    : base(repository)
    {
    Init(repository);
    }
    public static IAlbert_BasicNumberRuleService Instance
    {
      get { return AutofacContainerModule.GetService<IAlbert_BasicNumberRuleService>(); } }
    }
 }
