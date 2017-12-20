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
    /// Interaction logic for PuttyModule.xaml
    /// </summary>
    public partial class PuttyModule : UserControl
    {

        public static PuttyModule _PuttyModule = null;
        public static PuttyModule PuttyModuleHandler()
        {
            if (_PuttyModule == null)
            {
                _PuttyModule = new PuttyModule();
            }
            return _PuttyModule;
        }
        private PuttyModule()
        {
            InitializeComponent();
        }
    }
}
