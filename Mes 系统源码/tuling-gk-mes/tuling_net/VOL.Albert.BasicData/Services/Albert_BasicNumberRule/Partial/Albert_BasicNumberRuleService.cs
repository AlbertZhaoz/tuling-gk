/*
 *所有关于Albert_BasicNumberRule类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Albert_BasicNumberRuleService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;
using System.Linq;
using VOL.Core.Utilities;
using System.Linq.Expressions;
using VOL.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VOL.Albert.BasicData.IRepositories;
using System.Collections.Generic;

namespace VOL.Albert.BasicData.Services
{
    public partial class Albert_BasicNumberRuleService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAlbert_BasicNumberRuleRepository _repository;//访问数据库

        [ActivatorUtilitiesConstructor]
        public Albert_BasicNumberRuleService(
            IAlbert_BasicNumberRuleRepository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        WebResponseContent webResponse = new WebResponseContent();

        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            //此处saveModel是从前台提交的原生数据，可对数据进修改过滤
            AddOnExecuting = (Albert_BasicNumberRule numberRule, object list) =>
            {
                //如果返回false,后面代码不会再执行、
                if (repository.Exists(x => x.FormCode == numberRule.FormCode))
                {
                    return webResponse.Error("目标表单已存在");
                }
                return webResponse.OK();
            };
            return base.Add(saveDataModel);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveDataModel)
        {
            //编辑方法保存数据库前处理
            UpdateOnExecuting = (Albert_BasicNumberRule numberRule, object addList, object updateList, List<object> delKeys) =>
            {
                if (repository.Exists(x => x.FormCode == numberRule.FormCode && x.BasicNumberRulePkInt != numberRule.BasicNumberRulePkInt))
                {
                    return webResponse.Error("目标表单已存在");
                }
                return webResponse.OK();
            };
            return base.Update(saveDataModel);
        }

    }
}
