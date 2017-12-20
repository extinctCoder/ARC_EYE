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
    /// Interaction logic for RoverConsole.xaml
    /// </summary>
    public partial class RoverConsole : UserControl
    {
        public static RoverConsole _RoverConsole = null;
        public static RoverConsole RoverConsoleHandler()
        {
            if (_RoverConsole == null)
            {
                _RoverConsole = new RoverConsole();
            }
            return _RoverConsole;
        }
        private RoverConsole()
        {
            InitializeComponent();
        }

        private void cnsl_btn_Click(object sender, RoutedEventArgs e)
        {
            _RoverConsole.cnsl_txt.AppendText("USER\t: " + _RoverConsole.cnsl_inpt.Text + "\n");
            _RoverConsole.cnsl_inpt.Clear();
            _RoverConsole.cnsl_txt.ScrollToEnd();
        }

        private void cnsl_inpt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                _RoverConsole.cnsl_txt.AppendText("USER\t: " + _RoverConsole.cnsl_inpt.Text + "\n");
                _RoverConsole.cnsl_inpt.Clear();
                _RoverConsole.cnsl_txt.ScrollToEnd();
            }
        }

        public static void ArcEyeContent(String msg)
        {
            _RoverConsole.cnsl_txt.AppendText("Arc Eye\t: " + msg + "\n");
            _RoverConsole.cnsl_txt.ScrollToEnd();
        }

        public static void UserContent(String msg)
        {
            _RoverConsole.cnsl_txt.AppendText("USER\t: " + _RoverConsole.cnsl_inpt.Text + "\n");
            _RoverConsole.cnsl_txt.ScrollToEnd();

        }

        public static void ArcEyeAiContent(String msg)
        {

            _RoverConsole.cnsl_txt.AppendText("Arc Eye AI\t: " + msg + "\n");
            _RoverConsole.cnsl_txt.ScrollToEnd();
        }

        public static void ArcEyeContentThreadSafe(String msg)
        {
            try
            {
                lock (_RoverConsole)
                {
                    _RoverConsole.cnsl_txt.Dispatcher.Invoke(new Action(() => _RoverConsole.cnsl_txt.AppendText("ARC_EYE : " + msg.ToString() + "\n")));
                    //_RoverConsole.cnsl_txt.Dispatcher.Invoke(new Action(() => _RoverConsole.cnsl_txt.Clear()));
                    _RoverConsole.cnsl_txt.Dispatcher.Invoke(new Action(() => _RoverConsole.cnsl_txt.ScrollToEnd()));
                }
            }
            catch { }
        }

        public static void UserContentThreadSafe(String msg)
        {
            lock (_RoverConsole)
            {
                _RoverConsole.cnsl_txt.Dispatcher.Invoke(new Action(() => _RoverConsole.cnsl_txt.AppendText("USER : " + msg.ToString() + "\n")));
                //_RoverConsole.cnsl_txt.Dispatcher.Invoke(new Action(() => _RoverConsole.cnsl_txt.Clear()));
                _RoverConsole.cnsl_txt.Dispatcher.Invoke(new Action(() => _RoverConsole.cnsl_txt.ScrollToEnd()));
            }
        }

        public static void ArcEyeAiContentThreadSafe(String msg)
        {
            try
            {
                lock (_RoverConsole)
                {
                    _RoverConsole.cnsl_txt.Dispatcher.Invoke(new Action(() => _RoverConsole.cnsl_txt.AppendText("ARC_EYE_AI : " + msg.ToString() + "\n")));
                    //_RoverConsole.cnsl_txt.Dispatcher.Invoke(new Action(() => _RoverConsole.cnsl_txt.Clear()));
                    _RoverConsole.cnsl_txt.Dispatcher.Invoke(new Action(() => _RoverConsole.cnsl_txt.ScrollToEnd()));
                }
            }
            catch { }
        }

    }
}
