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

namespace Control_Panel
{
    /// <summary>
    /// Interaction logic for Control_Module.xaml
    /// </summary>
    public partial class Control_Module : UserControl
    {

        private DirectInput directInput = new DirectInput();
        private Guid joystickGuid = Guid.Empty;
        public Control_Module()
        {
            InitializeComponent();
        }

        private void rvr_up_btn_Click(object sender, RoutedEventArgs e)
        {
            this.rvr_up_btn.Background = Brushes.Blue;
            this.rvrFrwrd();
        }

        private void rvr_lft_btn_Click(object sender, RoutedEventArgs e)
        {
            this.rvr_lft_btn.Background = Brushes.Blue;
            this.rvrLft();
        }

        private void rvr_rght_btn_Click(object sender, RoutedEventArgs e)
        {
            this.rvr_rght_btn.Background = Brushes.Blue;
            this.rvrRght();
        }

        private void rvr_dwn_btn_Click(object sender, RoutedEventArgs e)
        {
            this.rvr_dwn_btn.Background = Brushes.Blue;
            this.rvrBckwrd();
        }

        private void fst_dgre_lft_Click(object sender, RoutedEventArgs e)
        {
            this.fst_dgre_lft.Background = Brushes.Blue;
        }

        private void fst_dgre_rght_Click(object sender, RoutedEventArgs e)
        {
            this.fst_dgre_rght.Background = Brushes.Blue;
        }

        private void snd_dgre_up_Click(object sender, RoutedEventArgs e)
        {
            this.snd_dgre_up.Background = Brushes.Blue;
        }

        private void snd_dgre_dwn_Click(object sender, RoutedEventArgs e)
        {
            this.snd_dgre_dwn.Background = Brushes.Blue;
        }

        private void thrd_dgre_up_Click(object sender, RoutedEventArgs e)
        {
            this.thrd_dgre_up.Background = Brushes.Blue;
        }

        private void thrd_dgre_dwn_Click(object sender, RoutedEventArgs e)
        {
            this.thrd_dgre_dwn.Background = Brushes.Blue;
        }

        private void frth_dgre_up_Click(object sender, RoutedEventArgs e)
        {
            this.frth_dgre_up.Background = Brushes.Blue;
        }

        private void frth_dgre_dwn_Click(object sender, RoutedEventArgs e)
        {
            this.frth_dgre_dwn.Background = Brushes.Blue;
        }

        private void fifth_dgre_lft_Click(object sender, RoutedEventArgs e)
        {
            this.fifth_dgre_lft.Background = Brushes.Blue;
        }

        private void fifth_dgre_rght_Click(object sender, RoutedEventArgs e)
        {
            this.fifth_dgre_rght.Background = Brushes.Blue;
        }

        private void clw_dgre_on_Click(object sender, RoutedEventArgs e)
        {
            this.clw_dgre_on.Background = Brushes.Blue;
        }

        private void clw_dgre_Off_Click(object sender, RoutedEventArgs e)
        {
            this.clw_dgre_Off.Background = Brushes.Blue;
        }

        private void cmra_up_btn_Click(object sender, RoutedEventArgs e)
        {
            this.cmra_up_btn.Background = Brushes.Blue;
            this.cmraUp();
        }

        private void cmra_lft_btn_Click(object sender, RoutedEventArgs e)
        {
            this.cmra_lft_btn.Background = Brushes.Blue;
            this.cmraLft();
        }

        private void cmra_rght_btn_Click(object sender, RoutedEventArgs e)
        {
            this.cmra_rght_btn.Background = Brushes.Blue;
            this.cmraRght();
        }

        private void cmra_dwn_btn_Click(object sender, RoutedEventArgs e)
        {
            this.cmra_dwn_btn.Background = Brushes.Blue;
            this.cmraDwn();
        }

        private void rld_btn_Click(object sender, RoutedEventArgs e)
        {
            this.joy_stck_cmbo_bx.Items.Clear();
            this.joy_stck_cmbo_bx_Loaded(new object(), new RoutedEventArgs());
        }
        private void defultBtnClor()
        {
            this.rvr_up_btn.Background = Brushes.LightGray;
            this.rvr_dwn_btn.Background = Brushes.LightGray;
            this.rvr_lft_btn.Background = Brushes.LightGray;
            this.rvr_rght_btn.Background = Brushes.LightGray;
            this.cmra_up_btn.Background = Brushes.LightGray;
            this.cmra_dwn_btn.Background = Brushes.LightGray;
            this.cmra_lft_btn.Background = Brushes.LightGray;
            this.cmra_rght_btn.Background = Brushes.LightGray;
            this.fst_dgre_lft.Background = Brushes.LightGray;
            this.fst_dgre_rght.Background = Brushes.LightGray;
            this.snd_dgre_up.Background = Brushes.LightGray;
            this.snd_dgre_dwn.Background = Brushes.LightGray;
            this.thrd_dgre_up.Background = Brushes.LightGray;
            this.thrd_dgre_dwn.Background = Brushes.LightGray;
            this.frth_dgre_up.Background = Brushes.LightGray;
            this.frth_dgre_dwn.Background = Brushes.LightGray;
            this.fifth_dgre_lft.Background = Brushes.LightGray;
            this.fifth_dgre_rght.Background = Brushes.LightGray;
            this.clw_dgre_on.Background = Brushes.LightGray;
            this.clw_dgre_Off.Background = Brushes.LightGray;
        }
        private void joy_stck_initilize_btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.joy_stck_cmbo_bx.SelectedItem != null)
            {
                Joystick joystick = new Joystick(directInput, (Guid)this.joy_stck_cmbo_bx.SelectedItem);
                this.joy_stck_cmbo_bx.IsEnabled = false;
                this.joy_stck_initilize_btn.IsEnabled = false;
                this.rld_btn.IsEnabled = false;
                Thread joystickInputHandlerThread = new Thread(() => joystickInputHandler(joystick));
                joystickInputHandlerThread.IsBackground = true;
                joystickInputHandlerThread.Start();
            }
            else
            {
            }
        }

        private void joystickInputHandler(Joystick joystick)
        {
            try
            {
                joystick.Properties.BufferSize = 128;
                joystick.Acquire();
                while (true)
                {
                    joystick.Poll();
                    var datas = joystick.GetBufferedData();
                    foreach (var state in datas)
                    {
                        //RoverConsole.ArcEyeContentThreadSafe("Joystick data : " + state.ToString());
                        this.buttonHandlerAnalog(state);
                        this.buttonHandlerDigital(state);
                    }

                }
            }
            catch (Exception ex)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.rld_btn.IsEnabled = true;
                }));
            }
        }

        private void buttonHandlerDigital(JoystickUpdate state)
        {
            if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 27000)                                                 //Camera Left Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.cmra_lft_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 18000)                                            //Camera Down Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.cmra_dwn_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 9000)                                             //Camera Right Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.cmra_rght_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 0)                                                //Camera Up Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.cmra_up_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 31500)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    //up left
                }));
            }
            else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 4500)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    //up right
                }));
            }
            else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 22500)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    //down left
                }));
            }
            else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 13500)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    //down right
                }));
            }
            else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == -1)                                               //Camera Empty Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.defultBtnClor();
                }));
            }

            if (state.Offset == JoystickOffset.Buttons0 && state.Value == 128)                                                                  //Rover Forward Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.rvr_up_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.Buttons0 && state.Value == 0)                                                               //Rover Stop Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.defultBtnClor();
                }));
            }

            if (state.Offset == JoystickOffset.Buttons1 && state.Value == 128)                                                                  //Rover Right Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.rvr_rght_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.Buttons1 && state.Value == 0)                                                               //Rover Stop Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.defultBtnClor();
                }));
            }

            if (state.Offset == JoystickOffset.Buttons2 && state.Value == 128)                                                                  //Rover Backward Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.rvr_dwn_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.Buttons2 && state.Value == 0)                                                               //Rover Stop Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.defultBtnClor();
                }));
            }

            if (state.Offset == JoystickOffset.Buttons3 && state.Value == 128)                                                                  //Rover Left Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.rvr_lft_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.Buttons3 && state.Value == 0)                                                               //Rover Stop Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.defultBtnClor();
                }));
            }

            if (state.Offset == JoystickOffset.Buttons4 && state.Value == 128)//high torque
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                }));
            }
            else if (state.Offset == JoystickOffset.Buttons4 && state.Value == 0)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                }));
            }

            if (state.Offset == JoystickOffset.Buttons5 && state.Value == 128)//high speed
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                }));
            }
            else if (state.Offset == JoystickOffset.Buttons5 && state.Value == 0)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                }));
            }

            if (state.Offset == JoystickOffset.Buttons6 && state.Value == 128)//pwm increase
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                }));
            }
            else if (state.Offset == JoystickOffset.Buttons6 && state.Value == 0)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                }));
            }

            if (state.Offset == JoystickOffset.Buttons7 && state.Value == 128)//pwm decrease
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                }));
            }
            else if (state.Offset == JoystickOffset.Buttons7 && state.Value == 0)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                }));
            }

            if (state.Offset == JoystickOffset.Buttons8 && state.Value == 128)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                }));
            }
            else if (state.Offset == JoystickOffset.Buttons8 && state.Value == 0)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                }));
            }

            if (state.Offset == JoystickOffset.Buttons9 && state.Value == 128)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                }));
            }
            else if (state.Offset == JoystickOffset.Buttons9 && state.Value == 0)
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                }));
            }
        }

        private void buttonHandlerAnalog(JoystickUpdate state)
        {
            if (state.Offset == JoystickOffset.X && state.Value < 32767)                                                                        //Camera Left Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.cmra_lft_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.X && state.Value > 32767)                                                                   //Camera Right Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.cmra_rght_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.X && state.Value == 32767)                                                                  //Camera Empty Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.defultBtnClor();
                }));
            }

            if (state.Offset == JoystickOffset.Y && state.Value < 32767)                                                                        //Camera Up Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.cmra_up_btn_Click(new object(), new RoutedEventArgs());
                }));

            }
            else if (state.Offset == JoystickOffset.Y && state.Value > 32767)                                                                   //Camera Down Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.cmra_dwn_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.Y && state.Value == 32767)                                                                  //Camera Empty Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.defultBtnClor();
                }));
            }

            if (state.Offset == JoystickOffset.Z && state.Value < 32767)                                                                        //Rover Left Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.rvr_lft_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.Z && state.Value > 32767)                                                                   //Rover Right Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.rvr_rght_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.Z && state.Value == 32767)                                                                   //Rover Stop Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.defultBtnClor();
                }));
            }

            if (state.Offset == JoystickOffset.RotationZ && state.Value < 32767)                                                                //Rover Forward Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.rvr_up_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.RotationZ && state.Value > 32767)                                                           //Rover Backward Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.rvr_dwn_btn_Click(new object(), new RoutedEventArgs());
                }));
            }
            else if (state.Offset == JoystickOffset.RotationZ && state.Value == 32767)                                                          //Rover Stop Function
            {
                this.Control_module.Dispatcher.Invoke((Action)(() =>
                {
                    this.defultBtnClor();
                }));
            }
        }

        private void joy_stck_cmbo_bx_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.joy_stck_cmbo_bx.Items.Clear();
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = deviceInstance.InstanceGuid;
                    this.joy_stck_cmbo_bx.Items.Add(joystickGuid);
                }
                if (joystickGuid == System.Guid.Empty)
                {
                    this.joy_stck_cmbo_bx.IsEnabled = false;
                }
                else
                {
                    this.joy_stck_initilize_btn.IsEnabled = true;
                    this.joy_stck_cmbo_bx.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    public partial class Control_Module
    {
        private void rvrFrwrd()
        {

        }
        private void rvrBckwrd()
        {

        }
        private void rvrLft()
        {

        }
        private void rvrRght()
        {

        }
        private void rvrStop()
        {

        }
        private void cmraLft()
        {

        }
        private void cmraRght()
        {

        }
        private void cmraUp()
        {

        }
        private void cmraDwn()
        {

        }
        private void cmraStp()
        {

        }
    }
}
