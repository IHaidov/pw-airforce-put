using Alesik.Haidov.Airforce.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alesik.Haidov.Airforce.UI.ViewModels
{
    public class AirbaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private IAirbase airbase;

        public AirbaseViewModel(IAirbase airbase)
        {
            this.airbase = airbase;
        }

        public string AirbaseGUID
        {
            get => airbase.GUID;
            set
            {
                airbase.GUID = value;
                RaisePropertyChanged(nameof(AirbaseGUID));
            }
        }

        public string AirbaseName
        {
            get => airbase.Name;
            set
            {
                airbase.Name = value;
                RaisePropertyChanged(nameof(AirbaseName));
            }
        }
        public string AirbaseLocation
        {
            get => airbase.Location;
            set
            {
                airbase.Location = value;
                RaisePropertyChanged(nameof(AirbaseLocation));
            }
        }
        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
