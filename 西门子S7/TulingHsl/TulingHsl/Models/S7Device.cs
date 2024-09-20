using HslCommunication.Profinet.Siemens;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace TulingHsl.Models
{
    public class S7Device:DeviceModel
    {
        public SiemensPLCS Type { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public string HeartAddress { get; set; }
        public string GetExcelPath { get; set; }
        public string SetExcelPath { get; set; }
        public bool IsSelected {get;set; }
        
        /// <summary>
        /// 创建的时候直接 new 出来一个对象，不需要每次都 new
        /// </summary>
        public SiemensS7Net SiemensS7NetHandle { get; set; }

        /// <summary>
        /// 是否连接成功
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// 心跳的Cts
        /// </summary>
        public CancellationTokenSource HeartCts { get; set; } = new CancellationTokenSource();
        public Task HeartTask { get; set; }

        public ConcurrentDictionary<string,CancellationTokenSource> GetDataTaskDic { get; set; } = new ConcurrentDictionary<string, CancellationTokenSource>();
    }
}