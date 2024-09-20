using System;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;

namespace VOL.Core.Communication
{
    public static class IpOperate
    {
        public static bool CmdPing(string strHost)
        {
            try
            {
                lock (strHost)
                {
                    var host = strHost;
                    if (host == "." || host == "localhost")
                    {
                        host = "127.0.0.1";
                    }
                    if (!IPAddress.TryParse(host, out _))
                    {
                        return false;
                    }
                    // Windows L2TP VPN和非Windows VPN使用ping VPN服务端的方式获取是否可以连通     
                    var pingSender = new Ping();
                    // Use the default Ttl value which is 128,     
                    // but change the fragmentation behavior.   
                    var options = new PingOptions
                    {
                        DontFragment = true
                    };

                    // Create a buffer of 32 bytes of data to be transmitted.     
                    const string data = "test";
                    var buffer = Encoding.ASCII.GetBytes(data);
                    const int timeout = 50;
                    var reply = pingSender.Send(host, timeout, buffer, options);

                    return reply != null && (reply.Status == IPStatus.Success);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
