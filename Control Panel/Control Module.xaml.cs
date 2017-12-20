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
    /// Interaction logic for Control_Module.xaml
    /// </summary>
    public partial class Control_Module : UserControl
    {
        public Control_Module()
        {
            InitializeComponent();
			this.defultButtonState();
        }

        private void rvr_up_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rvr_lft_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rvr_rght_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rvr_dwn_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fst_dgre_lft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fst_dgre_rght_Click(object sender, RoutedEventArgs e)
        {

        }

        private void snd_dgre_up_Click(object sender, RoutedEventArgs e)
        {

        }

        private void snd_dgre_dwn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void thrd_dgre_up_Click(object sender, RoutedEventArgs e)
        {

        }

        private void thrd_dgre_dwn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void frth_dgre_up_Click(object sender, RoutedEventArgs e)
        {

        }

        private void frth_dgre_dwn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fifth_dgre_lft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fifth_dgre_rght_Click(object sender, RoutedEventArgs e)
        {

        }

        private void clw_dgre_on_Click(object sender, RoutedEventArgs e)
        {

        }

        private void clw_dgre_Off_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmra_up_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmra_lft_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmra_rght_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmra_dwn_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rld_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void joy_stck_initilize_btn_Click(object sender, RoutedEventArgs e)
        {

        }

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
			if (e.Key == Key.W)
			{
				this.rvr_up_btn.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.A)
			{
				this.rvr_lft_btn.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.D)
			{
				this.rvr_rght_btn.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.S)
			{
				this.rvr_dwn_btn.Background = Brushes.HotPink;
			}

			if (e.Key == Key.Up)
			{
				this.cmra_up_btn.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.Left)
			{
				this.cmra_lft_btn.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.Right)
			{
				this.cmra_rght_btn.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.Down)
			{
				this.cmra_dwn_btn.Background = Brushes.HotPink;
			}

			if (e.Key == Key.F)
			{
				this.fst_dgre_lft.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.C)
			{
				this.fst_dgre_rght.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.G)
			{
				this.snd_dgre_up.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.V)
			{
				this.snd_dgre_dwn.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.H)
			{
				this.thrd_dgre_up.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.B)
			{
				this.thrd_dgre_dwn.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.J)
			{
				this.frth_dgre_up.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.N)
			{
				this.frth_dgre_dwn.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.K)
			{
				this.fifth_dgre_lft.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.M)
			{
				this.fifth_dgre_rght.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.L)
			{
				this.clw_dgre_on.Background = Brushes.HotPink;
			}
			else if (e.Key == Key.OemComma)
			{
				this.clw_dgre_Off.Background = Brushes.HotPink;
			}
		}

		public void UserControl_KeyDown(KeyEventArgs e)
		{
			if (e.Key == Key.W)
			{
				this.rvr_up_btn.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.A)
			{
				this.rvr_lft_btn.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.D)
			{
				this.rvr_rght_btn.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.S)
			{
				this.rvr_dwn_btn.Background = Brushes.BlueViolet;
			}

			if (e.Key == Key.Up)
			{
				this.cmra_up_btn.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.Left)
			{
				this.cmra_lft_btn.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.Right)
			{
				this.cmra_rght_btn.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.Down)
			{
				this.cmra_dwn_btn.Background = Brushes.BlueViolet;
			}

			if (e.Key == Key.F)
			{
				this.fst_dgre_lft.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.C)
			{
				this.fst_dgre_rght.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.G)
			{
				this.snd_dgre_up.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.V)
			{
				this.snd_dgre_dwn.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.H)
			{
				this.thrd_dgre_up.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.B)
			{
				this.thrd_dgre_dwn.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.J)
			{
				this.frth_dgre_up.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.N)
			{
				this.frth_dgre_dwn.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.K)
			{
				this.fifth_dgre_lft.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.M)
			{
				this.fifth_dgre_rght.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.L)
			{
				this.clw_dgre_on.Background = Brushes.BlueViolet;
			}
			else if (e.Key == Key.OemComma)
			{
				this.clw_dgre_Off.Background = Brushes.BlueViolet;
			}
		}
	}
}
