/*
 *接口编写处...
*如果接口需要做Action的权限验证，请在Action上使用属性
*如: [ApiActionPermission("Albert_CraftParam",Enums.ActionPermissionOptions.Search)]
 */
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VOL.Entity.DomainModels;
using VOL.Albert.ProductionManager.IServices;
using System.Net;
using VOL.Core.Utilities;
using AgileObjects.AgileMapper;
using VOL.Albert.ProductionManager.IRepositories;
using VOL.Albert.ProductionManager.Repositories;
using System.Linq;
using VOL.Core.BaseProvider;

namespace VOL.Albert.ProductionManager.Controllers
{
    public partial class Albert_CraftParamController
    {
        private readonly IAlbert_CraftParamService _service;//访问业务代码
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAlbert_PdmCraftParamHistoryRepository _albert_PdmCraftParamHistoryRepository;
        private readonly IAlbert_CraftParamRepository _albert_CraftParamRepository;

        [ActivatorUtilitiesConstructor]
        public Albert_CraftParamController(
            IAlbert_CraftParamService service,
            IHttpContextAccessor httpContextAccessor,
            IAlbert_PdmCraftParamHistoryRepository albert_PdmCraftParamHistoryRepository,
            IAlbert_CraftParamRepository albert_CraftParamRepository
        )
        : base(service)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            _albert_PdmCraftParamHistoryRepository = albert_PdmCraftParamHistoryRepository;
            _albert_CraftParamRepository = albert_CraftParamRepository;
        }

        [HttpPost("SendCraftParams")]
        public WebResponseContent SendCraftParams([FromBody] List<Albert_CraftParam> carftParamList) {
            var webResponseContent = new WebResponseContent();

            if (carftParamList != null && carftParamList.Count > 0) {
                
                try
                {
                    // 1.调取 PLC 通讯接口进行下发
                    // 2. 更新发送状态
                    carftParamList.ForEach(x => x.Status = "1");

                    // 开启事务，更新和插入需要同步进行
                    WebResponseContent webResponse = _albert_CraftParamRepository.DbContextBeginTransaction(() =>
                    {
                        //如果想要回滚，返回new WebResponseContent().Error("返回消息")
                        _albert_CraftParamRepository.UpdateRange(carftParamList);
                        _albert_CraftParamRepository.SaveChanges();
                        // 3.将发送参数数据进行记录
                        var albertParamHistoryList = Mapper.Map(carftParamList).ToANew<List<Albert_PdmCraftParamHistory>>();
                        albertParamHistoryList.ForEach(x => x.ModifyDate = DateTime.Now);
                        _albert_PdmCraftParamHistoryRepository.AddRange(albertParamHistoryList);                    
                        _albert_PdmCraftParamHistoryRepository.SaveChanges();
                        return webResponseContent.OK("参数下发成功");
                    });
                    //判断事务是否执行成功
                    if (webResponse.Status)
                    {
                        return webResponseContent.OK("参数下发成功");
                    }
                    else
                    {
                        return webResponseContent.OK("参数下发失败，数据库回滚成功");
                    }
                }
                catch (Exception ex)
                {
                    return webResponseContent.OK("参数下发失败");
                }          
            }
            else
            {
                return webResponseContent.Error("请检查数据是否存在");
            }
        }
    }
}
