using Alesik.Haidov.Airforce.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alesik.Haidov.Airforce.UI.ViewModels
{
    internal class AircraftListViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<AircraftViewModel> Aircrafts { get; set; } = new ObservableCollection<AircraftViewModel>();

        public void RefreshList(IEnumerable<IAircraft> aircrafts)
        {
            Aircrafts.Clear();

            foreach (var airbase in aircrafts)
            {
                Aircrafts.Add(new AircraftViewModel(airbase));
            }

            RaisePropertyChanged(nameof(Aircrafts));
        }

        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
