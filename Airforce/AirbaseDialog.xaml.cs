using Alesik.Haidov.Airforce.Interfaces;
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
using System.Windows.Shapes;

namespace Alesik.Haidov.Airforce.UI
{
    /// <summary>
    /// Interaction logic for AirbaseDialog.xaml
    /// </summary>
    public partial class AirbaseDialog : Window
    {
        public AirbaseDialog()
        {
            InitializeComponent();
        }

        public AirbaseDialog(IAirbase airbase)
        {
            InitializeComponent();
            airbaseName.Text = airbase.Name;
            airbaseLocation.Text = airbase.Location;
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            airbaseName.SelectAll();
            airbaseName.Focus();
        }

        public string AirbaseName
        {
            get { return airbaseName.Text; }
        }
        public string AirbaseLocation
        {
            get { return airbaseLocation.Text; }
        }
    }
}
