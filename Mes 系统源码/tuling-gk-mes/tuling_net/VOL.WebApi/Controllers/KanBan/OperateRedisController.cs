using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VOL.Albert.DataQuery.IRepositories;
using VOL.Core.CacheManager;
using VOL.Core.Const;
using VOL.Core.Utilities;

namespace VOL.WebApi.Controllers.KanBan;

[AllowAnonymous]
[Route("api/OperateRedis")]
public class OperateRedisController:Controller
{
    private readonly ICacheService _cacheService;
    private readonly IAlbert_DataSecondRepository _dataSecondRepository;
    
    private WebResponseContent webResponse;

    public OperateRedisController(ICacheService cacheService, IAlbert_DataSecondRepository dataSecondRepository)
    {
        _cacheService = cacheService;
        _dataSecondRepository = dataSecondRepository;
    }

    [HttpGet("PushProductFromRedis2Sql")]
    public async Task<WebResponseContent> PushProductFromRedis2Sql(string isDelete,string productCode = "")
    {
        webResponse = new WebResponseContent();
        
        _cacheService.GetInstance().XAdd(CacheConst.MESSAGE_STREAM_KEY,
            new (string, string)[]
            {
                (CacheConst.MESSAGE_STREAM_ISDELETE, isDelete),
                (CacheConst.MESSAGE_STREAM_PRODUCTCODE, productCode.Trim())
            });

        return webResponse.OK("已发到消息等待处理");
    }
    
    [HttpGet("PushProductFromSql2Redis")]
    public async Task<WebResponseContent> PushProductFromSql2Redis(string productCode)
    {
        webResponse = new WebResponseContent();

        var albertDataSecond = _dataSecondRepository.FindFirst(x=>x.ProductCode == productCode.Trim());

        if (albertDataSecond == null)
        {
            return webResponse.Error("未查询到相关数据");
        }

        _cacheService.AddObject(CacheConst.VOL_DATA_PRODUCT + productCode.Trim(), albertDataSecond);

        return webResponse.OK("已将该产品推送到 Redis 中");
    }
}