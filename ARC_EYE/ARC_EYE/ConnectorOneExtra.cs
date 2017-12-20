using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ARC_EYE
{
    public static partial  class ConnectorOne
    {
        public static void pi3Port1ConnectionEnabler()
        {
            ConnectorOne.pi3Port1AddressUpdater();
            RoverConsole.ArcEyeContentThreadSafe("Checking Pi3 Connection via Port1");
            try
            {
                pi3Port1Tcp = new TcpClient();
                pi3Port1Tcp.Connect(pi3Ip, pi3Port1);
                pi3Port1NetworkStream = pi3Port1Tcp.GetStream();
                pi3Port1SrReciever = new StreamReader(pi3Port1NetworkStream);
                pi3Port1SwSender = new StreamWriter(pi3Port1NetworkStream);
                RoverConsole.ArcEyeContentThreadSafe("Pi3 via Port1 Connection Successful");
                if (ConnectorOne.pi3Port1ConnectedStatusEvent != null)
                {
                    ConnectorOne.pi3Port1ConnectedStatusEvent(new object(), new EventArgs());
                }
                Thread imuDataHandlerThread = new Thread(() => imuInputHandler());
                imuDataHandlerThread.Name = "imuDataHandlerThread";
                imuDataHandlerThread.IsBackground = true;
                imuDataHandlerThread.Start();
            }
            catch (Exception ex)
            {
                RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
                if (ConnectorOne.pi3Port1DisconnectedStatusEvent != null)
                {
                    ConnectorOne.pi3Port1DisconnectedStatusEvent(new object(), new EventArgs());
                }
            }
        }
        private static void imuInputHandler()
        {
            try
            {
                pi3Port1SwSender.AutoFlush = true;
                while (true)
                {
                    imuData = pi3Port1SrReciever.ReadLine();
                    //RoverConsole.ArcEyeAiContentThreadSafe("IMU Data Received : " + ConnectorOne.imuData);
                }
            }
            catch (Exception ex)
            {
                RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
                RoverConsole.ArcEyeAiContentThreadSafe("Trying To Reconnect");
                if (ConnectorOne.pi3Port1DisconnectedStatusEvent != null)
                {
                    ConnectorOne.pi3Port1DisconnectedStatusEvent(new object(), new EventArgs());
                }

            }
        }
        public static string getImuData()
        {
            if (imuData != null)
            {
                return ConnectorOne.imuData;
            }
            else
            {
                return "0,0,0,0,0,0";
            }
        }
    }
    class ConnectorOneExtra
    {
    }
}
