using System;
using System.Collections.Generic;
using System.Linq;
using Alesik.Haidov.Airforce.Core;
using Alesik.Haidov.Airforce.Interfaces;
using Alesik.Haidov.Airforce.Web.Models;
using Alesik.Haidov.Airforce.BLC;

namespace Alesik.Haidov.Airforce.Web.Services {
    public class AircraftService
    {
        private readonly BLC.BLC _blc;

        public AircraftService(BLC.BLC blc)
        {
            _blc = blc;
        }

        public IEnumerable<Aircraft> GetAllAircrafts()
        {
            return _blc.GetAllAircrafts().Select(a => ConvertToModel(a));
        }

        public Aircraft GetAircraftById(string guid)
        {
            return ConvertToModel(_blc.GetAircraft(guid).FirstOrDefault());
        }

        public IEnumerable<Aircraft> GetAircraftByModel(string model)
        {
            return _blc.GetAircraftByModel(model).Select(a => ConvertToModel(a));
        }

        public IEnumerable<Aircraft> GetAircraftByType(AircraftType type)
        {
            return _blc.GetAircraft(type).Select(a => ConvertToModel(a));
        }

        public IEnumerable<Aircraft> GetAircraftByServiceHours(int serviceHours)
        {
            return _blc.GetAircraft(serviceHours).Select(a => ConvertToModel(a));
        }

        public IEnumerable<Aircraft> GetAircraftByBaseName(string baseName)
        {
            return _blc.GetAircraftByBaseName(baseName).Select(a => ConvertToModel(a));
        }

        public IEnumerable<Aircraft> GetAircraftByBaseLocation(string baseLocation)
        {
            return _blc.GetAircraftByBaseLocation(baseLocation).Select(a => ConvertToModel(a));
        }

        public void RemoveAircraft(string guid)
        {
            _blc.RemoveAircraft(guid);
        }

        public void CreateOrUpdateAircraft(Aircraft aircraft)
        {
            var aircraftInterface = ConvertToInterface(aircraft);
            _blc.CreateOrUpdateAircraft(aircraftInterface);
        }

        private Aircraft? ConvertToModel(IAircraft aircraft)
        {
            return aircraft == null ? null : new Aircraft
            {
                GUID = aircraft.GUID,
                Model = aircraft.Model,
                ServiceHours = aircraft.ServiceHours,
                Type = aircraft.Type,
                Airbase = AirbaseService.ConvertToModel(aircraft.Airbase)
            };
        }

        private IAircraft? ConvertToInterface(Aircraft aircraft)
        {
            return aircraft == null ? null : new Aircraft // Assuming you have an implementation of IAircraft
            {
                GUID = aircraft.GUID,
                Model = aircraft.Model,
                ServiceHours = aircraft.ServiceHours,
                Type = aircraft.Type,
                Airbase = AirbaseService.ConvertToInterface(aircraft.Airbase)
            };
        }
    }
}
