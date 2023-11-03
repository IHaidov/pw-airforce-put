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
    internal class AirbaseListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<AirbaseViewModel> Airbases { get; set; } = new ObservableCollection<AirbaseViewModel>();

        public void RefreshList(IEnumerable<IAirbase> airbases)
        {
            Airbases.Clear();
            
            foreach(var airbase in airbases)
            {
                Airbases.Add(new AirbaseViewModel(airbase));
            }

            RaisePropertyChanged(nameof(Airbases));
        }

        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
