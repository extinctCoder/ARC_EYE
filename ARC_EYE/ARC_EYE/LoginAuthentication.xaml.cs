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

namespace ARC_EYE
{
    /// <summary>
    /// Interaction logic for LoginAuthentication.xaml
    /// </summary>
    public partial class LoginAuthentication : UserControl
    {

        public event EventHandler loginVarificationCmnd;

        public LoginAuthentication()
        {
            InitializeComponent();
        }

        private void lgin_btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.loginVarificationCmnd != null)
                this.loginVarificationCmnd(new object(), new EventArgs());
        }
    }
}
