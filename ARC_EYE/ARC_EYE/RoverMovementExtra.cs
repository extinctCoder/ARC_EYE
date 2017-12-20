using SharpDX.DirectInput;
using System;
using System.Windows.Input;
using System.Windows.Media;


namespace ARC_EYE
{
	public partial class RoverMovement
	{
		RoverAndArmRoverMovement roverMovement = RoverAndArmRoverMovement.Stop;
		double pwm = 0;
		double tempPwm = 0;
		private DirectInput directInput = new DirectInput();
		private Guid joystickGuid = Guid.Empty;

		public void updatePwm(double pwm)
		{
			_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
			{
				_RoverMovement.pwm = pwm;
				_RoverMovement.pwm_slidr.Value = pwm;
			}));
		}

		public static void KeyboardInputHandler_KeyDown(KeyEventArgs e)
		{
			if (e.Key == System.Windows.Input.Key.W)
			{
				if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Forward)
				{
					_RoverMovement.rvr_up.Background = Brushes.Green;
					_RoverMovement.roverMovement = RoverAndArmRoverMovement.Forward;
					_RoverMovement.pwm = _RoverMovement.tempPwm;
					_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
					_RoverMovement.RoverMovementStatusUpdater();
				}
				else
				{
					RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
				}
			}
			else if (e.Key == System.Windows.Input.Key.S)
			{
				if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Backward)
				{
					_RoverMovement.rvr_dwn.Background = Brushes.Green;
					_RoverMovement.roverMovement = RoverAndArmRoverMovement.Backward;
					_RoverMovement.pwm = _RoverMovement.tempPwm;
					_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
					_RoverMovement.RoverMovementStatusUpdater();
				}
				else
				{
					RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
				}
			}
			else if (e.Key == System.Windows.Input.Key.A)
			{
				if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.LeftTurn)
				{
					_RoverMovement.rvr_lft.Background = Brushes.Green;
					_RoverMovement.roverMovement = RoverAndArmRoverMovement.LeftTurn;
					_RoverMovement.pwm = _RoverMovement.tempPwm;
					_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
					_RoverMovement.RoverMovementStatusUpdater();
				}
				else
				{
					RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
				}
			}
			else if (e.Key == System.Windows.Input.Key.D)
			{
				if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.RightTurn)
				{
					_RoverMovement.rvr_rght.Background = Brushes.Green;
					_RoverMovement.roverMovement = RoverAndArmRoverMovement.RightTurn;
					_RoverMovement.pwm = _RoverMovement.tempPwm;
					_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
					_RoverMovement.RoverMovementStatusUpdater();
				}
				else
				{
					RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
				}
			}
			else if (e.Key == System.Windows.Input.Key.Space)
			{
				if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Stop)
				{
					_RoverMovement.rvr_rght.Background = Brushes.LightGray;
					_RoverMovement.rvr_up.Background = Brushes.LightGray;
					_RoverMovement.rvr_dwn.Background = Brushes.LightGray;
					_RoverMovement.rvr_lft.Background = Brushes.LightGray;
					_RoverMovement.roverMovement = RoverAndArmRoverMovement.Stop;
					_RoverMovement.pwm = 0;
					_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
					_RoverMovement.RoverMovementStatusUpdater();
				}
				else
				{
					RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
				}
			}
			else if (e.Key == System.Windows.Input.Key.LeftShift)
			{
				if (_RoverMovement.tempPwm <= 80)
				{
					_RoverMovement.tempPwm = _RoverMovement.tempPwm + 20;
					RoverConsole.ArcEyeContentThreadSafe("Speed set to : " + _RoverMovement.tempPwm.ToString());
				}
				else
				{
					RoverConsole.ArcEyeAiContentThreadSafe("Speed Already Set To The Maximum Limit");
				}
			}
			else if (e.Key == System.Windows.Input.Key.LeftCtrl)
			{

				if (_RoverMovement.tempPwm >= 40)
				{
					_RoverMovement.tempPwm = _RoverMovement.tempPwm - 20;
					RoverConsole.ArcEyeContentThreadSafe("Speed set to : " + _RoverMovement.tempPwm.ToString());
				}
				else
				{
					RoverConsole.ArcEyeAiContentThreadSafe("Speed Already Set To The Minimum Limit");
				}
			}

			if (e.Key == System.Windows.Input.Key.F)
			{
				_RoverMovement.frst_dgre_lft.Background = Brushes.BlueViolet;
				_RoverMovement.FirstDegreeLeft();
			}
			else if (e.Key == System.Windows.Input.Key.C)
			{
				_RoverMovement.frst_dgre_rght.Background = Brushes.BlueViolet;
				_RoverMovement.FirstDegreeRight();
			}
			else if (e.Key == System.Windows.Input.Key.G)
			{
				_RoverMovement.two_dgre_up.Background = Brushes.BlueViolet;
				_RoverMovement.SecondDrgreeUp();
			}
			else if (e.Key == System.Windows.Input.Key.V)
			{
				_RoverMovement.two_dgre_dwn.Background = Brushes.BlueViolet;
				_RoverMovement.SecondDrgreeDown();
			}
			else if (e.Key == System.Windows.Input.Key.H)
			{
				_RoverMovement.three_dgre_up.Background = Brushes.BlueViolet;
				_RoverMovement.ThirdDrgreeUp();
			}
			else if (e.Key == System.Windows.Input.Key.B)
			{
				_RoverMovement.three_dgre_dwn.Background = Brushes.BlueViolet;
				_RoverMovement.ThirdDrgreeDown();
			}
			else if (e.Key == System.Windows.Input.Key.J)
			{
				_RoverMovement.fur_dgre_lft.Background = Brushes.BlueViolet;
				_RoverMovement.FourthDrgreeUp();
			}
			else if (e.Key == System.Windows.Input.Key.N)
			{
				_RoverMovement.fur_dgre_rght.Background = Brushes.BlueViolet;
				_RoverMovement.FourthDrgreeDown();
			}
			else if (e.Key == System.Windows.Input.Key.K)
			{
				_RoverMovement.fiv_dgre_up.Background = Brushes.BlueViolet;
				_RoverMovement.FifthDegreeLeft();
			}
			else if (e.Key == System.Windows.Input.Key.M)
			{
				_RoverMovement.fiv_dgre_dwn.Background = Brushes.BlueViolet;
				_RoverMovement.FifthDegreeRight();
			}
			else if (e.Key == System.Windows.Input.Key.L)
			{
				_RoverMovement.clw_on.Background = Brushes.BlueViolet;
				_RoverMovement.ClawOnn();
			}
			else if (e.Key == System.Windows.Input.Key.OemComma)
			{
				_RoverMovement.clw_off.Background = Brushes.BlueViolet;
				_RoverMovement.ClawOff();
			}
			//e.Handled = true;
		}

		public static void KeyboardInputHandler_KeyUp(KeyEventArgs e)
		{
			if (e.Key == System.Windows.Input.Key.W)
			{
				_RoverMovement.rvr_up.Background = Brushes.Red;
				if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Stop)
				{

					_RoverMovement.roverMovement = RoverAndArmRoverMovement.Stop;
					_RoverMovement.pwm = 0;
					_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
					_RoverMovement.RoverMovementStatusUpdater();
				}
				else
				{
					RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
				}
			}
			else if (e.Key == System.Windows.Input.Key.S)
			{
				_RoverMovement.rvr_dwn.Background = Brushes.Red;
				if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Stop)
				{
					_RoverMovement.roverMovement = RoverAndArmRoverMovement.Stop;
					_RoverMovement.pwm = 0;
					_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
					_RoverMovement.RoverMovementStatusUpdater();
				}
				else
				{
					RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
				}
			}
			else if (e.Key == System.Windows.Input.Key.A)
			{
				_RoverMovement.rvr_lft.Background = Brushes.Red;
				if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Stop)
				{
					_RoverMovement.roverMovement = RoverAndArmRoverMovement.Stop;
					_RoverMovement.pwm = 0;
					_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
					_RoverMovement.RoverMovementStatusUpdater();
				}
				else
				{
					RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
				}
			}
			else if (e.Key == System.Windows.Input.Key.D)
			{
				_RoverMovement.rvr_rght.Background = Brushes.Red;
				if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Stop)
				{
					_RoverMovement.roverMovement = RoverAndArmRoverMovement.Stop;
					_RoverMovement.pwm = 0;
					_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
					_RoverMovement.RoverMovementStatusUpdater();
				}
				else
				{
					RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
				}
			}

			if (e.Key == System.Windows.Input.Key.F)
			{
				_RoverMovement.frst_dgre_lft.Background = Brushes.HotPink;
				_RoverMovement.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.C)
			{
				_RoverMovement.frst_dgre_rght.Background = Brushes.HotPink;
				_RoverMovement.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.G)
			{
				_RoverMovement.two_dgre_up.Background = Brushes.HotPink;
				_RoverMovement.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.V)
			{
				_RoverMovement.two_dgre_dwn.Background = Brushes.HotPink;
				_RoverMovement.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.H)
			{
				_RoverMovement.three_dgre_up.Background = Brushes.HotPink;
				_RoverMovement.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.B)
			{
				_RoverMovement.three_dgre_dwn.Background = Brushes.HotPink;
				_RoverMovement.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.J)
			{
				_RoverMovement.fur_dgre_lft.Background = Brushes.HotPink;
				_RoverMovement.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.N)
			{
				_RoverMovement.fur_dgre_rght.Background = Brushes.HotPink;
				_RoverMovement.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.K)
			{
				_RoverMovement.fiv_dgre_up.Background = Brushes.HotPink;
				_RoverMovement.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.M)
			{
				_RoverMovement.fiv_dgre_dwn.Background = Brushes.HotPink;
				_RoverMovement.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.L)
			{
				_RoverMovement.clw_on.Background = Brushes.HotPink;
				_RoverMovement.HandMovementStop();
			}
			else if (e.Key == System.Windows.Input.Key.OemComma)
			{
				_RoverMovement.clw_off.Background = Brushes.HotPink;
				_RoverMovement.HandMovementStop();
			}
			//e.Handled = true;
		}

		public void RoverMovementStatusUpdater()
		{
			if (_RoverMovement != null)
			{
				RoverConsole.ArcEyeAiContentThreadSafe("Rover Movement Command : Direction-" + roverMovement.ToString() + ", Speed-" + pwm.ToString());
				ConnectorOne.RoverMovementStatusUpdater(roverMovement, pwm);
			}
		}

		public void RoverMovementStatusUpdater(RoverAndArmRoverMovement roverMovement, double pwm)
		{
			RoverConsole.ArcEyeAiContent("Rover Movement Command : Direction-" + roverMovement.ToString() + ", Speed-" + pwm.ToString());
			ConnectorOne.RoverMovementStatusUpdater(roverMovement, pwm);
		}

		private void joystickInputHandler(Joystick joystick)
		{
			try
			{
				RoverConsole.ArcEyeContentThreadSafe("Joystick ready to rock and roll.");
				joystick.Properties.BufferSize = 128;
				joystick.Acquire();
				while (true)
				{
					joystick.Poll();
					var datas = joystick.GetBufferedData();
					foreach (var state in datas)
					{
						//RoverConsole.ArcEyeContentThreadSafe("Joystick data : " + state.ToString());
						_RoverMovement.buttonHandlerAnalog(state);
						_RoverMovement.buttonHandlerDigital(state);
					}

				}
			}
			catch (Exception ex)
			{
				RoverConsole.ArcEyeAiContentThreadSafe(ex.ToString());
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.joystck_pnl.IsExpanded = false;
					_RoverMovement.rld_btn.IsEnabled = true;
					_RoverMovement.fst_initialize_btn.IsEnabled = true;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Stop)
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Exciting safety procedure ...!!!");
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.Stop;
						_RoverMovement.pwm = 0;
						_RoverMovement.RoverMovementStatusUpdater();
					}
				}));
				RoverConsole.ArcEyeAiContentThreadSafe("Mouse And KeyBoard Panel Activated, Set As primary I/o Device");
			}
		}

	}
	public partial class RoverMovement
	{

		private void pi1Port1ConnectedStatusEventHandler(object sender, EventArgs e)
		{
			_RoverMovement.rvr_mvmnt_pnl.IsEnabled = true;
		}

		private void pi1Port1DisconnectedStatusEvent(object sender, EventArgs e)
		{
			_RoverMovement.rvr_mvmnt_pnl.IsEnabled = false;
		}
	}
	public partial class RoverMovement                                                                                                          //joystick input definition ... :P
	{
		private void buttonHandlerAnalog(JoystickUpdate state)
		{
			if (state.Offset == JoystickOffset.X && state.Value < 32767)                                                                        //Camera 1 Left Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{

					_RoverMovement.xy_rb_13.IsChecked = true;
					_RoverMovement.pb_x.Value = state.Value / 655.35;
				}));
			}
			else if (state.Offset == JoystickOffset.X && state.Value > 32767)                                                                   //Camera 1 Right Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.xy_rb_53.IsChecked = true;
					_RoverMovement.pb_x.Value = state.Value / 655.35;
				}));
			}
			else if (state.Offset == JoystickOffset.X && state.Value == 32767)                                                                  //Camera 1 Empty Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.xy_rb_13.IsChecked = false;
					_RoverMovement.xy_rb_53.IsChecked = false;
					_RoverMovement.pb_x.Value = state.Value / 655.35;
				}));
			}

			if (state.Offset == JoystickOffset.Y && state.Value < 32767)                                                                        //Camera 1 Up Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{

					_RoverMovement.xy_rb_31.IsChecked = true;
					_RoverMovement.pb_y.Value = state.Value / 655.35;
				}));

			}
			else if (state.Offset == JoystickOffset.Y && state.Value > 32767)                                                                   //Camera 1 Down Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.xy_rb_35.IsChecked = true;
					_RoverMovement.pb_y.Value = state.Value / 655.35;
				}));
			}
			else if (state.Offset == JoystickOffset.Y && state.Value == 32767)                                                                  //Camera 1 Empty Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.xy_rb_31.IsChecked = false;
					_RoverMovement.xy_rb_35.IsChecked = false;
					_RoverMovement.pb_y.Value = state.Value / 655.35;
				}));
			}

			if (state.Offset == JoystickOffset.Z && state.Value < 32767)                                                                        //Rover Left Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.zz_rb_13.IsChecked = true;
					_RoverMovement.pb_z.Value = state.Value / 655.35;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.LeftTurn)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.LeftTurn;
						_RoverMovement.pwm = _RoverMovement.tempPwm;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Left Turn Command ");
					}
				}));
			}
			else if (state.Offset == JoystickOffset.Z && state.Value > 32767)                                                                   //Rover Right Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.zz_rb_53.IsChecked = true;
					_RoverMovement.pb_z.Value = state.Value / 655.35;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.RightTurn)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.RightTurn;
						_RoverMovement.pwm = _RoverMovement.tempPwm;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}
			else if (state.Offset == JoystickOffset.Z && state.Value == 32767)                                                                   //Rover Stop Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.zz_rb_13.IsChecked = false;
					_RoverMovement.zz_rb_53.IsChecked = false;
					_RoverMovement.pb_z.Value = state.Value / 655.35;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Stop)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.Stop;
						_RoverMovement.pwm = 0;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}

			if (state.Offset == JoystickOffset.RotationZ && state.Value < 32767)                                                                //Rover Forward Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.zz_rb_31.IsChecked = true;
					_RoverMovement.pb_rz.Value = state.Value / 655.35;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Forward)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.Forward;
						_RoverMovement.pwm = _RoverMovement.tempPwm;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}
			else if (state.Offset == JoystickOffset.RotationZ && state.Value > 32767)                                                           //Rover Backward Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.zz_rb_35.IsChecked = true;
					_RoverMovement.pb_rz.Value = state.Value / 655.35;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Backward)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.Backward;
						_RoverMovement.pwm = _RoverMovement.tempPwm;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}
			else if (state.Offset == JoystickOffset.RotationZ && state.Value == 32767)                                                          //Rover Stop Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.zz_rb_31.IsChecked = false;
					_RoverMovement.zz_rb_35.IsChecked = false;
					_RoverMovement.pb_rz.Value = state.Value / 655.35;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Stop)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.Stop;
						_RoverMovement.pwm = 0;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}

		}
		private void buttonHandlerDigital(JoystickUpdate state)
		{
			if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 27000)                                                 //Camera 2 Left Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_povc_left.IsChecked = true;
				}));
			}
			else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 18000)                                            //Camera 2 Down Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_povc_down.IsChecked = true;
				}));
			}
			else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 9000)                                             //Camera 2 Right Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_povc_right.IsChecked = true;
				}));
			}
			else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 0)                                                //Camera 2 Up Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_povc_up.IsChecked = true;
				}));
			}
			else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 31500)
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					//up left
				}));
			}
			else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 4500)
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					//up right
				}));
			}
			else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 22500)
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					//down left
				}));
			}
			else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == 13500)
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					//down right
				}));
			}
			else if (state.Offset == JoystickOffset.PointOfViewControllers0 && state.Value == -1)                                               //Camera 2 Empty Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_povc_left.IsChecked = false;
					_RoverMovement.rb_povc_down.IsChecked = false;
					_RoverMovement.rb_povc_right.IsChecked = false;
					_RoverMovement.rb_povc_up.IsChecked = false;
				}));
			}

			if (state.Offset == JoystickOffset.Buttons0 && state.Value == 128)                                                                  //Rover Forward Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_c.IsChecked = true;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Forward)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.Forward;
						_RoverMovement.pwm = _RoverMovement.tempPwm;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}
			else if (state.Offset == JoystickOffset.Buttons0 && state.Value == 0)                                                               //Rover Stop Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_c.IsChecked = false;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Stop)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.Stop;
						_RoverMovement.pwm = 0;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}

			if (state.Offset == JoystickOffset.Buttons1 && state.Value == 128)                                                                  //Rover Right Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_d.IsChecked = true; if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.RightTurn)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.RightTurn;
						_RoverMovement.pwm = _RoverMovement.tempPwm;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}
			else if (state.Offset == JoystickOffset.Buttons1 && state.Value == 0)                                                               //Rover Stop Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_d.IsChecked = false;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Stop)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.Stop;
						_RoverMovement.pwm = 0;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}

			if (state.Offset == JoystickOffset.Buttons2 && state.Value == 128)                                                                  //Rover Backward Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_a.IsChecked = true;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Backward)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.Backward;
						_RoverMovement.pwm = _RoverMovement.tempPwm;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}
			else if (state.Offset == JoystickOffset.Buttons2 && state.Value == 0)                                                               //Rover Stop Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_a.IsChecked = false;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Stop)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.Stop;
						_RoverMovement.pwm = 0;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}

			if (state.Offset == JoystickOffset.Buttons3 && state.Value == 128)                                                                  //Rover Left Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_b.IsChecked = true;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.LeftTurn)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.LeftTurn;
						_RoverMovement.pwm = _RoverMovement.tempPwm;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}
			else if (state.Offset == JoystickOffset.Buttons3 && state.Value == 0)                                                               //Rover Stop Function
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_b.IsChecked = false;
					if (_RoverMovement.roverMovement != RoverAndArmRoverMovement.Stop)
					{
						_RoverMovement.roverMovement = RoverAndArmRoverMovement.Stop;
						_RoverMovement.pwm = 0;
						_RoverMovement.pwm_slidr.Value = _RoverMovement.pwm;
						_RoverMovement.RoverMovementStatusUpdater();
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Executing Same Command ... !!!");
					}
				}));
			}

			if (state.Offset == JoystickOffset.Buttons4 && state.Value == 128)//high torque
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_l1.IsChecked = true;
					_RoverMovement.hgh_spd_btn.IsEnabled = true;
					_RoverMovement.hgh_trq_btn.IsEnabled = false;
				}));
			}
			else if (state.Offset == JoystickOffset.Buttons4 && state.Value == 0)
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_l1.IsChecked = false;
				}));
			}

			if (state.Offset == JoystickOffset.Buttons5 && state.Value == 128)//high speed
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_r1.IsChecked = true;
					_RoverMovement.hgh_spd_btn.IsEnabled = false;
					_RoverMovement.hgh_trq_btn.IsEnabled = true;
				}));
			}
			else if (state.Offset == JoystickOffset.Buttons5 && state.Value == 0)
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_r1.IsChecked = false;
				}));
			}

			if (state.Offset == JoystickOffset.Buttons6 && state.Value == 128)//pwm increase
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_l2.IsChecked = true;
					if (_RoverMovement.tempPwm <= 80)
					{
						_RoverMovement.tempPwm = _RoverMovement.tempPwm + 20;
						RoverConsole.ArcEyeContentThreadSafe("Speed set to : " + _RoverMovement.tempPwm.ToString());
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Speed Already Set To The Maximum Limit");
					}

				}));
			}
			else if (state.Offset == JoystickOffset.Buttons6 && state.Value == 0)
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_l2.IsChecked = false;
				}));
			}

			if (state.Offset == JoystickOffset.Buttons7 && state.Value == 128)//pwm decrease
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_r2.IsChecked = true;
					if (_RoverMovement.tempPwm >= 40)
					{
						_RoverMovement.tempPwm = _RoverMovement.tempPwm - 20;
						RoverConsole.ArcEyeContentThreadSafe("Speed set to : " + _RoverMovement.tempPwm.ToString());
					}
					else
					{
						RoverConsole.ArcEyeAiContentThreadSafe("Speed Already Set To The Minimum Limit");
					}
				}));
			}
			else if (state.Offset == JoystickOffset.Buttons7 && state.Value == 0)
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_r2.IsChecked = false;
				}));
			}

			if (state.Offset == JoystickOffset.Buttons8 && state.Value == 128)
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_08.IsChecked = true;
				}));
			}
			else if (state.Offset == JoystickOffset.Buttons8 && state.Value == 0)
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_08.IsChecked = false;
				}));
			}

			if (state.Offset == JoystickOffset.Buttons9 && state.Value == 128)
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_09.IsChecked = true;
				}));
			}
			else if (state.Offset == JoystickOffset.Buttons9 && state.Value == 0)
			{
				_RoverMovement.rvr_mvmnt_pnl.Dispatcher.Invoke((Action)(() =>
				{
					_RoverMovement.rb_09.IsChecked = false;
				}));
			}
		}
	}
	public partial class RoverMovement
	{
		private HandMovement handMovement = HandMovement.Stop;
		private MotorName motorName = MotorName.Stop;
		private void FirstDegreeLeft()
		{
			if (_RoverMovement.handMovement != HandMovement.FirstDegreeLeft)
			{
				_RoverMovement.handMovement = HandMovement.FirstDegreeLeft;
				_RoverMovement.motorName = MotorName.FirstDegreeMotor;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
		private void FirstDegreeRight()
		{
			if (_RoverMovement.handMovement != HandMovement.FirstDegreeRight)
			{
				_RoverMovement.handMovement = HandMovement.FirstDegreeRight;
				_RoverMovement.motorName = MotorName.FirstDegreeMotor;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
		private void SecondDrgreeUp()
		{
			if (_RoverMovement.handMovement != HandMovement.SecondDegreeUp)
			{
				_RoverMovement.handMovement = HandMovement.SecondDegreeUp;
				_RoverMovement.motorName = MotorName.SecondDegreeMotor;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
		private void SecondDrgreeDown()
		{
			if (_RoverMovement.handMovement != HandMovement.SecondDegreeDown)
			{
				_RoverMovement.handMovement = HandMovement.SecondDegreeDown;
				_RoverMovement.motorName = MotorName.SecondDegreeMotor;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
		private void ThirdDrgreeUp()
		{
			if (_RoverMovement.handMovement != HandMovement.ThirdDegreeUp)
			{
				_RoverMovement.handMovement = HandMovement.ThirdDegreeUp;
				_RoverMovement.motorName = MotorName.ThirdDegreeMotor;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
		private void ThirdDrgreeDown()
		{
			if (_RoverMovement.handMovement != HandMovement.ThirdDegreeDown)
			{
				_RoverMovement.handMovement = HandMovement.ThirdDegreeDown;
				_RoverMovement.motorName = MotorName.ThirdDegreeMotor;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
		private void FourthDrgreeUp()
		{
			if (_RoverMovement.handMovement != HandMovement.FourthDegreeUp)
			{
				_RoverMovement.handMovement = HandMovement.FourthDegreeUp;
				_RoverMovement.motorName = MotorName.FourthDegreeMotor;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
		private void FourthDrgreeDown()
		{
			if (_RoverMovement.handMovement != HandMovement.FourthDegreeDown)
			{
				_RoverMovement.handMovement = HandMovement.FourthDegreeDown;
				_RoverMovement.motorName = MotorName.FourthDegreeMotor;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
		private void FifthDegreeLeft()
		{
			if (_RoverMovement.handMovement != HandMovement.FifthDegreeLeft)
			{
				_RoverMovement.handMovement = HandMovement.FifthDegreeLeft;
				_RoverMovement.motorName = MotorName.FifthDegreeMotor;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
		private void FifthDegreeRight()
		{
			if (_RoverMovement.handMovement != HandMovement.FifthDegreeRight)
			{
				_RoverMovement.handMovement = HandMovement.FifthDegreeRight;
				_RoverMovement.motorName = MotorName.FifthDegreeMotor;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
		private void ClawOnn()
		{
			if (_RoverMovement.handMovement != HandMovement.ClawOn)
			{
				_RoverMovement.handMovement = HandMovement.ClawOn;
				_RoverMovement.motorName = MotorName.Claw;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
		private void ClawOff()
		{
			if (_RoverMovement.handMovement != HandMovement.ClawOff)
			{
				_RoverMovement.handMovement = HandMovement.ClawOff;
				_RoverMovement.motorName = MotorName.Claw;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
		private void HandMovementStop()
		{
			if (_RoverMovement.handMovement != HandMovement.Stop)
			{
				_RoverMovement.handMovement = HandMovement.Stop;
				_RoverMovement.motorName = MotorName.Stop;
				ConnectorOne.RoveArmStatusUpdater(motorName, handMovement);
			}
		}
	}
	public enum RoverAndArmRoverMovement
	{
		Forward, Backward, LeftTurn, RightTurn, Stop
	}
	public enum RoverCameraMovement
	{
		UpTurn, DownTurn, LeftTurn, RightTurn, Stop
	}
	public enum HandMovement
	{
		FirstDegreeLeft, FirstDegreeRight, SecondDegreeUp, SecondDegreeDown, ThirdDegreeUp, ThirdDegreeDown, FourthDegreeUp, FourthDegreeDown, FifthDegreeLeft, FifthDegreeRight, ClawOn, ClawOff, Stop
	}
	public enum MotorName
	{
		FirstDegreeMotor, SecondDegreeMotor, ThirdDegreeMotor, FourthDegreeMotor, FifthDegreeMotor, Claw, Stop
	}
	class RoverMovementExtra
	{
	}
}
