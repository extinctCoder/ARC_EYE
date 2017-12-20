using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
	/// Interaction logic for MapModule.xaml
	/// </summary>
	public partial class MapModule : UserControl
	{
		public MapModule()
		{
			InitializeComponent();
			map_viw.MapProvider = GMapProviders.GoogleMap;
			map_viw.Position = new PointLatLng(23.8103, 90.4125);
			map_viw.Zoom = 10;
		}
	}
}
