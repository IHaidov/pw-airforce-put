using System;
using System.Collections.Generic;
using System.Linq;
using Alesik.Haidov.Airforce.Interfaces;
using Alesik.Haidov.Airforce.Web.Models;
using Alesik.Haidov.Airforce.BLC;

namespace Alesik.Haidov.Airforce.Web.Services
{
    public class AirbaseService
    {
        private readonly BLC.BLC _blc;

        public AirbaseService(BLC.BLC blc)
        {
            _blc = blc;
            _blc.LoadDatasource("airforce.db");
        }

        public IEnumerable<Airbase> GetAllAirbases()
        {
            return _blc.GetAllAirbases().Select(ab => ConvertToModel(ab));
        }

        public Airbase GetAirbaseById(string guid)
        {
            return ConvertToModel(_blc.GetAirbase(guid).FirstOrDefault());
        }

        public IEnumerable<Airbase> GetAirbaseByName(string name)
        {
            return _blc.GetAirbaseByName(name).Select(ab => ConvertToModel(ab));
        }

        public IEnumerable<Airbase> GetAirbaseByLocation(string location)
        {
            return _blc.GetAirbaseByLocation(location).Select(ab => ConvertToModel(ab));
        }

        public void RemoveAirbase(string guid)
        {
            _blc.RemoveAirbase(guid);
        }

        public void CreateOrUpdateAirbase(Airbase airbase)
        {
            var airbaseInterface = ConvertToInterface(airbase);
            _blc.CreateOrUpdateAirbase(airbaseInterface);
        }

        public static Airbase? ConvertToModel(IAirbase airbase) => airbase == null ? null : new Airbase
        {
            GUID = airbase.GUID,
            Name = airbase.Name,
            Location = airbase.Location
        };

        public static IAirbase? ConvertToInterface(IAirbase airbase)
        {
            return airbase == null ? null : new Airbase
            {
                GUID = airbase.GUID,
                Name = airbase.Name,
                Location = airbase.Location
            };
        }
    }
}