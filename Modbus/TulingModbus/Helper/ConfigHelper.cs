using System.IO.Ports;
using HslCommunication.Core;
using Sunny.UI;

namespace TulingModbus.Helper
{
    [ConfigFile("Config\\Setting.ini")]
    public class ConfigHelper:IniConfig<ConfigHelper>
    {
        public string PortName { get; set; }

        public int BaudRate { get; set; }

        public int DataBits { get; set; }

        public StopBits StopBits { get; set; }

        public Parity Parity { get; set; }
        public bool RtsEnable { get; set; }
        public int ReceiveTimeOut { get; set; }
        public byte Station { get; set; }
        public DataFormat DataFormat { get; set; }
        public bool AddressStartWithZero { get; set; }
        public bool Crc16CheckEnable { get; set; }

        public override void SetDefault()
        {
            base.SetDefault();
            PortName = "COM2";
            BaudRate = 9600;
            DataBits = 8;
            StopBits = StopBits.One;
            Parity = Parity.None;
            RtsEnable = false;
            ReceiveTimeOut = 5000;
            Station = 1;
            DataFormat = DataFormat.CDAB;
            AddressStartWithZero = true;
            Crc16CheckEnable = true;
        }
    }
}