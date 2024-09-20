/*
 *所有关于Albert_BasicWorkshop类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Albert_BasicWorkshopService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/

using System;
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
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using VOL.Albert.BasicData.IRepositories;

namespace VOL.Albert.BasicData.Services
{
    public partial class Albert_BasicWorkshopService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAlbert_BasicWorkshopRepository _repository;//访问数据库
        private readonly IAlbert_BasicNumberRuleRepository _basicNumberRuleRepository;// 编码规则数据库

        [ActivatorUtilitiesConstructor]
        public Albert_BasicWorkshopService(
            IAlbert_BasicWorkshopRepository dbRepository,
            IAlbert_BasicNumberRuleRepository basicNumberRuleRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _basicNumberRuleRepository= basicNumberRuleRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        WebResponseContent webResponse = new WebResponseContent();

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="saveDataModel"></param>
        /// <returns></returns>
        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            //此处saveModel是从前台提交的原生数据，可对数据进修改过滤
            // AddOnExecute = (SaveModel saveModel) =>
            // {
            //     //如果返回false,后面代码不会再执行
            //     return webResponse.OK();
            // };

            // 在保存数据库前的操作，所有数据都验证通过了，这一步执行完就执行数据库保存
            AddOnExecuting = (Albert_BasicWorkshop workshop, object list) =>
            {
                if (string.IsNullOrWhiteSpace(workshop.BasicWorkshopCode))
                    workshop.BasicWorkshopCode = GetWorkshpCode();
                //如果返回false,后面代码不会再执行
                if (repository.Exists(x => x.BasicWorkshopCode == workshop.BasicWorkshopCode))
                {
                    return webResponse.Error("车间编号已存在");
                }
                return webResponse.OK();
            };
            return base.Add(saveDataModel);
        }



        /// <summary>
        /// 自动生成设备编号
        /// </summary>
        /// <returns></returns>
        public string GetWorkshpCode()
        {
            DateTime dateNow = (DateTime)DateTime.Now.ToString("yyyy-MM-dd").GetDateTime();
            //查询当天最新的订单号
            string defectItemCode = repository.FindAsIQueryable(x => x.CreateDate > dateNow && x.BasicWorkshopCode.Length > 8)
                .OrderByDescending(x => x.BasicWorkshopCode)
                .Select(s => s.BasicWorkshopCode)
                .FirstOrDefault();
            var numberRule = _basicNumberRuleRepository.FindAsIQueryable(x => x.FormCode == "BasicWorkshopCode")
                .OrderByDescending(x => x.CreateDate)
                .FirstOrDefault();
            if (numberRule != null)
            {
                string rule = numberRule.Prefix + DateTime.Now.ToString(numberRule.SubmitTime.Replace("hh", "HH"));
                if (string.IsNullOrEmpty(defectItemCode))
                {
                    rule += "1".PadLeft((int)numberRule.SerialNumber, '0');
                }
                else
                {
                    rule += (defectItemCode.Substring(defectItemCode.Length - (int)numberRule.SerialNumber).GetInt() + 1).ToString("0".PadLeft((int)numberRule.SerialNumber, '0'));
                }
                return rule;
            }
            else //如果自定义序号配置项不存在，则使用日期生成
            {
                return DateTime.Now.ToString("yyyyMMddHHmmssffff");
            }
        }
    }
}
