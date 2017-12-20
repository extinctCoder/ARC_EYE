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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Control_Panel
{
	/// <summary>
	/// Interaction logic for ImuModule.xaml
	/// </summary>
	public partial class ImuModule : UserControl
	{
		private Thread roverVisualizationSyncronizerThread;

		public ImuModule()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (ConnectorOne.imuConnectionEnabler())
			{
				this.imuEnabler();
			}
		}
		private void imuEnabler()
		{
			
			if (roverVisualizationSyncronizerThread == null)
			{
				roverVisualizationSyncronizerThread = new Thread(() => roverVisualizationSyncronizerThreadFunction());
				roverVisualizationSyncronizerThread.IsBackground = true;
				roverVisualizationSyncronizerThread.Name = "roverVisualizationSyncronizerThread";
				roverVisualizationSyncronizerThread.Start();
			}
			else
			{
			}
		}

		private void roverVisualizationSyncronizerThreadFunction()
		{
			string datas;
			while (true)
			{
				datas = ConnectorOne.getImuData();
				try
				{
					string[] words = datas.Split(',');
					this.rvr_mdl_ht.Dispatcher.Invoke((Action)(() =>
					{
						this.rtn_x.Angle = Convert.ToDouble(words[0]);
						this.rtn_y.Angle = Convert.ToDouble(words[1]);
						this.rtn_z.Angle = Convert.ToDouble(words[2]);
					}));
				}
				catch (Exception ex)
				{
					
				}
			}
		}
	}
}
