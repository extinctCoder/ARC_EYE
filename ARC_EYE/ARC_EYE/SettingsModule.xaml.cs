using System;
using System.Windows;
using System.Windows.Controls;

namespace ARC_EYE
{
	/// <summary>
	/// Interaction logic for SettingsModule.xaml
	/// </summary>
	public partial class SettingsModule : UserControl
	{
		public static SettingsModule _SettingsModule = null;
		public static SettingsModule SettingsModuleHandler()
		{
			if (_SettingsModule == null)
			{
				_SettingsModule = new SettingsModule();
			}
			return _SettingsModule;
		}
		public SettingsModule()
		{
			InitializeComponent();
			ConnectorOne.pi1Port1ConnectedStatusEvent += new EventHandler(pi1Port1ConnectedStatusEventHandler);
			ConnectorOne.pi1Port1DisconnectedStatusEvent += new EventHandler(pi1Port1DisconnectedStatusEvent);

			ConnectorOne.pi3Port1ConnectedStatusEvent += new EventHandler(pi3Port1ConnectedStatusEventHandler);
			ConnectorOne.pi3Port1DisconnectedStatusEvent += new EventHandler(pi3Port1DisconnectedStatusEvent);

			ConnectorOne.pi1Port2ConnectedStatusEvent += new EventHandler(pi1Port2ConnectedStatusEventHandler);
			ConnectorOne.pi1Port2DisconnectedStatusEvent += new EventHandler(pi1Port2DisconnectedStatusEvent);
		}


		private void pi_1_port_1_btn_Click(object sender, RoutedEventArgs e)
		{
			ConnectorOne.pi1Port1ConnectionEnabler();
		}

		private void pi_3_port_1_btn_Click(object sender, RoutedEventArgs e)
		{
			ConnectorOne.pi3Port1ConnectionEnabler();
		}

		private void pi_1_port_2_btn_Click(object sender, RoutedEventArgs e)
		{
			ConnectorOne.pi1Port2ConnectionEnabler();
		}
	}
}
