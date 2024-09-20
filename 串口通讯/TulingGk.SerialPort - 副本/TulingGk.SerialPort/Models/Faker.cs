using System.Collections.Generic;
using System.IO.Ports;
using System.Net;

namespace TulingGk.SerialPort.Models
{
    public static class Faker
    {
        public static List<string> GetTypes()
        {
            return new List<string>()
            {
                "TCP Server",
                "TCP Client",
                "UDP",
                "Modbus",
                "WebSocket",
                "Rpc",
                "WebApi",
                "JsonRpc"
            };
        }

        public static List<string> GetIps()
        {
            var ips = new List<string>();

            ips.Add("127.0.0.1");

            foreach (var item in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if(item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ips.Add(item.ToString());
                }
            }

            ips.Add("0.0.0.0");

            return ips;
        }
    }
}