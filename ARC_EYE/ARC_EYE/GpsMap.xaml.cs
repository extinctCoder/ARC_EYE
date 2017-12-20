using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ARC_EYE
{
    /// <summary>
    /// Interaction logic for GpsMap.xaml
    /// </summary>
    public partial class GpsMap : UserControl
    {
        public static PointLatLng startingPosition;
        public static PointLatLng endingPosition;
        public static GMapMarker currentMarker;
        public static GpsMap _GpsMap = null;
        public static GpsMap GpsMapHandler()
        {
            if (_GpsMap == null)
            {
                _GpsMap = new GpsMap();
            }
            return _GpsMap;
        }
        private GpsMap()
        {
            InitializeComponent();
            if (!PingNetwork("pingtest.com"))
            {
                map_viw.Manager.Mode = AccessMode.CacheOnly;
                RoverConsole.ArcEyeAiContentThreadSafe("No Internet connection available, going to CacheOnly mode");
            }
            else
            {
                RoverConsole.ArcEyeAiContentThreadSafe("Internet connection available, going to normal mode");
            }
            map_viw.MapProvider = GMapProviders.OpenStreetMap;
            map_viw.Position = new PointLatLng(23.8103, 90.4125);
            map_viw.Zoom = 10;

            map_type_combo_bx.ItemsSource = GMapProviders.List;
            map_type_combo_bx.SelectedItem = map_viw.MapProvider;

            map_mode_combo_bx.ItemsSource = Enum.GetValues(typeof(AccessMode));
            map_mode_combo_bx.SelectedItem = map_viw.Manager.Mode;

            routing_CK_bx.IsChecked = map_viw.Manager.UseRouteCache;
            geo_coding_ck_bx.IsChecked = map_viw.Manager.UseGeocoderCache;

            latitude_txt.Text = map_viw.Position.Lat.ToString(CultureInfo.InvariantCulture);
            longitude_txt.Text = map_viw.Position.Lng.ToString(CultureInfo.InvariantCulture);

            current_marker_cheack_bx.IsChecked = true;
            drag_map_cheack_bx.IsChecked = map_viw.CanDragMap;
            grid_cheack_bx.IsChecked = true;

            GpsMap.currentMarker = new GMapMarker(map_viw.Position);
            {
                GpsMap.currentMarker.Shape = new Rectangle
                {
                    Width = 10,
                    Height = 10,
                    Stroke = Brushes.Red,
                    StrokeThickness = 1.5
                };
            }
        }

        private void zom_slidr_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            map_viw.Zoom = ((int)zom_slidr.Value);
            RoverConsole.ArcEyeContentThreadSafe("Map Zoomed In : " + zom_slidr.Value.ToString() + "x");
        }

        private void go_to_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double latitude = double.Parse(latitude_txt.Text, CultureInfo.InvariantCulture);
                double longitude = double.Parse(longitude_txt.Text, CultureInfo.InvariantCulture);
                map_viw.Position = new PointLatLng(latitude, longitude);
                RoverConsole.ArcEyeContentThreadSafe("Map Initialized In : " + latitude.ToString() + ", " + longitude.ToString());
            }
            catch (Exception ex)
            {
                RoverConsole.ArcEyeAiContentThreadSafe("Incorrect Coordinate Format: " + ex.Message);
            }
        }

        private void reload_btn_Click(object sender, RoutedEventArgs e)
        {
            map_viw.ReloadMap();
            RoverConsole.ArcEyeAiContentThreadSafe("Map Re-Initialized");
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoverConsole.ArcEyeAiContentThreadSafe("Trying To Save Map Snapshot In Desktop Folder");
                ImageSource imageSource = map_viw.ToImageSource();
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(imageSource as BitmapSource));

                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.FileName = "MAP " + DateTime.Today.ToString();
                saveFileDialog.DefaultExt = ".png"; // Default file extension
                saveFileDialog.Filter = "Image (.png)|*.png"; // Filter files by extension
                saveFileDialog.AddExtension = true;
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                bool? result = saveFileDialog.ShowDialog();
                if (result == true)
                {
                    string filename = saveFileDialog.FileName;
                    using (System.IO.Stream stream = System.IO.File.OpenWrite(filename))
                    {
                        pngBitmapEncoder.Save(stream);
                    }
                }
                RoverConsole.ArcEyeAiContentThreadSafe("Successfully Done Save Map Snapshot In Desktop Folder Process");
            }
            catch (Exception ex)
            {
                RoverConsole.ArcEyeAiContentThreadSafe(ex.Message);
            }
        }

        private void add_marker_btn_Click(object sender, RoutedEventArgs e)
        {
            GMapMarker gMapMarker = new GMapMarker(currentMarker.Position);
            {

                string toolTipText;
                Placemark? placemark = null;
                if (place_info_btn.IsChecked.Value)
                {
                    GeoCoderStatusCode status;
                    var plret = GMapProviders.GoogleMap.GetPlacemark(currentMarker.Position, out status);
                    if (status == GeoCoderStatusCode.G_GEO_SUCCESS && plret != null)
                    {
                        placemark = plret;
                    }
                }
                if (placemark != null)
                {
                    toolTipText = placemark.Value.Address;
                }
                else
                {
                    toolTipText = currentMarker.Position.ToString();
                }
                gMapMarker.Shape = new Rectangle
                {
                    Width = 10,
                    Height = 10,
                    Stroke = Brushes.Green,
                    StrokeThickness = 1.5
                };
                gMapMarker.ZIndex = 55;
            }
            map_viw.Markers.Add(gMapMarker);
            RoverConsole.ArcEyeAiContentThreadSafe("New Marker Added to the map in : " + gMapMarker.Position.ToString());
        }

        private void clear_all_btn_Click(object sender, RoutedEventArgs e)
        {
            var clearMarker = map_viw.Markers.Where(tempMarker => tempMarker != null && tempMarker != currentMarker);
            if (clearMarker != null)
            {
                for (int i = 0; i < clearMarker.Count(); i++)
                {
                    map_viw.Markers.Remove(clearMarker.ElementAt(i));
                    i--;
                }
            }
            RoverConsole.ArcEyeAiContentThreadSafe("All Temporary Markers Has Cleared");
        }

        private void zoom_center_btn_Click(object sender, RoutedEventArgs e)
        {
            map_viw.ZoomAndCenterMarkers(null);
            map_viw.Zoom = 15;
            RoverConsole.ArcEyeAiContentThreadSafe("Map Zoomed In Center Position");
        }

        private void set_start_btn_Click(object sender, RoutedEventArgs e)
        {
            startingPosition = currentMarker.Position;
            RoverConsole.ArcEyeAiContentThreadSafe("Stat Position For Routing Is Set In : " + startingPosition.Lat.ToString() + ", " + startingPosition.Lng.ToString());
        }

        private void set_stop_btn_Click(object sender, RoutedEventArgs e)
        {
            endingPosition = currentMarker.Position;
            RoverConsole.ArcEyeAiContentThreadSafe("End Position For Routing Is Set In : " + endingPosition.Lat.ToString() + ", " + endingPosition.Lng.ToString());
        }

        private void add_route_btn_Click(object sender, RoutedEventArgs e)
        {
            RoverConsole.ArcEyeAiContentThreadSafe("Trying To Find The Route Between Start Point And End Point");
            RoutingProvider routingProvider = map_viw.MapProvider as RoutingProvider;
            if (routingProvider == null)
            {
                routingProvider = GMapProviders.OpenStreetMap;
            }
            MapRoute mapRoute = routingProvider.GetRoute(startingPosition, endingPosition, false, false, (int)map_viw.Zoom);
            if (mapRoute != null)
            {
                GMapMarker tempStartingPosition = new GMapMarker(startingPosition);
                tempStartingPosition.Shape = new Rectangle
                {
                    Width = 10,
                    Height = 10,
                    Stroke = Brushes.Blue,
                    StrokeThickness = 1.5
                };

                GMapMarker tempEndingPosition = new GMapMarker(endingPosition);
                tempEndingPosition.Shape = new Rectangle
                {
                    Width = 10,
                    Height = 10,
                    Stroke = Brushes.Blue,
                    StrokeThickness = 1.5
                };

                GMapRoute gMapRoute = new GMapRoute(mapRoute.Points);
                {
                    gMapRoute.ZIndex = -1;
                }

                map_viw.Markers.Add(tempStartingPosition);
                map_viw.Markers.Add(tempEndingPosition);
                map_viw.Markers.Add(gMapRoute);
                map_viw.ZoomAndCenterMarkers(null);
            }
            RoverConsole.ArcEyeAiContentThreadSafe("Route Between Start Point And End Point Is Initialized In The Map");
        }

        private void export_btn_Click(object sender, RoutedEventArgs e)
        {
            RoverConsole.ArcEyeAiContentThreadSafe("Saving The Map Cache In Local Storage");
            map_viw.ShowExportDialog();
        }

        private void clear_all_cache_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Clear The Map Cache?\nNo Data Will Be Saved In Local Storage", "Map Cache Clear Warning", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                try
                {
                    map_viw.Manager.PrimaryCache.DeleteOlderThan(DateTime.Now, null);
                    RoverConsole.ArcEyeAiContentThreadSafe("Successfully Cleared The Map Cache");
                }
                catch (Exception ex)
                {
                    RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
                }
            }
        }

        private void prefetch_btn_Click(object sender, RoutedEventArgs e)
        {
            RectLatLng rectLatLng = map_viw.SelectedArea;
            if (!rectLatLng.IsEmpty)
            {
                for (int i = (int)map_viw.Zoom; i <= map_viw.MaxZoom; i++)
                {
                    MessageBoxResult messageBoxResult = MessageBox.Show("Ready Prefetch The Map At Zoom = " + i + " ?", "Prefetch", MessageBoxButton.YesNoCancel);

                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        TilePrefetcher tilePrefetcher = new TilePrefetcher();
                        tilePrefetcher.ShowCompleteMessage = true;
                        tilePrefetcher.Start(rectLatLng, i, map_viw.MapProvider, 100);
                    }
                    else if (messageBoxResult == MessageBoxResult.No)
                    {
                        continue;
                    }
                    else if (messageBoxResult == MessageBoxResult.Cancel)
                    {
                        break;
                    }
                }
            }
            else
            {
                RoverConsole.ArcEyeAiContentThreadSafe("Select The Map Area Holding ALT");
            }
        }

        private void import_btn_Click(object sender, RoutedEventArgs e)
        {
            RoverConsole.ArcEyeAiContentThreadSafe("Importing The Map Cache From The Local Storage");
            map_viw.ShowImportDialog();
        }

        private void current_marker_cheack_bx_Checked(object sender, RoutedEventArgs e)
        {
            if (currentMarker != null)
            {
                map_viw.Markers.Add(currentMarker);
                RoverConsole.ArcEyeAiContentThreadSafe("Current Marker Initialized");
            }
        }

        private void current_marker_cheack_bx_Unchecked(object sender, RoutedEventArgs e)
        {
            if (currentMarker != null)
            {
                map_viw.Markers.Remove(currentMarker);
                RoverConsole.ArcEyeAiContentThreadSafe("Current Marker De Initialized");
            }
        }

        private void grid_cheack_bx_Checked(object sender, RoutedEventArgs e)
        {
            map_viw.ShowTileGridLines = true;
            RoverConsole.ArcEyeAiContentThreadSafe("Grid System Initialized");
        }

        private void grid_cheack_bx_Unchecked(object sender, RoutedEventArgs e)
        {
            map_viw.ShowTileGridLines = false;
            RoverConsole.ArcEyeAiContentThreadSafe("Grid System De Initialized");
        }

        private void drag_map_cheack_bx_Checked(object sender, RoutedEventArgs e)
        {
            map_viw.CanDragMap = true;
            RoverConsole.ArcEyeAiContentThreadSafe("Drag Map Ability Initialized");
        }

        private void drag_map_cheack_bx_Unchecked(object sender, RoutedEventArgs e)
        {
            map_viw.CanDragMap = false;
            RoverConsole.ArcEyeAiContentThreadSafe("Drag Map Ability De Initialized");
        }

        private void map_viw_MouseEnter(object sender, MouseEventArgs e)
        {
            map_viw.Focus();
            RoverConsole.ArcEyeAiContentThreadSafe("Map Gets Focus");
        }

        private void map_viw_MouseMove(object sender, MouseEventArgs e)
        {
            if (_GpsMap.current_marker_cheack_bx.IsChecked == true && e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                _GpsMap.map_viw.Markers.Remove(currentMarker);
                System.Windows.Point p = e.GetPosition(map_viw);
                currentMarker.Position = map_viw.FromLocalToLatLng((int)p.X, (int)p.Y);
                _GpsMap.latitude_txt.Text = p.X.ToString();
                _GpsMap.longitude_txt.Text = p.Y.ToString();
                map_viw.Markers.Add(currentMarker);
                RoverConsole.ArcEyeAiContentThreadSafe("Current Position Of Marker Is : " + p.X.ToString() + ", " + p.Y.ToString());
            }
        }

        private void map_viw_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_GpsMap.current_marker_cheack_bx.IsChecked == true)
            {
                _GpsMap.map_viw.Markers.Remove(currentMarker);
                System.Windows.Point p = e.GetPosition(map_viw);
                currentMarker.Position = map_viw.FromLocalToLatLng((int)p.X, (int)p.Y);
                _GpsMap.latitude_txt.Text = p.X.ToString();
                _GpsMap.longitude_txt.Text = p.Y.ToString();
                map_viw.Markers.Add(currentMarker);
                RoverConsole.ArcEyeAiContentThreadSafe("Current Position Of Marker Is : " + p.X.ToString() + ", " + p.Y.ToString());
            }
        }

        private void map_viw_OnTileLoadStart()
        {
            //try
            //{
            //    if (_GpsMap != null)
            //    {
            //        loading_br.IsIndeterminate = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
            //}
        }

        private void map_viw_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            //try
            //{
            //    if (_GpsMap != null)
            //    {
            //        loading_br.IsIndeterminate = false;
            //        RoverConsole.ArcEyeAiContentThreadSafe("Map Load Completed In : " + ElapsedMilliseconds.ToString() + " Milliseconds");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
            //}
        }

        private void map_type_combo_bx_DropDownClosed(object sender, EventArgs e)
        {
            map_viw.MapProvider = (GMapProvider)map_type_combo_bx.SelectedItem;
            map_viw.ReloadMap();
        }

        private void map_mode_combo_bx_DropDownClosed(object sender, EventArgs e)
        {
            map_viw.Manager.Mode = (AccessMode)map_mode_combo_bx.SelectedItem;
            map_viw.ReloadMap();
        }
    }
}
