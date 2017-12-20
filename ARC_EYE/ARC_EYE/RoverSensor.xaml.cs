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
    /// Interaction logic for RoverSensor.xaml
    /// </summary>
    public partial class RoverSensor : UserControl
    {
        public static RoverSensor _RoverSensor = null;
        public static RoverSensor RoverSensorHandler()
        {
            if (_RoverSensor == null)
            {
                _RoverSensor = new RoverSensor();
            }
            return _RoverSensor;
        }
        private RoverSensor()
        {
            InitializeComponent();
        }
    }
}
