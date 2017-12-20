using MjpegProcessor;
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
    /// Interaction logic for WebCam_Module.xaml
    /// </summary>
    public partial class WebCam_Module : UserControl
    {
        readonly MjpegDecoder webcam1Decoder;
        readonly MjpegDecoder webcam2Decoder;
        public WebCam_Module()
        {
            InitializeComponent();
            webcam1Decoder = new MjpegDecoder();
            webcam2Decoder = new MjpegDecoder();
            webcam1Decoder.FrameReady += Webcam1Decoder_FrameReady;
            webcam2Decoder.FrameReady += Webcam2Decoder_FrameReady;
            webcam1Decoder.Error += Webcam1Decoder_Error;
            webcam2Decoder.Error += Webcam2Decoder_Error;
        }

        private void Webcam1Decoder_Error(object sender, ErrorEventArgs e)
        {
            
        }

        private void Webcam2Decoder_Error(object sender, ErrorEventArgs e)
        {
            
        }

        private void Webcam2Decoder_FrameReady(object sender, FrameReadyEventArgs e)
        {
            this.webcam_view_2.Source = e.BitmapImage;
        }

        private void Webcam1Decoder_FrameReady(object sender, FrameReadyEventArgs e)
        {
            this.webcam_view_1.Source = e.BitmapImage;
        }

        private void web_cam_1_start_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                webcam1Decoder.ParseStream(new Uri("http://192.168.0.223:8081"));
            }
            catch (Exception ex)
            {
            }
        }

        private void web_cam_1_stop_btn_Click(object sender, RoutedEventArgs e)
        {
            webcam1Decoder.StopStream();
        }

        private void web_cam_1_start_record_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void web_cam_1_stop_record_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void web_cam_2_start_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                webcam2Decoder.ParseStream(new Uri("http://192.168.0.223:8081"));
            }
            catch (Exception ex)
            {
            }
        }

        private void web_cam_2_stop_btn_Click(object sender, RoutedEventArgs e)
        {
            webcam2Decoder.StopStream();
        }

        private void web_cam_2_start_record_btn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void web_cam_2_stop_record_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
