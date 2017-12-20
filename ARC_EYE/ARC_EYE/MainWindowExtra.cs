using MahApps.Metro.Controls.Dialogs;
using System;

namespace ARC_EYE
{
	public partial class MainWindow
	{
		private void pi1Port1ConnectedStatusEventHandler(object sender, EventArgs e)
		{
			this.cnc_stings_dck.IsExpanded = false;
		}
		private async void pi1Port1DisconnectedStatusEventAsync(object sender, EventArgs e)
		{
			this.cnc_stings_dck.IsExpanded = true;
			await this.ShowMessageAsync("pi1Port1 Connection Error", "Please Check The Connection Settings in 'Connection Settings And Maintenance Dock' Or Check The Error In : RoverConsole");
		}
		private void pi1Port2ConnectedStatusEventHandler(object sender, EventArgs e)
		{
			this.cnc_stings_dck.IsExpanded = false;
		}
		private async void pi1Port2DisconnectedStatusEventAsync(object sender, EventArgs e)
		{
			this.cnc_stings_dck.IsExpanded = true;
			await this.ShowMessageAsync("pi1Port2 Connection Error", "Please Check The Connection Settings in 'Connection Settings And Maintenance Dock' Or Check The Error In : RoverConsole");
		}
		private void pi3Port1ConnectedStatusEventHandler(object sender, EventArgs e)
		{
			this.cnc_stings_dck.IsExpanded = false;
		}

		private async void pi3Port1DisconnectedStatusEventAsync(object sender, EventArgs e)
		{
			this.cnc_stings_dck.IsExpanded = true;
			await this.ShowMessageAsync("pi3Port1 Connection Error", "Please Check The Connection Settings in 'Connection Settings And Maintenance Dock' Or Check The Error In : RoverConsole");
		}

	}
	class MainWindowExtra
	{
	}
}
