using Alesik.Haidov.Airforce.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AircraftDialog.xaml
    /// </summary>
    public partial class AircraftDialog : Window
    {
        public AircraftDialog(IEnumerable<string> airbases)
        {
            InitializeComponent();
            airbases.ToList().ForEach(f => airbase.Items.Add(f));
            if (airbase.Items.Count > 0)
            {
                airbase.SelectedIndex = 0;
            }
            aircraftType.ItemsSource = Enum.GetNames(typeof(AircraftType));
            if(aircraftType.Items.Count > 0)
            {
                aircraftType.SelectedIndex = 0;
            }
        }

        public AircraftDialog(IEnumerable<string> airbases, Interfaces.IAircraft aircraft)
        {
            InitializeComponent();
            airbases.ToList().ForEach(f => airbase.Items.Add(f));

            for (int i = 0; i < airbases.Count(); i++)
            {
                if (airbases.ElementAt(i).Equals(aircraft.Airbase.Name))
                {
                    airbase.SelectedIndex = i;
                    break;
                }
            }

            aircraftModel.Text = aircraft.Model;
            aircraftType.SelectedIndex = (int) aircraft.Type;
            aircraftServiceHours.Text = aircraft.ServiceHours.ToString();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            aircraftModel.SelectAll();
            aircraftModel.Focus();
        }

        public string AircraftModel
        {
            get { return aircraftModel.Text; }
        }

        public AircraftType AirType
        {
            get
            {
                return (AircraftType)aircraftType.SelectedIndex;
            }
        }

        public int AircraftServiceHours
        {
            get
            {
                return int.Parse(aircraftServiceHours.Text);
            }
        }

        public string Airbase
        {
            get
            {
                return airbase.Text;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

