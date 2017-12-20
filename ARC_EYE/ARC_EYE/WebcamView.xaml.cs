using MjpegProcessor;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ARC_EYE
{
	/// <summary>
	/// Interaction logic for WebcamView.xaml
	/// </summary>
	public partial class WebcamView : UserControl
	{
		public static WebcamView _WebcamView = null;
		readonly MjpegDecoder webcam1Decoder;
		readonly MjpegDecoder webcam2Decoder;
		public static WebcamView WebcamViewHandler()
		{
			if (_WebcamView == null)
			{
				_WebcamView = new WebcamView();
			}
			return _WebcamView;
		}
		private WebcamView()
		{
			InitializeComponent();
			webcam1Decoder = new MjpegDecoder();
			webcam2Decoder = new MjpegDecoder();
			webcam1Decoder.FrameReady += Webcam1Decoder_FrameReady;
			webcam2Decoder.FrameReady += Webcam2Decoder_FrameReady;
			webcam1Decoder.Error += Webcam1Decoder_Error;
			webcam2Decoder.Error += Webcam2Decoder_Error;
		}

		private void Webcam2Decoder_Error(object sender, ErrorEventArgs e)
		{
			RoverConsole.ArcEyeAiContentThreadSafe(e.ToString());
		}

		private void Webcam1Decoder_Error(object sender, ErrorEventArgs e)
		{
			RoverConsole.ArcEyeAiContentThreadSafe(e.ToString());
		}

		private void Webcam2Decoder_FrameReady(object sender, FrameReadyEventArgs e)
		{
			_WebcamView.webcam_view_2.Source = e.BitmapImage;
		}

		private void Webcam1Decoder_FrameReady(object sender, FrameReadyEventArgs e)
		{
			_WebcamView.webcam_view_1.Source = e.BitmapImage;
		}

		private void webcam_viw_1_strt_btn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				_WebcamView.webcam_viw_1_txt.Content = "";
				_WebcamView.webcam_viw_1_txt.Visibility = Visibility.Hidden;
				_WebcamView.webcam_view_1.Visibility = Visibility.Visible;
				//webcam1Decoder.ParseStream(new Uri("http://" + SettingsModule.getWebCam1Ip() + ":" + SettingsModule.getWebcam1Port()));
				webcam1Decoder.ParseStream(new Uri("http://192.168.1.150:8081"));
				RoverConsole.ArcEyeContentThreadSafe("Web Cam View 1 Streaming Has Started");
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
			}
		}

		private void webcam_viw_1_stp_btn_Click(object sender, RoutedEventArgs e)
		{
			_WebcamView.webcam_viw_1_txt.Content = "Streaming stopped...!!!";
			_WebcamView.webcam_viw_1_txt.Visibility = Visibility.Visible;
			webcam1Decoder.StopStream();
			webcam_view_1.Visibility = Visibility.Hidden;
			RoverConsole.ArcEyeContent("Web Cam View 1 Streaming Has Stopped");
		}

		private void webcam_viw_1_strt_rcd_btn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void webcam_viw_1_stp_rcd_btn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void webcam_viw_2_strt_btn_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				_WebcamView.webcam_viw_2_txt.Content = "";
				_WebcamView.webcam_viw_2_txt.Visibility = Visibility.Hidden;
				_WebcamView.webcam_view_2.Visibility = Visibility.Visible;
				//webcam2Decoder.ParseStream(new Uri("http://" + SettingsModule.getWebCam2Ip() + ":" + SettingsModule.getWebcam2Port()));
				webcam2Decoder.ParseStream(new Uri("http://192.168.1.150:8081"));
				RoverConsole.ArcEyeContentThreadSafe("Web Cam View 2 Streaming Has Started");
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
			}
		}

		private void webcam_viw_2_stp_btn_Click(object sender, RoutedEventArgs e)
		{
			_WebcamView.webcam_viw_2_txt.Content = "Streaming stopped...!!!";
			_WebcamView.webcam_viw_2_txt.Visibility = Visibility.Visible;
			webcam1Decoder.StopStream();
			webcam_view_2.Visibility = Visibility.Hidden;
			RoverConsole.ArcEyeContent("Web Cam View 2 Streaming Has Stopped");
		}

		private void webcam_viw_2_strt_rcd_btn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void webcam_viw_2_stp_rcd_btn_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
