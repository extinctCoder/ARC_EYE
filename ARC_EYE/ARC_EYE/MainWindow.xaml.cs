using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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

namespace ARC_EYE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.userAuthenticationVarificationHundler(new object(), new EventArgs());
            ConnectorOne.pi1Port1ConnectedStatusEvent += new EventHandler(pi1Port1ConnectedStatusEventHandler);
            ConnectorOne.pi1Port1DisconnectedStatusEvent += new EventHandler(pi1Port1DisconnectedStatusEventAsync);


			ConnectorOne.pi1Port2ConnectedStatusEvent += new EventHandler(pi1Port2ConnectedStatusEventHandler);
			ConnectorOne.pi1Port2DisconnectedStatusEvent += new EventHandler(pi1Port2DisconnectedStatusEventAsync);


			ConnectorOne.pi3Port1ConnectedStatusEvent += new EventHandler(pi3Port1ConnectedStatusEventHandler);
            ConnectorOne.pi3Port1DisconnectedStatusEvent += new EventHandler(pi3Port1DisconnectedStatusEventAsync);
            //this.min_container.Visibility = Visibility.Hidden;
            //this.ua_container.Visibility = Visibility.Visible;
            //LoginAuthentication _LoginAuthentication = new LoginAuthentication();
            //this.lgin_auth_plc.Children.Add(_LoginAuthentication);
            //_LoginAuthentication.loginVarificationCmnd += new EventHandler(userAuthenticationVarificationHundler);
        }

       

        public void ModuleInitializer()
        {
            Thread RoverConsoleThread = new Thread(ThreadedRoverConsoleInitializerFunction);
            Thread PuttyModuleThread = new Thread(PuttyModuleThreadFunction);
            Thread SettingsModuleThread = new Thread(ThreadedSettingsModuleInitializerFunction);
            Thread RoverMovementThread = new Thread(ThreadedRoverMovementInitializerFunction);
            Thread WebcamViewThread = new Thread(ThreadedWebcamViewInitializerFunction);
            Thread RoverVisualizationThread = new Thread(ThreadedRoverVisualizationInitializerFunction);
            Thread ArmVisualizationThread = new Thread(ThreadedArmVisualizationInitializerFunction);
            Thread RoverFeedbackThread = new Thread(ThreadedRoverFeedbackInitializerFunction);
            Thread RoverSensorThread = new Thread(ThreadedRoverSensorInitializerFunction);
            Thread GpsMapThread = new Thread(ThreadedGpsMapInitializerFunction);

            RoverConsoleThread.IsBackground = true;
            PuttyModuleThread.IsBackground = true;
            SettingsModuleThread.IsBackground = true;
            RoverMovementThread.IsBackground = true;
            WebcamViewThread.IsBackground = true;
            RoverVisualizationThread.IsBackground = true;
            ArmVisualizationThread.IsBackground = true;
            RoverFeedbackThread.IsBackground = true;
            RoverSensorThread.IsBackground = true;
            GpsMapThread.IsBackground = true;

            RoverConsoleThread.Start();
            PuttyModuleThread.Start();
            SettingsModuleThread.Start();
            RoverMovementThread.Start();
            WebcamViewThread.Start();
            RoverVisualizationThread.Start();
            ArmVisualizationThread.Start();
            RoverFeedbackThread.Start();
            RoverSensorThread.Start();
            GpsMapThread.Start();

            //this.arm_visulization_plc.Children.Add(RoverConsole.RoverConsoleHandler());
            //this.cnc_stings_plc.Children.Add(SettingsModule.SettingsModuleHandler());
            //this.rvr_movment_plc.Children.Add(RoverMovement.RoverMovementHandler());
            //this.webcam_viw_plc.Children.Add(WebcamView.WebcamViewHandler());;
            //this.rvr_visulization_plc.Children.Add(RoverVisualization.RoverVisualizationHandler());
            //this.cncl_plc.Children.Add(ArmVisualization.ArmVisualizationHandler());
            //this.rvr_fedbk_plc.Children.Add(RoverFeedback.RoverFeedbackHandler());
            //this.rvr_sncr_plc.Children.Add(RoverSensor.RoverSensorHandler());
            //this.gps_mp_plc.Children.Add(GpsMap.GpsMapHandler());
        }

        private void ThreadedRoverConsoleInitializerFunction()
        {
            this.cncl_plc.Dispatcher.Invoke((Action)(() =>
            {
                this.cncl_plc.Children.Add(RoverConsole.RoverConsoleHandler());
            }));
        }

        private void PuttyModuleThreadFunction()
        {
            this.putty_plc.Dispatcher.Invoke((Action)(() =>
            {
                this.putty_plc.Children.Add(PuttyModule.PuttyModuleHandler());
            }));
            //this.putty_plc.Dispatcher.Invoke((Action)(() =>
            //{
            //    this.putty_plc.Children.Add(RoverConsole.RoverConsoleHandler());
            //}));
        }

        private void ThreadedRoverMovementInitializerFunction()
        {
            this.rvr_movment_plc.Dispatcher.Invoke((Action)(() =>
            {
                this.rvr_movment_plc.Children.Add(RoverMovement.RoverMovementHandler());
            }));
        }

        private void ThreadedWebcamViewInitializerFunction()
        {
            this.webcam_viw_plc.Dispatcher.Invoke((Action)(() =>
            {
                this.webcam_viw_plc.Children.Add(WebcamView.WebcamViewHandler());
            }));
        }

        private void ThreadedRoverVisualizationInitializerFunction()
        {
            this.rvr_visulization_plc.Dispatcher.Invoke((Action)(() =>
            {
                this.rvr_visulization_plc.Children.Add(RoverVisualization.RoverVisualizationHandler());
            }));
        }

        private void ThreadedArmVisualizationInitializerFunction()
        {
            this.arm_visulization_plc.Dispatcher.Invoke((Action)(() =>
            {
                this.arm_visulization_plc.Children.Add(ArmVisualization.ArmVisualizationHandler());
            }));
        }

        private void ThreadedRoverFeedbackInitializerFunction()
        {
            this.rvr_fedbk_plc.Dispatcher.Invoke((Action)(() =>
            {
                this.rvr_fedbk_plc.Children.Add(RoverFeedback.RoverFeedbackHandler());
            }));
        }

        private void ThreadedRoverSensorInitializerFunction()
        {
            this.rvr_sncr_plc.Dispatcher.Invoke((Action)(() =>
            {
                this.rvr_sncr_plc.Children.Add(RoverSensor.RoverSensorHandler());
            }));
        }

        private void ThreadedGpsMapInitializerFunction()
        {
            this.gps_mp_plc.Dispatcher.Invoke((Action)(() =>
            {
                this.gps_mp_plc.Children.Add(GpsMap.GpsMapHandler());
            }
            ));
        }

        private void ThreadedSettingsModuleInitializerFunction()
        {
            this.cnc_stings_plc.Dispatcher.Invoke((Action)(() =>
            {
                this.cnc_stings_plc.Children.Add(SettingsModule.SettingsModuleHandler());
            }
            ));
        }

        private void userAuthenticationVarificationHundler(object sender, EventArgs e)
        {
            this.ua_container.Visibility = Visibility.Hidden;
            this.min_container.Visibility = Visibility.Visible;
            this.ModuleInitializer();
        }

        private void putty_plc_MouseEnter(object sender, MouseEventArgs e)
        {
            this.putty_plc_expndr.IsExpanded = true;
        }

        private void putty_plc_MouseLeave(object sender, MouseEventArgs e)
        {
            this.putty_plc_expndr.IsExpanded = false;
        }

        private async void abt_arc_eye_btn_Click(object sender, RoutedEventArgs e)
        {
            await this.ShowMessageAsync("AIUB Robotic Crew - 2017", "Together we bring machines into Life ... :P");
        }

    }
    public partial class MainWindow
    {
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (RoverMovement.RoverMovementHandler() != null)
            {
                RoverMovement.KeyboardInputHandler_KeyDown(e);
                //e.Handled = true;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (RoverMovement.RoverMovementHandler() != null)
            {
                RoverMovement.KeyboardInputHandler_KeyUp(e);
                //e.Handled = true;
            }
        }
    }
}
