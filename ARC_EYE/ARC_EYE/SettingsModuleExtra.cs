using System;
using System.Windows.Media;

namespace ARC_EYE
{
	public partial class SettingsModule
	{
		public static String getPi1Ip()
		{
			return _SettingsModule.pi_1_ip.Text;
		}

		public static String getPi1Port1()
		{
			return _SettingsModule.pi_1_port_1.Text;
		}
		public static String getPi1Port2()
		{
			return _SettingsModule.pi_1_port_2.Text;
		}
		public static String getPi2Ip()
		{
			return _SettingsModule.pi_2_ip.Text;
		}

		public static String getPi2Port1()
		{
			return _SettingsModule.pi_2_port_1.Text;
		}
		public static String getPi2Port2()
		{
			return _SettingsModule.pi_2_port_2.Text;
		}
		public static String getPi3Ip()
		{
			return _SettingsModule.pi_3_ip.Text;
		}

		public static String getPi3Port1()
		{
			return _SettingsModule.pi_3_port_1.Text;
		}
		public static String getPi3Port2()
		{
			return _SettingsModule.pi_3_port_2.Text;
		}
		public static string getWebCam1Ip()
		{
			return _SettingsModule.webcam_1_ip.Text;
		}
		public static string getWebcam1Port()
		{
			return _SettingsModule.webcam_1_port.Text;
		}
		public static string getWebCam2Ip()
		{
			return _SettingsModule.webcam_2_ip.Text;
		}
		public static string getWebcam2Port()
		{
			return _SettingsModule.webcam_2_port.Text;
		}
	}
	public partial class SettingsModule
	{
		private void pi1Port1ConnectedStatusEventHandler(object sender, EventArgs e)
		{
			_SettingsModule.wcam1_plc.IsEnabled = true;
			_SettingsModule.pi2_plc.IsEnabled = true;
			_SettingsModule.wcam2_plc.IsEnabled = true;
			_SettingsModule.pi3_plc.IsEnabled = true;
			_SettingsModule.pi_1_port_2.IsEnabled = true;
			_SettingsModule.pi_1_port_2_btn.IsEnabled = true;
			_SettingsModule.pi_1_port_1_btn.IsEnabled = false;
			_SettingsModule.pi_1_ip.IsEnabled = false;
			_SettingsModule.pi_1_port_1.IsEnabled = false;
			_SettingsModule.pi_1_port_1_btn.Background = Brushes.Green;
			_SettingsModule.pi_1_port_1_btn.Content = "Connected";
		}

		private void pi1Port1DisconnectedStatusEvent(object sender, EventArgs e)
		{
			_SettingsModule.wcam1_plc.IsEnabled = false;
			_SettingsModule.pi2_plc.IsEnabled = false;
			_SettingsModule.wcam2_plc.IsEnabled = false;
			_SettingsModule.pi3_plc.IsEnabled = false;
			_SettingsModule.pi_1_port_2.IsEnabled = false;
			_SettingsModule.pi_1_port_2_btn.IsEnabled = false;
			_SettingsModule.pi_1_port_1_btn.IsEnabled = true;
			_SettingsModule.pi_1_ip.IsEnabled = true;
			_SettingsModule.pi_1_port_1.IsEnabled = true;
			_SettingsModule.pi_1_port_1_btn.Background = Brushes.Red;
			_SettingsModule.pi_1_port_1_btn.Content = "Disconnected";
		}

		private void pi3Port1ConnectedStatusEventHandler(object sender, EventArgs e)
		{

			_SettingsModule.wcam1_plc.IsEnabled = true;
			_SettingsModule.pi2_plc.IsEnabled = true;
			_SettingsModule.wcam2_plc.IsEnabled = true;
			_SettingsModule.pi1_plc.IsEnabled = true;
			_SettingsModule.pi_3_port_2.IsEnabled = true;
			_SettingsModule.pi_3_port_2_btn.IsEnabled = true;
			_SettingsModule.pi_3_port_1_btn.IsEnabled = false;
			_SettingsModule.pi_3_ip.IsEnabled = false;
			_SettingsModule.pi_3_port_1.IsEnabled = false;
			_SettingsModule.pi_3_port_1_btn.Background = Brushes.Green;
			_SettingsModule.pi_3_port_1_btn.Content = "Connected";
		}
		private void pi3Port1DisconnectedStatusEvent(object sender, EventArgs e)
		{

			_SettingsModule.wcam1_plc.IsEnabled = false;
			_SettingsModule.pi2_plc.IsEnabled = false;
			_SettingsModule.wcam2_plc.IsEnabled = false;
			_SettingsModule.pi1_plc.IsEnabled = false;
			_SettingsModule.pi_3_port_2.IsEnabled = false;
			_SettingsModule.pi_3_port_2_btn.IsEnabled = false;
			_SettingsModule.pi_3_port_1_btn.IsEnabled = true;
			_SettingsModule.pi_3_ip.IsEnabled = true;
			_SettingsModule.pi_3_port_1.IsEnabled = true;
			_SettingsModule.pi_3_port_1_btn.Background = Brushes.Red;
			_SettingsModule.pi_3_port_1_btn.Content = "Disconnected";
		}
		private void pi1Port2ConnectedStatusEventHandler(object sender, EventArgs e)
		{
			_SettingsModule.wcam1_plc.IsEnabled = true;
			_SettingsModule.pi2_plc.IsEnabled = true;
			_SettingsModule.wcam2_plc.IsEnabled = true;
			_SettingsModule.pi3_plc.IsEnabled = true;
			_SettingsModule.pi_1_port_1.IsEnabled = true;
			_SettingsModule.pi_1_port_1_btn.IsEnabled = true;
			_SettingsModule.pi_1_port_2_btn.IsEnabled = false;
			_SettingsModule.pi_1_ip.IsEnabled = false;
			_SettingsModule.pi_1_port_2.IsEnabled = false;
			_SettingsModule.pi_1_port_2_btn.Background = Brushes.Green;
			_SettingsModule.pi_1_port_2_btn.Content = "Connected";
		}

		private void pi1Port2DisconnectedStatusEvent(object sender, EventArgs e)
		{
			_SettingsModule.wcam1_plc.IsEnabled = false;
			_SettingsModule.pi2_plc.IsEnabled = false;
			_SettingsModule.wcam2_plc.IsEnabled = false;
			_SettingsModule.pi3_plc.IsEnabled = false;
			_SettingsModule.pi_1_port_1.IsEnabled = false;
			_SettingsModule.pi_1_port_1_btn.IsEnabled = false;
			_SettingsModule.pi_1_port_2_btn.IsEnabled = true;
			_SettingsModule.pi_1_ip.IsEnabled = true;
			_SettingsModule.pi_1_port_2.IsEnabled = true;
			_SettingsModule.pi_1_port_2_btn.Background = Brushes.Red;
			_SettingsModule.pi_1_port_2_btn.Content = "Disconnected";
		}
	}
	class SettingsModuleExtra
	{
	}
}
