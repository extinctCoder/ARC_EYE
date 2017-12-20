using System;
using System.IO;
using System.Net.Sockets;

namespace ARC_EYE
{
	public static partial class ConnectorOne
	{
		public static string imuData = null;

		public static event EventHandler pi1Port1DisconnectedStatusEvent;
		public static event EventHandler pi1Port1ConnectedStatusEvent;
		public static event EventHandler pi1Port2DisconnectedStatusEvent;
		public static event EventHandler pi1Port2ConnectedStatusEvent;
		public static event EventHandler pi3Port1DisconnectedStatusEvent;
		public static event EventHandler pi3Port1ConnectedStatusEvent;

		private static string pi1Ip;
		private static int pi1Port1;
		private static int pi1Port2;
		private static string pi2Ip;
		private static int pi2Port1;
		private static int pi2Port2;

		private static string pi3Ip;
		private static int pi3Port1;
		private static int pi3Port2;

		private static TcpClient pi1Port1Tcp;
		private static StreamWriter pi1Port1SwSender;
		private static StreamReader pi1Port1SrReciever;
		private static NetworkStream pi1Port1NetworkStream;

		private static TcpClient pi1Port2Tcp;
		private static StreamWriter pi1Port2SwSender;
		private static StreamReader pi1Port2SrReciever;
		private static NetworkStream pi1Port2NetworkStream;

		private static TcpClient pi3Port1Tcp;
		private static StreamWriter pi3Port1SwSender;
		private static StreamReader pi3Port1SrReciever;
		private static NetworkStream pi3Port1NetworkStream;

		public static bool addressUpdater()
		{
			try
			{
				ConnectorOne.pi1Ip = SettingsModule.getPi1Ip();
				RoverConsole.ArcEyeContent("pi1Ip : " + pi1Ip.ToString());
				ConnectorOne.pi1Port1 = Convert.ToInt32(SettingsModule.getPi1Port1());
				RoverConsole.ArcEyeContent("pi1Port1 : " + pi1Port1.ToString());
				ConnectorOne.pi1Port2 = Convert.ToInt32(SettingsModule.getPi1Port2());
				RoverConsole.ArcEyeContent("pi1Port2 : " + pi1Port2.ToString());
				ConnectorOne.pi2Ip = SettingsModule.getPi2Ip();
				RoverConsole.ArcEyeContent("pi2Ip : " + pi2Ip.ToString());
				ConnectorOne.pi2Port1 = Convert.ToInt32(SettingsModule.getPi2Port1());
				RoverConsole.ArcEyeContent("pi2Port1 : " + pi2Port1.ToString());
				ConnectorOne.pi2Port2 = Convert.ToInt32(SettingsModule.getPi2Port2());
				RoverConsole.ArcEyeContent("pi2Port2 : " + pi2Port2.ToString());
				ConnectorOne.pi3Ip = SettingsModule.getPi3Ip();
				RoverConsole.ArcEyeContent("pi3Ip : " + pi3Ip.ToString());
				ConnectorOne.pi3Port1 = Convert.ToInt32(SettingsModule.getPi3Port1());
				RoverConsole.ArcEyeContent("pi3Port1 : " + pi3Port1.ToString());
				ConnectorOne.pi3Port2 = Convert.ToInt32(SettingsModule.getPi3Port2());
				RoverConsole.ArcEyeContent("pi3Port2 : " + pi3Port2.ToString());
				RoverConsole.ArcEyeAiContent("IP PORT ASSIGN SUCCESSFULL ... !!!");
				return true;
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContent(ex.ToString());
				return false;
			}
		}
		public static void pi1Port1AddressUpdater()
		{
			try
			{
				ConnectorOne.pi1Ip = SettingsModule.getPi1Ip();
				RoverConsole.ArcEyeContentThreadSafe("pi1Ip : " + pi1Ip.ToString());
				ConnectorOne.pi1Port1 = Convert.ToInt32(SettingsModule.getPi1Port1());
				RoverConsole.ArcEyeContent("pi1Port1 : " + pi1Port1.ToString());
				RoverConsole.ArcEyeAiContentThreadSafe("PI1 IP PORT1 ASSIGN SUCCESSFULL ... !!!");
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
			}
		}
		public static void pi1Port2AddressUpdater()
		{
			try
			{
				ConnectorOne.pi1Ip = SettingsModule.getPi1Ip();
				RoverConsole.ArcEyeContent("pi1Ip : " + pi1Ip.ToString());
				ConnectorOne.pi1Port2 = Convert.ToInt32(SettingsModule.getPi1Port2());
				RoverConsole.ArcEyeContent("pi1Port2 : " + pi1Port2.ToString());
				RoverConsole.ArcEyeAiContent("PI1 IP PORT2 ASSIGN SUCCESSFULL ... !!!");
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContent(ex.ToString());
			}
		}
		public static void pi2Port1AddressUpdater()
		{
			try
			{
				ConnectorOne.pi2Ip = SettingsModule.getPi1Ip();
				RoverConsole.ArcEyeContentThreadSafe("pi2Ip : " + pi2Ip.ToString());
				ConnectorOne.pi2Port1 = Convert.ToInt32(SettingsModule.getPi2Port1());
				RoverConsole.ArcEyeContent("pi2Port1 : " + pi2Port1.ToString());
				RoverConsole.ArcEyeAiContentThreadSafe("PI2 IP PORT1 ASSIGN SUCCESSFULL ... !!!");
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
			}
		}
		public static void pi2Port2AddressUpdater()
		{
			try
			{
				ConnectorOne.pi2Ip = SettingsModule.getPi2Ip();
				RoverConsole.ArcEyeContent("pi2Ip : " + pi2Ip.ToString());
				ConnectorOne.pi2Port2 = Convert.ToInt32(SettingsModule.getPi2Port1());
				RoverConsole.ArcEyeContent("pi2Port2 : " + pi2Port2.ToString());
				RoverConsole.ArcEyeAiContent("PI2 IP PORT2 ASSIGN SUCCESSFULL ... !!!");
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContent(ex.ToString());
			}
		}
		public static void pi3Port1AddressUpdater()
		{
			try
			{
				ConnectorOne.pi3Ip = SettingsModule.getPi3Ip();
				RoverConsole.ArcEyeContentThreadSafe("pi3Ip : " + pi3Ip.ToString());
				ConnectorOne.pi3Port1 = Convert.ToInt32(SettingsModule.getPi3Port1());
				RoverConsole.ArcEyeContent("pi3Port1 : " + pi3Port1.ToString());
				RoverConsole.ArcEyeAiContentThreadSafe("PI3 IP PORT1 ASSIGN SUCCESSFULL ... !!!");
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
			}
		}
		public static void pi3Port2AddressUpdater()
		{
			try
			{
				ConnectorOne.pi3Ip = SettingsModule.getPi3Ip();
				RoverConsole.ArcEyeContent("pi3Ip : " + pi3Ip.ToString());
				ConnectorOne.pi3Port2 = Convert.ToInt32(SettingsModule.getPi3Port1());
				RoverConsole.ArcEyeContent("pi1Port3 : " + pi3Port2.ToString());
				RoverConsole.ArcEyeAiContent("PI3 IP PORT2 ASSIGN SUCCESSFULL ... !!!");
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContent(ex.ToString());
			}
		}
		public static void pi1Port1ConnectionEnabler()
		{
			ConnectorOne.pi1Port1AddressUpdater();
			RoverConsole.ArcEyeContentThreadSafe("Checking Pi1 Connection via Port1");
			try
			{
				pi1Port1Tcp = new TcpClient();
				pi1Port1Tcp.Connect(pi1Ip, pi1Port1);
				pi1Port1NetworkStream = pi1Port1Tcp.GetStream();
				pi1Port1SrReciever = new StreamReader(pi1Port1NetworkStream);
				pi1Port1SwSender = new StreamWriter(pi1Port1NetworkStream);
				RoverConsole.ArcEyeContentThreadSafe("Pi1 via Port1 Connection Successful");
				if (ConnectorOne.pi1Port1ConnectedStatusEvent != null)
				{
					ConnectorOne.pi1Port1ConnectedStatusEvent(new object(), new EventArgs());
				}
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
				if (ConnectorOne.pi1Port1DisconnectedStatusEvent != null)
				{
					ConnectorOne.pi1Port1DisconnectedStatusEvent(new object(), new EventArgs());
				}
			}
		}
		public static void RoverMovementStatusUpdater(RoverAndArmRoverMovement roverMovement, double pwm)
		{
			try
			{
				RoverConsole.ArcEyeAiContent("Uploading Rover Movement Command : Direction-" + roverMovement.ToString() + ", Speed-" + pwm.ToString());
				pi1Port1SwSender.AutoFlush = true;
				pi1Port1SwSender.Write(Convert.ToString(Convert.ToInt32(roverMovement)) + "," + Convert.ToString(pwm));
				RoverConsole.ArcEyeAiContent("Command Uploaded to Pi1 via port1");
				if (ConnectorOne.pi1Port1ConnectedStatusEvent != null)
				{
					ConnectorOne.pi1Port1ConnectedStatusEvent(new object(), new EventArgs());
				}
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
				RoverConsole.ArcEyeAiContentThreadSafe("Trying To Reconnect");
				if (ConnectorOne.pi1Port1DisconnectedStatusEvent != null)
				{
					ConnectorOne.pi1Port1DisconnectedStatusEvent(new object(), new EventArgs());
				}

			}

		}
		public static void pi1Port2ConnectionEnabler()
		{
			ConnectorOne.pi1Port2AddressUpdater();
			RoverConsole.ArcEyeContentThreadSafe("Checking Pi1 Connection via Port2");
			try
			{
				pi1Port2Tcp = new TcpClient();
				pi1Port2Tcp.Connect(pi1Ip, pi1Port2);
				pi1Port2NetworkStream = pi1Port2Tcp.GetStream();
				pi1Port2SrReciever = new StreamReader(pi1Port2NetworkStream);
				pi1Port2SwSender = new StreamWriter(pi1Port2NetworkStream);
				RoverConsole.ArcEyeContentThreadSafe("Pi1 via Port2 Connection Successful");
				if (ConnectorOne.pi1Port2ConnectedStatusEvent != null)
				{
					ConnectorOne.pi1Port2ConnectedStatusEvent(new object(), new EventArgs());
				}
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
				if (ConnectorOne.pi1Port2DisconnectedStatusEvent != null)
				{
					ConnectorOne.pi1Port2DisconnectedStatusEvent(new object(), new EventArgs());
				}
			}
		}
		public static void RoveArmStatusUpdater(MotorName motorName, HandMovement handMovement)
		{
			try
			{
				RoverConsole.ArcEyeAiContent("Uploading Rover Arm Command : Motor Name-" + motorName.ToString() + ", Hand Movement-" + handMovement.ToString());
				pi1Port2SwSender.AutoFlush = true;
				pi1Port2SwSender.Write(Convert.ToString(Convert.ToInt32(motorName)) + "," + Convert.ToInt32(handMovement));
				RoverConsole.ArcEyeAiContent("Command Uploaded to Pi1 via port2");
				if (ConnectorOne.pi1Port2ConnectedStatusEvent != null)
				{
					ConnectorOne.pi1Port2ConnectedStatusEvent(new object(), new EventArgs());
				}
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
				RoverConsole.ArcEyeAiContentThreadSafe("Trying To Reconnect");
				if (ConnectorOne.pi1Port2DisconnectedStatusEvent != null)
				{
					ConnectorOne.pi1Port2DisconnectedStatusEvent(new object(), new EventArgs());
				}

			}

		}
	}
}
