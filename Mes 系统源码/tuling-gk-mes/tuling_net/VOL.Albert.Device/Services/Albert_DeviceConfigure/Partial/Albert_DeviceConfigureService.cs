/*
 *所有关于Albert_DeviceConfigure类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Albert_DeviceConfigureService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/

using VOL.Entity.DomainModels;
using System.Linq;
using VOL.Core.Utilities;
using VOL.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VOL.Albert.Device.IRepositories;
using System.Collections.Generic;
using System;
using VOL.Albert.BasicData.IRepositories;

namespace VOL.Albert.Device.Services
{
    public partial class Albert_DeviceConfigureService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        // 设备数据库
        private readonly IAlbert_DeviceConfigureRepository _repository;
        // 设备 DB 块数据库
        private readonly IAlbert_DeviceStationConfigureRepository _deviceStationConfigureRepository;
        // 编码规则数据库
        private readonly IAlbert_BasicNumberRuleRepository _basicNumberRuleRepository;
        

        [ActivatorUtilitiesConstructor]
        public Albert_DeviceConfigureService(
            IAlbert_DeviceConfigureRepository dbRepository,
            IAlbert_DeviceStationConfigureRepository deviceStationConfigureRepository,
            IAlbert_BasicNumberRuleRepository basicNumberRuleRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _deviceStationConfigureRepository = deviceStationConfigureRepository;
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
            AddOnExecuting = (Albert_DeviceConfigure device, object list) =>
            {
                if (string.IsNullOrWhiteSpace(device.DeviceCode))
                    device.DeviceCode = GetDeviceCode();
                //如果返回false,后面代码不会再执行
                if (repository.Exists(x => x.DeviceCode == device.DeviceCode))
                {
                    return webResponse.Error("设备编号已存在");
                }
                return webResponse.OK();
            };
            return base.Add(saveDataModel);
        }

        /// <summary>
        /// 编辑操作
        /// </summary>
        /// <param name="saveModel"></param>
        /// <returns></returns>
        public override WebResponseContent Update(SaveModel saveModel)
        {
            UpdateOnExecute = (SaveModel model) =>
            {
                return webResponse.OK();
            };
            //编辑方法保存数据库前处理
            UpdateOnExecuting = (Albert_DeviceConfigure device, object addList, object updateList, List<object> delKeys) =>
            {
                return webResponse.OK();
            };
            return base.Update(saveModel);
        }

        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                var key = keys[i].ToInt();

                // 这种方式效率比较低，在 EF Core 执行层面会先将数据  Select 出来，然后再执行 Delete 操作。
                // 这边两种方式：
                // 1. 引入批量删除的开源组件 Zack.EFCore.Batch 
                // 2. 框架的明细表，直接就可以级联删除，无需写代码。
                var deviceList = _repository.FindAsIQueryable(x => x.DevicePkInt == key).ToList();
                _repository.DbContext.RemoveRange(deviceList);

                var dbDeviceList = _deviceStationConfigureRepository.FindAsIQueryable(x => x.DevicePkInt == key).ToArray();
                _deviceStationConfigureRepository.DbContext.RemoveRange(dbDeviceList);
            }
            //最终保存
            _repository.SaveChanges();
            _deviceStationConfigureRepository.SaveChanges();
            return webResponse.OK();
        }

        /// <summary>
        /// 自动生成设备编号
        /// </summary>
        /// <returns></returns>
        public string GetDeviceCode()
        {
            DateTime dateNow = (DateTime)DateTime.Now.ToString("yyyy-MM-dd").GetDateTime();
            //查询当天最新的订单号
            string defectItemCode = repository.FindAsIQueryable(x => x.CreateDate > dateNow && x.DeviceCode.Length > 8)
                .OrderByDescending(x => x.DeviceCode)
                .Select(s => s.DeviceCode)
                .FirstOrDefault();
            var numberRule = _basicNumberRuleRepository.FindAsIQueryable(x => x.FormCode == "Albert_DeviceConfigure")
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
