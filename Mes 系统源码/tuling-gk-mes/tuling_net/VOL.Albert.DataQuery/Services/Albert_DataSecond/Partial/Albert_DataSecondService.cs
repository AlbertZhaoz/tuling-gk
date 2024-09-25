/*
 *所有关于Albert_DataSecond类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Albert_DataSecondService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/

using System;
using System.Collections.Generic;
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
using VOL.Albert.DataQuery.IRepositories;
using System.Threading.Tasks;
using VOL.Albert.DataQuery.IServices;
using VOL.Core.CacheManager;
using VOL.Core.Const;

namespace VOL.Albert.DataQuery.Services
{
    public partial class Albert_DataSecondService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAlbert_DataSecondRepository _repository;//访问数据库
        private readonly ICacheService _cacheService;//缓存
        private readonly Itbl_record_data_230Service _tb230Service;

        [ActivatorUtilitiesConstructor]
        public Albert_DataSecondService(
            IAlbert_DataSecondRepository dbRepository,
            IHttpContextAccessor httpContextAccessor, ICacheService cacheService, Itbl_record_data_230Service tb230Service)
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _cacheService = cacheService;
            _tb230Service = tb230Service;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override WebResponseContent Export(PageDataOptions pageData)
        {
            return base.Export(pageData);
        }
    }
}
