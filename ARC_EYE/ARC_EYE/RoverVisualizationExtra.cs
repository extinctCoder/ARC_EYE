using HelixToolkit.Wpf;
using System;
using System.Threading;
using System.Windows.Media.Media3D;


namespace ARC_EYE
{
	public partial class RoverVisualization
	{
		private void pi3Port1DisconnectedStatusEvent(object sender, EventArgs e)
		{
			_RoverVisualization.initialize_btn.Visibility = System.Windows.Visibility.Visible;
			_RoverVisualization.rvr_mdl_plc.Visibility = System.Windows.Visibility.Hidden;
			if (roverVisualizationSyncronizerThread != null)
			{
				roverVisualizationSyncronizerThread.Suspend();
			}
		}
		private void pi3Port1ConnectedStatusEventHandler(object sender, EventArgs e)
		{
			_RoverVisualization.initialize_btn.Visibility = System.Windows.Visibility.Hidden;
			_RoverVisualization.rvr_mdl_plc.Visibility = System.Windows.Visibility.Visible;
			if (roverVisualizationSyncronizerThread == null)
			{
				//HelixToolkit.Wpf.ObjReader CurrentHelixObjReader = new ObjReader();
				//Model3DGroup MyModel = CurrentHelixObjReader.Read(@"C:\Users\exCdr\OneDrive\UNIVERSITY_ROVER_CHALANGE\ARC_EYE\ARC_EYE\Assets\roverModel.obj");
				//rvr_mdl.Content = MyModel;
				roverVisualizationSyncronizerThread = new Thread(() => roverVisualizationSyncronizerThreadFunction());
				roverVisualizationSyncronizerThread.IsBackground = true;
				roverVisualizationSyncronizerThread.Name = "roverVisualizationSyncronizerThread";
				roverVisualizationSyncronizerThread.Start();
			}
			else
			{
				roverVisualizationSyncronizerThread.Resume();
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
					_RoverVisualization.rvr_mdl_plc.Dispatcher.Invoke((Action)(() =>
					{
						_RoverVisualization.rtn_x.Angle = Convert.ToDouble(words[0]);
						_RoverVisualization.rtn_y.Angle = Convert.ToDouble(words[1]);
						_RoverVisualization.rtn_z.Angle = Convert.ToDouble(words[2]);
						//_RoverVisualization.axs.OffsetX = Convert.ToDouble(words[3]);
						//_RoverVisualization.axs.OffsetX = Convert.ToDouble(words[4]);
						//_RoverVisualization.axs.OffsetX = Convert.ToDouble(words[5]);
					}));
				}
				catch (Exception ex)
				{
					ARC_EYE.RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
				}
			}
		}
	}
	class RoverVisualizationExtra
	{
	}
}
