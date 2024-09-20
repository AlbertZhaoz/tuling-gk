/*
 *所有关于tbl_record_data_290_view类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*tbl_record_data_290_viewService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
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
using VOL.Albert.DataQuery.IRepositories;
using Newtonsoft.Json;
using SqlSugar.IOC;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;

namespace VOL.Albert.DataQuery.Services
{
    public partial class Itbl_Record_Data_290Service
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Itbl_record_data_290Repository _repository;//访问数据库
        private WebResponseContent _responseContent = new();

        [ActivatorUtilitiesConstructor]
        public Itbl_Record_Data_290Service(
            Itbl_record_data_290Repository dbRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(dbRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = dbRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        public override PageGridData<tbl_record_data_290> GetPageData(PageDataOptions options)
        {
            var pageGridData = new PageGridData<tbl_record_data_290>();
            int totalCount = 0;
            var searchParameters = JsonConvert.DeserializeObject<List<SearchParameters>>(options.Wheres);
            Dictionary<string, object> columnsWhere = new Dictionary<string, object>();

            foreach (var searchParameter in searchParameters)
            {
                columnsWhere.Add(searchParameter.Name, searchParameter.Value);
            }

            var data = DbScoped.SugarScope
                .GetConnection("op290")
                .Queryable<tbl_record_data_290>()
                .AS("tbl_record_data")
                .WhereColumns(columnsWhere)
                .OrderBy(options.Sort)
                .ToPageList(options.Page, options.Rows, ref totalCount);


            pageGridData.total = totalCount;
            pageGridData.rows = data;
            pageGridData.msg = "来源于 SqlSugar 多租户查询";

            return pageGridData;
        }

        public override WebResponseContent Export(PageDataOptions options)
        {
            options.Export = true;

            var data = DbScoped.SugarScope
                .GetConnection("op290")
                .Queryable<tbl_record_data_290>()
                .AS("tbl_record_data")
                .ToList();

            string tableName = typeof(T).GetEntityTableCnName();
            string fileName = tableName + DateTime.Now.ToString("yyyyMMddHHssmm") + ".xlsx";
            string folder = DateTime.Now.ToString("yyyyMMdd");
            string savePath = $"Download/ExcelExport/{folder}/".MapPath();
            List<string> ignoreColumn = new List<string>();
            //ExportColumns 2020.05.07增加扩展指定导出模板的列
            EPPlusHelper.Export(data, ExportColumns?.GetExpressionToArray(), ignoreColumn, savePath, fileName);
            //return Response.OK(null, (savePath + "/" + fileName).EncryptDES(AppSetting.Secret.ExportFile));
            //2022.01.08优化导出功能
            return _responseContent.OK(null, (savePath + "/" + fileName));
        }
    }
}
