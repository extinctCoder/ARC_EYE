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
			this.FirstDegreeLeft();
		}

		private void fst_dgre_rght_Click(object sender, RoutedEventArgs e)
		{
			this.fst_dgre_rght.Background = Brushes.Blue;
			this.FirstDegreeRight();
		}

		private void snd_dgre_up_Click(object sender, RoutedEventArgs e)
		{
			this.snd_dgre_up.Background = Brushes.Blue;
			this.SecondDrgreeUp();
		}

		private void snd_dgre_dwn_Click(object sender, RoutedEventArgs e)
		{
			this.snd_dgre_dwn.Background = Brushes.Blue;
			this.SecondDrgreeDown();
		}

		private void thrd_dgre_up_Click(object sender, RoutedEventArgs e)
		{
			this.thrd_dgre_up.Background = Brushes.Blue;
			this.SecondDrgreeUp();
		}

		private void thrd_dgre_dwn_Click(object sender, RoutedEventArgs e)
		{
			this.thrd_dgre_dwn.Background = Brushes.Blue;
			this.SecondDrgreeDown();
		}

		private void frth_dgre_up_Click(object sender, RoutedEventArgs e)
		{
			this.frth_dgre_up.Background = Brushes.Blue;
			this.FourthDrgreeUp();
		}

		private void frth_dgre_dwn_Click(object sender, RoutedEventArgs e)
		{
			this.frth_dgre_dwn.Background = Brushes.Blue;
			this.FourthDrgreeDown();
		}

		private void fifth_dgre_lft_Click(object sender, RoutedEventArgs e)
		{
			this.fifth_dgre_lft.Background = Brushes.Blue;
			this.FifthDegreeLeft();
		}

		private void fifth_dgre_rght_Click(object sender, RoutedEventArgs e)
		{
			this.fifth_dgre_rght.Background = Brushes.Blue;
			this.FifthDegreeRight();
		}

		private void clw_dgre_on_Click(object sender, RoutedEventArgs e)
		{
			this.clw_dgre_on.Background = Brushes.Blue;
			this.ClawOnn();
		}

		private void clw_dgre_Off_Click(object sender, RoutedEventArgs e)
		{
			this.clw_dgre_Off.Background = Brushes.Blue;
			this.ClawOff();
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
				this.rvrStop();
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
				this.rvrStop();
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
				this.rvrStop();
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
				this.rvrStop();
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

			if (state.Offset == JoystickOffset.Buttons6 && state.Value == 128)											//pwm increase
			{
				if (this.RoverPwm <= 80)
				{
					this.RoverPwm += 20;
				}
				this.Control_module.Dispatcher.Invoke((Action)(() =>
				{
					this.pwm_sldr.Value = this.RoverPwm;
				}));
			}
			else if (state.Offset == JoystickOffset.Buttons6 && state.Value == 0)
			{
				this.Control_module.Dispatcher.Invoke((Action)(() =>
				{
				}));
			}

			if (state.Offset == JoystickOffset.Buttons7 && state.Value == 128)										//pwm decrease
			{
				if (this.RoverPwm >= 20)
				{
					this.RoverPwm -= 20;
				}
				this.Control_module.Dispatcher.Invoke((Action)(() =>
				{
					this.pwm_sldr.Value = this.RoverPwm;
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
				rvrStop();
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
				this.rvrStop();
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
		private void defultButtonState()
		{
			this.rvr_up_btn.Background = Brushes.HotPink;
			this.rvr_lft_btn.Background = Brushes.HotPink;
			this.rvr_rght_btn.Background = Brushes.HotPink;
			this.rvr_dwn_btn.Background = Brushes.HotPink;
			this.cmra_up_btn.Background = Brushes.HotPink;
			this.cmra_lft_btn.Background = Brushes.HotPink;
			this.cmra_rght_btn.Background = Brushes.HotPink;
			this.cmra_dwn_btn.Background = Brushes.HotPink;
			this.fst_dgre_lft.Background = Brushes.HotPink;
			this.fst_dgre_rght.Background = Brushes.HotPink;
			this.snd_dgre_up.Background = Brushes.HotPink;
			this.snd_dgre_dwn.Background = Brushes.HotPink;
			this.thrd_dgre_up.Background = Brushes.HotPink;
			this.thrd_dgre_dwn.Background = Brushes.HotPink;
			this.frth_dgre_up.Background = Brushes.HotPink;
			this.frth_dgre_dwn.Background = Brushes.HotPink;
			this.fifth_dgre_lft.Background = Brushes.HotPink;
			this.fifth_dgre_rght.Background = Brushes.HotPink;
			this.clw_dgre_on.Background = Brushes.HotPink;
			this.clw_dgre_Off.Background = Brushes.HotPink;
		}

		public void UserControl_KeyUp(KeyEventArgs e)
		{
			if (e.Key == System.Windows.Input.Key.W)
			{
				this.rvr_up_btn.Background = Brushes.HotPink;
				this.rvrStop();
			}
			else if (e.Key == System.Windows.Input.Key.A)
			{
				this.rvr_lft_btn.Background = Brushes.HotPink;
				this.rvrStop();
			}
			else if (e.Key == System.Windows.Input.Key.D)
			{
				this.rvr_rght_btn.Background = Brushes.HotPink;
				this.rvrStop();
			}
			else if (e.Key == System.Windows.Input.Key.S)
			{
				this.rvr_dwn_btn.Background = Brushes.HotPink;
				this.rvrStop();
			}

			if (e.Key == System.Windows.Input.Key.Up)
			{
				this.cmra_up_btn.Background = Brushes.HotPink;
				this.cmraStp();
			}
			else if (e.Key == System.Windows.Input.Key.Left)
			{
				this.cmra_lft_btn.Background = Brushes.HotPink;
				this.cmraStp();
			}
			else if (e.Key == System.Windows.Input.Key.Right)
			{
				this.cmra_rght_btn.Background = Brushes.HotPink;
				this.cmraStp();
			}
			else if (e.Key == System.Windows.Input.Key.Down)
			{
				this.cmra_dwn_btn.Background = Brushes.HotPink;
				this.cmraStp();
			}

			if (e.Key == System.Windows.Input.Key.F)
			{
				this.fst_dgre_lft.Background = Brushes.HotPink;
				this.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.C)
			{
				this.fst_dgre_rght.Background = Brushes.HotPink;
				this.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.G)
			{
				this.snd_dgre_up.Background = Brushes.HotPink;
				this.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.V)
			{
				this.snd_dgre_dwn.Background = Brushes.HotPink;
				this.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.H)
			{
				this.thrd_dgre_up.Background = Brushes.HotPink;
				this.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.B)
			{
				this.thrd_dgre_dwn.Background = Brushes.HotPink;
				this.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.J)
			{
				this.frth_dgre_up.Background = Brushes.HotPink;
				this.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.N)
			{
				this.frth_dgre_dwn.Background = Brushes.HotPink;
				this.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.K)
			{
				this.fifth_dgre_lft.Background = Brushes.HotPink;
				this.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.M)
			{
				this.fifth_dgre_rght.Background = Brushes.HotPink;
				this.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.L)
			{
				this.clw_dgre_on.Background = Brushes.HotPink;
				this.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.OemComma)
			{
				this.clw_dgre_Off.Background = Brushes.HotPink;
				this.HandMovementStop();
			}
		}

		public void UserControl_KeyDown(KeyEventArgs e)
		{
			if (e.Key == System.Windows.Input.Key.W)
			{
				this.rvr_up_btn.Background = Brushes.BlueViolet;
				this.rvrFrwrd();
			}
			else if (e.Key == System.Windows.Input.Key.A)
			{
				this.rvr_lft_btn.Background = Brushes.BlueViolet;
				this.rvrLft();
			}
			else if (e.Key == System.Windows.Input.Key.D)
			{
				this.rvr_rght_btn.Background = Brushes.BlueViolet;
				this.cmraRght();
			}
			else if (e.Key == System.Windows.Input.Key.S)
			{
				this.rvr_dwn_btn.Background = Brushes.BlueViolet;
				this.rvrBckwrd();
			}

			if (e.Key == System.Windows.Input.Key.Up)
			{
				this.cmra_up_btn.Background = Brushes.BlueViolet;
				this.cmraUp();
			}
			else if (e.Key == System.Windows.Input.Key.Left)
			{
				this.cmra_lft_btn.Background = Brushes.BlueViolet;
				this.cmraLft();
			}
			else if (e.Key == System.Windows.Input.Key.Right)
			{
				this.cmra_rght_btn.Background = Brushes.BlueViolet;
				this.cmraRght();
			}
			else if (e.Key == System.Windows.Input.Key.Down)
			{
				this.cmra_dwn_btn.Background = Brushes.BlueViolet;
				this.cmraDwn();
			}

			if (e.Key == System.Windows.Input.Key.F)
			{
				this.fst_dgre_lft.Background = Brushes.BlueViolet;
				this.FirstDegreeLeft();
			}
			else if (e.Key == System.Windows.Input.Key.C)
			{
				this.fst_dgre_rght.Background = Brushes.BlueViolet;
				this.FirstDegreeRight();
			}
			else if (e.Key == System.Windows.Input.Key.G)
			{
				this.snd_dgre_up.Background = Brushes.BlueViolet;
				this.SecondDrgreeUp();
			}
			else if (e.Key == System.Windows.Input.Key.V)
			{
				this.snd_dgre_dwn.Background = Brushes.BlueViolet;
				this.SecondDrgreeDown();
			}
			else if (e.Key == System.Windows.Input.Key.H)
			{
				this.thrd_dgre_up.Background = Brushes.BlueViolet;
				this.ThirdDrgreeUp();
			}
			else if (e.Key == System.Windows.Input.Key.B)
			{
				this.thrd_dgre_dwn.Background = Brushes.BlueViolet;
				this.ThirdDrgreeDown();
			}
			else if (e.Key == System.Windows.Input.Key.J)
			{
				this.frth_dgre_up.Background = Brushes.BlueViolet;
				this.FourthDrgreeUp();
			}
			else if (e.Key == System.Windows.Input.Key.N)
			{
				this.frth_dgre_dwn.Background = Brushes.BlueViolet;
				this.FourthDrgreeDown();
			}
			else if (e.Key == System.Windows.Input.Key.K)
			{
				this.fifth_dgre_lft.Background = Brushes.BlueViolet;
				this.FifthDegreeLeft();
			}
			else if (e.Key == System.Windows.Input.Key.M)
			{
				this.fifth_dgre_rght.Background = Brushes.BlueViolet;
				this.FifthDegreeRight();
			}
			else if (e.Key == System.Windows.Input.Key.L)
			{
				this.clw_dgre_on.Background = Brushes.BlueViolet;
				this.ClawOnn();
			}
			else if (e.Key == System.Windows.Input.Key.OemComma)
			{
				this.clw_dgre_Off.Background = Brushes.BlueViolet;
				this.ClawOff();
			}
		}
	}
	public partial class Control_Module
	{
		private RoverAndArmRoverMovement roverMovement = RoverAndArmRoverMovement.Stop;
		private RoverCameraMovement cameraMovement = RoverCameraMovement.Stop;
		private HandMovement handMovement = HandMovement.Stop;
		int RoverPwm = 0;
		int CameraSpeed = 10;
		int HandSpeed = 10;

		private void rvrFrwrd()
		{
			if (roverMovement != RoverAndArmRoverMovement.Forward)
			{
				roverMovement = RoverAndArmRoverMovement.Forward;
				ConnectorOne.RoverMovementUpdater(roverMovement, RoverPwm);
			}
		}
		private void rvrBckwrd()
		{
			if (roverMovement != RoverAndArmRoverMovement.Backward)
			{
				roverMovement = RoverAndArmRoverMovement.Backward;
				ConnectorOne.RoverMovementUpdater(roverMovement, RoverPwm);
			}
		}
		private void rvrLft()
		{
			if (roverMovement != RoverAndArmRoverMovement.LeftTurn)
			{
				roverMovement = RoverAndArmRoverMovement.LeftTurn;
				ConnectorOne.RoverMovementUpdater(roverMovement, RoverPwm);
			}
		}
		private void rvrRght()
		{
			if (roverMovement != RoverAndArmRoverMovement.RightTurn)
			{
				roverMovement = RoverAndArmRoverMovement.RightTurn;
				ConnectorOne.RoverMovementUpdater(roverMovement, RoverPwm);
			}
		}
		private void rvrStop()
		{
			if (roverMovement != RoverAndArmRoverMovement.Stop)
			{
				roverMovement = RoverAndArmRoverMovement.Stop;
				ConnectorOne.RoverMovementUpdater(roverMovement, RoverPwm);
			}
		}

		private void cmraLft()
		{
			if (cameraMovement != RoverCameraMovement.LeftTurn)
			{
				cameraMovement = RoverCameraMovement.LeftTurn;
				ConnectorOne.CameraMovementUpdater(cameraMovement, CameraSpeed);
			}
		}
		private void cmraRght()
		{
			if (cameraMovement != RoverCameraMovement.RightTurn)
			{
				cameraMovement = RoverCameraMovement.RightTurn;
				ConnectorOne.CameraMovementUpdater(cameraMovement, CameraSpeed);
			}
		}
		private void cmraUp()
		{
			if (cameraMovement != RoverCameraMovement.UpTurn)
			{
				cameraMovement = RoverCameraMovement.UpTurn;
				ConnectorOne.CameraMovementUpdater(cameraMovement, CameraSpeed);
			}
		}
		private void cmraDwn()
		{
			if (cameraMovement != RoverCameraMovement.DownTurn)
			{
				cameraMovement = RoverCameraMovement.DownTurn;
				ConnectorOne.CameraMovementUpdater(cameraMovement, CameraSpeed);
			}
		}
		private void cmraStp()
		{
			if (cameraMovement != RoverCameraMovement.Stop)
			{
				cameraMovement = RoverCameraMovement.Stop;
				ConnectorOne.CameraMovementUpdater(cameraMovement, CameraSpeed);
			}
		}

		private void FirstDegreeLeft()
		{
			if (handMovement != HandMovement.FirstDegreeLeft)
			{
				handMovement = HandMovement.FirstDegreeLeft;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
		private void FirstDegreeRight()
		{
			if (handMovement != HandMovement.FirstDegreeRight)
			{
				handMovement = HandMovement.FirstDegreeRight;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
		private void SecondDrgreeUp()
		{
			if (handMovement != HandMovement.SecondDegreeUp)
			{
				handMovement = HandMovement.SecondDegreeUp;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
		private void SecondDrgreeDown()
		{
			if (handMovement != HandMovement.SecondDegreeDown)
			{
				handMovement = HandMovement.SecondDegreeDown;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
		private void ThirdDrgreeUp()
		{
			if (handMovement != HandMovement.ThirdDegreeUp)
			{
				handMovement = HandMovement.ThirdDegreeUp;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
		private void ThirdDrgreeDown()
		{
			if (handMovement != HandMovement.ThirdDegreeDown)
			{
				handMovement = HandMovement.ThirdDegreeDown;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
		private void FourthDrgreeUp()
		{
			if (handMovement != HandMovement.FourthDegreeUp)
			{
				handMovement = HandMovement.FourthDegreeUp;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
		private void FourthDrgreeDown()
		{
			if (handMovement != HandMovement.FourthDegreeDown)
			{
				handMovement = HandMovement.FourthDegreeDown;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
		private void FifthDegreeLeft()
		{
			if (handMovement != HandMovement.FifthDegreeLeft)
			{
				handMovement = HandMovement.FifthDegreeLeft;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
		private void FifthDegreeRight()
		{
			if (handMovement != HandMovement.FifthDegreeRight)
			{
				handMovement = HandMovement.FifthDegreeRight;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
		private void ClawOnn()
		{
			if (handMovement != HandMovement.ClawOn)
			{
				handMovement = HandMovement.ClawOn;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
		private void ClawOff()
		{
			if (handMovement != HandMovement.ClawOff)
			{
				handMovement = HandMovement.ClawOff;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
		private void HandMovementStop()
		{
			if (handMovement != HandMovement.Stop)
			{
				handMovement = HandMovement.Stop;
				ConnectorOne.HandMovementUpdater(handMovement, HandSpeed);
			}
		}
	}
	
}
