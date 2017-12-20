using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Control_Panel
{
	public static partial class ConnectorOne
	{
		private static string piIp = "192.168.0.223";
		public static string imuData = null;

		private static int RoverMovementPort = 8888;
		private static TcpClient piRoverMovementPortTcp;
		private static StreamWriter piRoverMovementPortSwSender;
		private static StreamReader piRoverMovementPortSrReciever;
		private static NetworkStream piRoverMovementPortNetworkStream;

		private static int CameraMovementPort = 8889;
		private static TcpClient piCameraMovementPortTcp;
		private static StreamWriter piCameraMovementPortSwSender;
		private static StreamReader piCameraMovementPortSrReciever;
		private static NetworkStream piCameraMovementPortNetworkStream;

		private static int HandMovementPort = 8890;
		private static TcpClient piHandMovementPortTcp;
		private static StreamWriter piHandMovementPortSwSender;
		private static StreamReader piHandMovementPortSrReciever;
		private static NetworkStream piHandMovementPortNetworkStream;

		private static int imuPort = 8891;
		private static TcpClient piImuPortTcp;
		private static StreamWriter piImuPortSwSender;
		private static StreamReader piImuPortSrReciever;
		private static NetworkStream piImuPortNetworkStream;

		private static int masterPort = 8879;
		private static TcpClient piMasterPortTcp;
		private static StreamWriter piMasterPortSwSender;
		private static StreamReader piMasterPortSrReciever;
		private static NetworkStream piMasterPortNetworkStream;
		private static void RoverMovementPortEnabler()
		{
			try
			{
				piRoverMovementPortTcp = new TcpClient();
				piRoverMovementPortTcp.Connect(piIp, RoverMovementPort);
				piRoverMovementPortNetworkStream = piRoverMovementPortTcp.GetStream();
				piRoverMovementPortSrReciever = new StreamReader(piRoverMovementPortNetworkStream);
				piRoverMovementPortSwSender = new StreamWriter(piRoverMovementPortNetworkStream);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "piRoverMovementPort Error");
			}
		}

		public static void RoverMovementUpdater(RoverAndArmRoverMovement roverMovement, double RoverPwm)
		{
			try
			{
				piRoverMovementPortSwSender.AutoFlush = true;
				piRoverMovementPortSwSender.Write(Convert.ToString(Convert.ToInt32(roverMovement)) + "," + Convert.ToString(RoverPwm));
			}
			catch (Exception ex)
			{
				RoverMovementPortEnabler();
			}
		}

		private static void CameraMovementPortEnabler()
		{
			try
			{
				piCameraMovementPortTcp = new TcpClient();
				piCameraMovementPortTcp.Connect(piIp, CameraMovementPort);
				piCameraMovementPortNetworkStream = piCameraMovementPortTcp.GetStream();
				piCameraMovementPortSrReciever = new StreamReader(piCameraMovementPortNetworkStream);
				piCameraMovementPortSwSender = new StreamWriter(piCameraMovementPortNetworkStream);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "piCameraMovementPort Error");
			}
		}

		public static void CameraMovementUpdater(RoverCameraMovement cameraMovement, int CameraSpeed)
		{
			try
			{
				piCameraMovementPortSwSender.AutoFlush = true;
				piCameraMovementPortSwSender.Write(Convert.ToString(Convert.ToInt32(cameraMovement)) + "," + Convert.ToString(CameraSpeed));
			}
			catch (Exception ex)
			{
				CameraMovementPortEnabler();
			}
		}

		private static void HandMovementPortEnabler()
		{
			try
			{
				piHandMovementPortTcp = new TcpClient();
				piHandMovementPortTcp.Connect(piIp, HandMovementPort);
				piHandMovementPortNetworkStream = piHandMovementPortTcp.GetStream();
				piHandMovementPortSrReciever = new StreamReader(piHandMovementPortNetworkStream);
				piHandMovementPortSwSender = new StreamWriter(piHandMovementPortNetworkStream);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "piHandMovementPort Error");
			}
		}

		public static void HandMovementUpdater(HandMovement handMovement, int handSpeed)
		{
			try
			{
				piHandMovementPortSwSender.AutoFlush = true;
				piHandMovementPortSwSender.Write(Convert.ToString(Convert.ToInt32(handMovement)) + "," + Convert.ToString(handSpeed));
			}
			catch (Exception ex)
			{
				HandMovementPortEnabler();
			}
		}
		public static bool imuConnectionEnabler()
		{
			try
			{
				piImuPortTcp = new TcpClient();
				piImuPortTcp.Connect(piIp, imuPort);
				piImuPortNetworkStream = piImuPortTcp.GetStream();
				piImuPortSrReciever = new StreamReader(piImuPortNetworkStream);
				piImuPortSwSender = new StreamWriter(piImuPortNetworkStream);
				Thread imuDataHandlerThread = new Thread(() => imuInputHandler());
				imuDataHandlerThread.Name = "imuDataHandlerThread";
				imuDataHandlerThread.IsBackground = true;
				imuDataHandlerThread.Start();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "piImuPort Error");
			}
			return false;
		}

		private static void imuInputHandler()
		{
			try
			{
				piImuPortSwSender.AutoFlush = true;
				while (true)
				{
					imuData = piImuPortSrReciever.ReadLine();
				}
			}
			catch (Exception ex)
			{
			}
		}

		internal static string getImuData()
		{
			if (imuData == null)
			{
				imuData = "0,0,0,0,0,0";
			}
			return imuData;
		}

		private static void MasterPortEnabler()
		{
			try
			{
				piMasterPortTcp = new TcpClient();
				piMasterPortTcp.Connect(piIp, masterPort);
				piMasterPortNetworkStream = piMasterPortTcp.GetStream();
				piMasterPortSrReciever = new StreamReader(piMasterPortNetworkStream);
				piMasterPortSwSender = new StreamWriter(piMasterPortNetworkStream);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "piMasterPort Error");
			}
		}

		public static void MasterUpdater(MovementObject movementObject, RoverAndArmRoverMovement roverMovement, RoverCameraMovement cameraMovement, HandMovement handMovement, double RoverPwm, int CameraSpeed, int handSpeed)
		{
			try
			{
				piMasterPortSwSender.AutoFlush = true;
				piMasterPortSwSender.Write(Convert.ToString(Convert.ToInt32(movementObject)) + "," + Convert.ToString(Convert.ToInt32(roverMovement)) + "," + Convert.ToString(Convert.ToInt32(cameraMovement)) + "," + Convert.ToString(Convert.ToInt32(handMovement)) + "," + Convert.ToString(RoverPwm) + "," + Convert.ToString(CameraSpeed) + "," + Convert.ToString(handSpeed));
			}
			catch (Exception ex)
			{
				MasterPortEnabler();
			}
		}
	}
	public enum RoverAndArmRoverMovement
	{
		Forward, Backward, LeftTurn, RightTurn, Stop
	}
	public enum RoverCameraMovement
	{
		UpTurn, DownTurn, LeftTurn, RightTurn, Stop
	}

	public enum HandMovement
	{
		FirstDegreeLeft, FirstDegreeRight, SecondDegreeUp, SecondDegreeDown, ThirdDegreeUp, ThirdDegreeDown, FourthDegreeUp, FourthDegreeDown, FifthDegreeLeft, FifthDegreeRight, ClawOn, ClawOff, Stop
	}
	public enum MovementObject
	{
		Movement, Camera, Arm
	}
}
