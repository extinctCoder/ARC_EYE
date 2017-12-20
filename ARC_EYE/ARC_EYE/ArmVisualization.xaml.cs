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
    /// Interaction logic for ArmVisualization.xaml
    /// </summary>
    public partial class ArmVisualization : UserControl
    {
        public static ArmVisualization _ArmVisualization = null;
        public static ArmVisualization ArmVisualizationHandler()
        {
            if (_ArmVisualization == null)
            {
                _ArmVisualization = new ArmVisualization();
            }
            return _ArmVisualization;
        }
        private ArmVisualization()
        {
            InitializeComponent();
        }

        private void initialize_btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
