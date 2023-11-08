using Alesik.Haidov.Airforce.Core;
using Alesik.Haidov.Airforce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
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
using BL = Alesik.Haidov.Airforce.BLC;

namespace Alesik.Haidov.Airforce.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModels.AirbaseListViewModel AirbaseLVM { get; } = new ViewModels.AirbaseListViewModel();
        private ViewModels.AirbaseViewModel selectedAirbase = null;

        public ViewModels.AircraftListViewModel AircraftLVM { get; } = new ViewModels.AircraftListViewModel();
        private ViewModels.AircraftViewModel selectedAircraft = null;

        private readonly BL.BLC blc;

        private string selectedDataSource = "Airforce.DBMock.dll";

        public MainWindow()
        {
            blc = new BL.BLC(selectedDataSource);

            AirbaseLVM.RefreshList(blc.GetAllAirbases());
            AircraftLVM.RefreshList(blc.GetAllAircrafts());

            InitializeComponent();
        }

        private void AircraftList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                ChangeSelectedAircraft((ViewModels.AircraftViewModel)e.AddedItems[0]);
            }
        }

        #region Filters
        private void ApplyFilter(object sender, RoutedEventArgs e)
        {
            // First, determine the selected filter type from the ComboBox.
            var selectedFilter = filterTypeComboBox.SelectedItem as ComboBoxItem;

            if (selectedFilter == null)
            {
                // Handle the case where no filter is selected, if necessary.
                AircraftLVM.RefreshList(blc.GetAllAircrafts());
            }

            // Retrieve the filter value entered by the user.
            string filterValue = filterValueTextBox.Text;

            if (string.IsNullOrWhiteSpace(filterValue))
            {
                // Handle the case where the filter value is empty, if necessary.
                AircraftLVM.RefreshList(blc.GetAllAircrafts());
            }

            // Apply the filter based on the selected filter type.
            switch (selectedFilter.Content.ToString())
            {
                case "service hours":
                    FilterByServiceHours(filterValue);
                    break;
                case "model name":
                    FilterByModelName(filterValue);
                    break;
                case "aircraft type":
                    FilterByAircraftType(filterValue);
                    break;
                case "airbase name":
                    FilterByAirbases(filterValue);
                    break;
                case "airbase location":
                    FilterByAirbasesLocation(filterValue);
                    break;
                default:
                    // Handle unexpected filter type, if necessary.
                    MessageBox.Show("Unknown filter type selected.");
                    break;
            }
        }

        private void FilterByServiceHours(string hours)
        {
            if (hours == "")
            {
                AircraftLVM.RefreshList(blc.GetAllAircrafts());
            }
            else
            {
                AircraftLVM.RefreshList(blc.GetAircraft(Convert.ToInt32(hours)));
            }
        }

        private void FilterByModelName(string modelName)
        {
            if (modelName == "")
            {
                AircraftLVM.RefreshList(blc.GetAllAircrafts());
            }
            else
            {
                AircraftLVM.RefreshList(blc.GetAircraftByModel(modelName));
            }
        }

        private void FilterByAircraftType(string modelType)
        {
            if (modelType == "")
            {
                AircraftLVM.RefreshList(blc.GetAllAircrafts());
            }
            else
            {
                AircraftType type;
                Enum.TryParse<AircraftType>(modelType,out type);
                AircraftLVM.RefreshList(blc.GetAircraft(type));
            }
        }

        private void FilterByAirbases(string airbase)
        {
            if (airbase == "")
            {
                AircraftLVM.RefreshList(blc.GetAllAircrafts());
            }
            else
            {
                AircraftLVM.RefreshList(blc.GetAircraftByBaseName(airbase));
            }
        }

        private void FilterByAirbasesLocation(string airbaseLocation)
        {
            if (airbaseLocation == "")
            {
                AircraftLVM.RefreshList(blc.GetAllAircrafts());
            }
            else
            {
                AircraftLVM.RefreshList(blc.GetAircraftByBaseLocation(airbaseLocation));
            }
        }

        #endregion

        private void ApplyAircraftSearch(object sender, RoutedEventArgs e)
        {
            // First, determine the selected filter type from the ComboBox.
            var selectedFilter = searchTypeComboBox.SelectedItem as ComboBoxItem;

            if (selectedFilter == null)
            {
                // Handle the case where no filter is selected, if necessary.
                AircraftLVM.RefreshList(blc.GetAllAircrafts());
            }

            // Retrieve the filter value entered by the user.
            string filterValue = aircraftSearchField.Text;

            if (string.IsNullOrWhiteSpace(filterValue))
            {
                // Handle the case where the filter value is empty, if necessary.
                AircraftLVM.RefreshList(blc.GetAllAircrafts());
            }

            // Apply the filter based on the selected filter type.
            switch (selectedFilter.Content.ToString())
            {
                case "service hours":
                    FilterByServiceHours(filterValue);
                    break;
                case "model name":
                    FilterByModelName(filterValue);
                    break;
                case "aircraft type":
                    FilterByAircraftType(filterValue);
                    break;
                case "airbase name":
                    FilterByAirbases(filterValue);
                    break;
                case "airbase location":
                    FilterByAirbasesLocation(filterValue);
                    break;
                default:
                    // Handle unexpected filter type, if necessary.
                    MessageBox.Show("Unknown filter type selected.");
                    break;
            }

            if (AircraftList.Items.Count > 0)
            {
                AircraftList.SelectedItem = AircraftList.Items[0];

            }
        }

        


        private void ApplyNewDataSource(object sender, RoutedEventArgs e)
        {
            try
            {
                blc.LoadLibrary(datasource.Text);
                AirbaseLVM.RefreshList(blc.GetAllAirbases());
                AircraftLVM.RefreshList(blc.GetAllAircrafts());
                selectedDataSource = datasource.Text;
            }
            catch
            {
                MessageBox.Show("Error occurred, check your input values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                blc.LoadLibrary(selectedDataSource);
            }
        }

        private void EditAircraft(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveAircraft(object sender, RoutedEventArgs e)
        {

        }

        private void AddAircraft(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeSelectedAircraft(ViewModels.AircraftViewModel aircraftViewModel)
        {
            selectedAircraft = aircraftViewModel;
            DataContext = selectedAircraft;
        }

        private void ChangeSelectedAirbase(ViewModels.AirbaseViewModel airbaseViewModel)
        {
            selectedAirbase = airbaseViewModel;
            DataContext = selectedAirbase;
        }
    }
}
