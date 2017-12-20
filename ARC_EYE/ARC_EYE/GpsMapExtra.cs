using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ARC_EYE
{
    public partial class GpsMap
    {
        public static bool PingNetwork(string hostNameOrAddress)
        {
            using (Ping p = new Ping())
            {
                byte[] buffer = Encoding.ASCII.GetBytes("network test string");
                int timeout = 4444; // 4s

                try
                {
                    PingReply reply = p.Send(hostNameOrAddress, timeout, buffer);
                    return (reply.Status == IPStatus.Success) ? true : false;
                }
                catch (Exception ex)
                {
                    RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
                }
            }
            return false;
        }
    }
    class GpsMapExtra
    {
    }
}
