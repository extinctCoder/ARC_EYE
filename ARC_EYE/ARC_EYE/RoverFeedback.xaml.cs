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
    /// Interaction logic for RoverFeedback.xaml
    /// </summary>
    public partial class RoverFeedback : UserControl
    {
        public static RoverFeedback _RoverFeedback = null;
        public static RoverFeedback RoverFeedbackHandler()
        {
            if (_RoverFeedback == null)
            {
                _RoverFeedback = new RoverFeedback();
            }
            return _RoverFeedback;
        }
        private RoverFeedback()
        {
            InitializeComponent();
        }
    }
}
