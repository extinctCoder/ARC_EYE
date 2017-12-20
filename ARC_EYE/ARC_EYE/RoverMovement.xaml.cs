using SharpDX.DirectInput;
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
    /// Interaction logic for RoverMovement.xaml
    /// </summary>
    public partial class RoverMovement : UserControl
    {
        public static RoverMovement _RoverMovement = null;

        public static RoverMovement RoverMovementHandler()
        {
            if (_RoverMovement == null)
            {
                _RoverMovement = new RoverMovement();
            }
            return _RoverMovement;
        }

        private RoverMovement()
        {
            InitializeComponent();
            ConnectorOne.pi1Port1ConnectedStatusEvent += new EventHandler(pi1Port1ConnectedStatusEventHandler);
            ConnectorOne.pi1Port1DisconnectedStatusEvent += new EventHandler(pi1Port1DisconnectedStatusEvent);
        }

        private void pwm_slidr_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            _RoverMovement.pwm_txt.Text = pwm_slidr.Value.ToString();

        }

        private void rld_btn_Click(object sender, RoutedEventArgs e)
        {

            _RoverMovement.joystick_lst.Items.Clear();
            joystickGuid = Guid.Empty;
            RoverConsole.ArcEyeContentThreadSafe("Joystick Is De Initialized.");
            _RoverMovement.joystck_pnl.IsExpanded = false;
            _RoverMovement.joystick_lst_Loaded(sender, e);

        }

        private void joystick_lst_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = deviceInstance.InstanceGuid;
                    _RoverMovement.joystick_lst.Items.Add(joystickGuid);
                }
                if (joystickGuid == System.Guid.Empty)
                {
                    RoverConsole.ArcEyeContentThreadSafe("No Joystick Found.");
                    RoverConsole.ArcEyeAiContentThreadSafe("Press The Reload Button To Search Again");
                    _RoverMovement.joystick_lst.IsEnabled = false;
                }
                else
                {
                    RoverConsole.ArcEyeAiContentThreadSafe("Joystick Found.");
                    _RoverMovement.initialize_btn.IsEnabled = true;
                    _RoverMovement.joystick_lst.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                RoverConsole.ArcEyeAiContent(ex.ToString());
            }

        }

        private void initialize_btn_Click(object sender, RoutedEventArgs e)
        {

            if (_RoverMovement.joystick_lst.SelectedItem != null)
            {
                Joystick joystick = new Joystick(directInput, (Guid)_RoverMovement.joystick_lst.SelectedItem);
                RoverConsole.ArcEyeContentThreadSafe("Joystick initialization successful.");
                _RoverMovement.initialize_btn.IsEnabled = false;
                _RoverMovement.joystick_lst.IsEnabled = false;
                _RoverMovement.rld_btn.IsEnabled = false;
                _RoverMovement.fst_initialize_btn.IsEnabled = false;
                Thread joystickInputHandlerThread = new Thread(() => joystickInputHandler(joystick));
                joystickInputHandlerThread.IsBackground = true;
                joystickInputHandlerThread.Start();
                _RoverMovement.joystck_pnl.IsExpanded = true;
            }
            else
            {
                RoverConsole.ArcEyeAiContentThreadSafe("No Joystick Selected");
            }

        }


        private void fst_initialize_btn_Click(object sender, RoutedEventArgs e)
        {
            _RoverMovement.joystick_lst.Items.Clear();
            joystickGuid = Guid.Empty;
            RoverConsole.ArcEyeContentThreadSafe("Initializing fast Joystick Initializing process.");
            try
            {
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = deviceInstance.InstanceGuid;
                    _RoverMovement.joystick_lst.Items.Add(joystickGuid);
                }
                if (joystickGuid == System.Guid.Empty)
                {
                    RoverConsole.ArcEyeContentThreadSafe("No Joystick Found.");
                    RoverConsole.ArcEyeAiContentThreadSafe("Fast Initializing Process Failed.");
                }
                else
                {
                    RoverConsole.ArcEyeAiContentThreadSafe("Joystick Found.");
                    _RoverMovement.initialize_btn.IsEnabled = true;
                    _RoverMovement.joystick_lst.IsEnabled = true;
                    Joystick joystick = new Joystick(directInput, (Guid)_RoverMovement.joystick_lst.Items[0]);
                    RoverConsole.ArcEyeContentThreadSafe("Joystick initialization successful.");
                    _RoverMovement.initialize_btn.IsEnabled = false;
                    _RoverMovement.joystick_lst.IsEnabled = false;
                    _RoverMovement.rld_btn.IsEnabled = false;
                    _RoverMovement.fst_initialize_btn.IsEnabled = false;
                    Thread joystickInputHandlerThread = new Thread(() => joystickInputHandler(joystick));
                    joystickInputHandlerThread.IsBackground = true;
                    joystickInputHandlerThread.Start();
                    _RoverMovement.joystck_pnl.IsExpanded = true;
                }
            }
            catch (Exception ex)
            {
                RoverConsole.ArcEyeAiContent(ex.ToString());
            }
        }

        private void rvr_up_Click(object sender, RoutedEventArgs e)
        {
            if (_RoverMovement != null)
            {
                RoverConsole.ArcEyeContentThreadSafe("rvr_up_Click");
                roverMovement = RoverAndArmRoverMovement.Forward;
                RoverMovementStatusUpdater();
            }
        }

        private void rvr_lft_Click(object sender, RoutedEventArgs e)
        {
            if (_RoverMovement != null)
            {
                RoverConsole.ArcEyeContentThreadSafe("rvr_lft_Click");
                roverMovement = RoverAndArmRoverMovement.LeftTurn;
                RoverMovementStatusUpdater();
            }
        }

        private void rvr_rght_Click(object sender, RoutedEventArgs e)
        {
            if (_RoverMovement != null)
            {
                RoverConsole.ArcEyeContentThreadSafe("rvr_rght_Click");
                roverMovement = RoverAndArmRoverMovement.RightTurn;
                RoverMovementStatusUpdater();
            }
        }

        private void rvr_dwn_Click(object sender, RoutedEventArgs e)
        {
            if (_RoverMovement != null)
            {
                RoverConsole.ArcEyeContentThreadSafe("rvr_dwn_Click");
                roverMovement = RoverAndArmRoverMovement.Backward;
                RoverMovementStatusUpdater();
            }
        }

        private void hgh_spd_btn_Click(object sender, RoutedEventArgs e)
        {
            _RoverMovement.hgh_spd_btn.IsEnabled = false;
            _RoverMovement.hgh_trq_btn.IsEnabled = true;
        }

        private void hgh_trq_btn_Click(object sender, RoutedEventArgs e)
        {
            _RoverMovement.hgh_spd_btn.IsEnabled = true;
            _RoverMovement.hgh_trq_btn.IsEnabled = false;
        }
    }
}
