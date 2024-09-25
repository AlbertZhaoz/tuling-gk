/*
 *所有关于Albert_DataFirst类的业务代码应在此处编写
*可使用repository.调用常用方法，获取EF/Dapper等信息
*如果需要事务请使用repository.DbContextBeginTransaction
*也可使用DBServerProvider.手动获取数据库相关信息
*用户信息、权限、角色等使用UserContext.Current操作
*Albert_DataFirstService对增、删、改查、导入、导出、审核业务代码扩展参照ServiceFunFilter
*/
using VOL.Entity.DomainModels;
using VOL.Core.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using VOL.Albert.DataQuery.IRepositories;
using VOL.Albert.Device.IRepositories;
using System.Threading.Tasks;
using System;
using AgileObjects.AgileMapper;
using VOL.Core.BaseProvider;
using VOL.Entity.SystemModels;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using VOL.Core.Extensions;
using System.Linq;

namespace VOL.Albert.DataQuery.Services
{
    public partial class Albert_DataFirstService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAlbert_DataFirstRepository _firstRepository;//访问数据库
        private readonly IAlbert_DataSecondRepository _secondRepository;//访问数据库
        private readonly IAlbert_DataFirstReworkRepository _firstReworkRepository;//访问数据库
        private readonly IAlbert_DataSecondReworkRepository _secondReworkRepository;//访问数据库
        private readonly IAlbert_DeviceStationConfigureRepository _deviceStationConfigureRepository;//访问数据库
        
        private WebResponseContent webResponse = null;

        [ActivatorUtilitiesConstructor]
        public Albert_DataFirstService(
            IAlbert_DataFirstRepository firstRepository,
            IAlbert_DataSecondRepository secondRepository,
            IAlbert_DataFirstReworkRepository firstReworkRepository,
            IAlbert_DataSecondReworkRepository secondReworkRepository,
            IAlbert_DeviceStationConfigureRepository deviceStationConfigureRepository,
            IHttpContextAccessor httpContextAccessor
            )
        : base(firstRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _firstRepository = firstRepository;
            _secondRepository = secondRepository;
            _firstReworkRepository = firstReworkRepository;
            _secondReworkRepository = secondReworkRepository;
            _deviceStationConfigureRepository = deviceStationConfigureRepository;
            //多租户会用到这init代码，其他情况可以不用
            //base.Init(dbRepository);
        }

        /// <summary>
        /// 根据环形线和产品码获取最后一站的 step
        /// </summary>
        /// <param name="reworkNumber"></param>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public async Task<WebResponseContent> GetLastStationAsync(int reworkNumber, string productCode)
        {
            try
            {
                webResponse = new WebResponseContent();
                if (reworkNumber == 1)
                {
                    var finalStation = await _firstRepository.FindAsyncFirst(x => x.ProductCode == productCode);

                    if (finalStation != null)
                    {
                        var deviceStationList = await _deviceStationConfigureRepository.FindAsync(x => x.DevicePkInt>0);
                        webResponse.Data = deviceStationList.ToList()
                            .FirstOrDefault(x => string.Equals(x.DeviceDBName, finalStation.OpFinalStation, StringComparison.OrdinalIgnoreCase));
                        return webResponse.OK();
                    }
                    else
                    {
                        webResponse.Data = 0;
                        
                        return webResponse.Error("环形1线未查询到数据");
                    }
                }
                else if(reworkNumber == 2)
                {
                    var finalStation = await _secondRepository.FindAsyncFirst(x => x.ProductCode == productCode);

                    if (finalStation != null)
                    {
                        var deviceStationList = await _deviceStationConfigureRepository.FindAsync(x => x.DevicePkInt > 0);
                        webResponse.Data = deviceStationList.ToList()
                            .FirstOrDefault(x => string.Equals(x.DeviceDBName, finalStation.OpFinalStation, StringComparison.OrdinalIgnoreCase));
                        return webResponse.OK();
                    }
                    else
                    {
                        webResponse.Data = 0;

                        return webResponse.Error("环形2线未查询到数据");
                    }
                }
                else
                {
                    webResponse.Data = 0;

                    return webResponse.Error("请输入正确的环形线代码，1 或 2");
                }

            }
            catch (System.Exception ex)
            {
                return webResponse.Error(ex.Message);
            }

        }

        public async Task<WebResponseContent> UpdateLastStationAsync(int reworkNumber,string productCode, string lastStepName)
        {
            try
            {
                webResponse = new WebResponseContent();

                // 对原始数据进行更新操作，对 Rework 表进行插入操作
                if (reworkNumber == 1)
                {
                    var finalStation = await _firstRepository.FindAsyncFirst(x => x.ProductCode == productCode);

                    if(finalStation != null)
                    {
                        finalStation.OpFinalStation = lastStepName;
                        _firstRepository.Update(finalStation);
                        await _firstRepository.SaveChangesAsync();

                        var finalStationRework = Mapper.Map(finalStation).ToANew<Albert_DataFirstRework>();
                        finalStationRework.ModifyDate = DateTime.Now;

                        _firstReworkRepository.Add(finalStationRework);
                        await _firstReworkRepository.SaveChangesAsync();

                        return webResponse.OK();
                    }
                    else
                    {
                        return webResponse.Error("产品码未查询到数据");
                    }

                    
                }

                if (reworkNumber == 2)
                {

                    var finalStation = await _secondRepository.FindAsyncFirst(x => x.ProductCode == productCode);
                    if (finalStation != null)
                    {
                        finalStation.OpFinalStation = lastStepName;
                        _secondRepository.Update(finalStation);
                        await _secondRepository.SaveChangesAsync();

                        var finalStationRework = Mapper.Map(finalStation).ToANew<Albert_DataSecondRework>();
                        finalStationRework.ModifyDate = DateTime.Now;

                        _secondReworkRepository.Add(finalStationRework);
                        await _secondReworkRepository.SaveChangesAsync();

                        return webResponse.OK();
                    }
                    else
                    {
                        return webResponse.Error("产品码未查询到数据");
                    }
                }    

                return webResponse.Error("请输入正确的环形线代码，1 或 2,保证更新成功");
            }
            catch (Exception ex)
            {
                return webResponse.Error(ex.Message);
            }
           
        }
    }
}
