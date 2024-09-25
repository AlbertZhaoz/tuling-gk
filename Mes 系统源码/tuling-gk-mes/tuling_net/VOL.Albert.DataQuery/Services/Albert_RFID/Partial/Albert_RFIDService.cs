/*
 *所有关于Albert_RFID类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Albert_RFIDService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/

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
using Newtonsoft.Json;
using SqlSugar.IOC;
using VOL.Albert.DataQuery.IRepositories;
using VOL.Core.CacheManager;

namespace VOL.Albert.DataQuery.Services
{
    public partial class Albert_RFIDService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAlbert_RFIDRepository _repository;//访问数据库
        private ICacheService _cacheService;

        [ActivatorUtilitiesConstructor]
        public Albert_RFIDService(
            IAlbert_RFIDRepository dbRepository,
            IHttpContextAccessor httpContextAccessor,
            ICacheService cacheService
        )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            _cacheService = cacheService;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }
    }
}
