/*
*所有关于Albert_DataFirst类的业务代码接口应在此处编写
*/
using VOL.Core.Utilities;
using System.Threading.Tasks;

namespace VOL.Albert.DataQuery.IServices
{
    public partial interface IAlbert_DataFirstService
    {
        Task<WebResponseContent> GetLastStationAsync(int reworkNumber, string productCode);
        Task<WebResponseContent> UpdateLastStationAsync(int reworkNumber, string productCode, string lastStepName);
    }
 }
