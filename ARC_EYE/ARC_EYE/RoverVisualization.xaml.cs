using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ARC_EYE
{
	/// <summary>
	/// Interaction logic for RoverVisualization.xaml
	/// </summary>
	public partial class RoverVisualization : UserControl
	{
		Thread roverVisualizationSyncronizerThread = null;
		public static RoverVisualization _RoverVisualization = null;

		public static RoverVisualization RoverVisualizationHandler()
		{
			if (_RoverVisualization == null)
			{
				_RoverVisualization = new RoverVisualization();
			}
			return _RoverVisualization;
		}
		private RoverVisualization()
		{
			InitializeComponent();
			ConnectorOne.pi3Port1ConnectedStatusEvent += new EventHandler(pi3Port1ConnectedStatusEventHandler);
			ConnectorOne.pi3Port1DisconnectedStatusEvent += new EventHandler(pi3Port1DisconnectedStatusEvent);
		}

		private void initialize_btn_Click(object sender, RoutedEventArgs e)
		{
			_RoverVisualization.initialize_btn.Visibility = Visibility.Hidden;
			_RoverVisualization.rvr_mdl_plc.Visibility = Visibility.Visible;
			
			ConnectorOne.pi3Port1ConnectionEnabler();
		}
		
	}
}
