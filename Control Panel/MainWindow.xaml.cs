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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		private Control_Module controlModule = null;
		public MainWindow()
        {
            InitializeComponent();
			controlModule = new Control_Module();
			this.rvr_cntrl_mdl.Children.Add(controlModule);
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (controlModule != null)
			{
				this.controlModule.UserControl_KeyDown(e);
			}
		}

		private void Window_KeyUp(object sender, KeyEventArgs e)
		{
			if (controlModule != null)
			{
				this.controlModule.UserControl_KeyUp(e);
			}
		}
	}
}
