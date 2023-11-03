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
    public class AircraftViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private IAircraft aircraft;

        public AircraftViewModel(IAircraft aircraft)
        {
            this.aircraft = aircraft;
        }

        public string AircraftGUID
        {
            get => aircraft.GUID;
            set
            {
                aircraft.GUID = value;
                RaisePropertyChanged(nameof(AircraftGUID));
            }
        }

        public string AircraftModel
        {
            get => aircraft.Model;
            set
            {
                aircraft.Model = value;
                RaisePropertyChanged(nameof(AircraftModel));
            }
        }

        public int AircraftServiceHours
        {
            get => aircraft.ServiceHours;
            set
            {
                aircraft.ServiceHours = value;
                RaisePropertyChanged(nameof(AircraftServiceHours));
            }
        }

        public Core.AircraftType AircraftType
        {
            get => aircraft.Type;
            set
            {
                aircraft.Type = value;
                RaisePropertyChanged(nameof(AircraftType));
            }
        }

        public string AircraftBase
        {
            get => aircraft.Airbase.Name;
            set
            {
                aircraft.Airbase.Name = value;
                RaisePropertyChanged(nameof(AircraftBase));
            }
        }

        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
