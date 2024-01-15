using Alesik.Haidov.Airforce.Core;
using Alesik.Haidov.Airforce.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Alesik.Haidov.Airforce.DBSQL
{
    public class AircraftDBSQL
    {
        [Key]
        public string GUID { get; set; }
        public string Model { get; set; }
        public int ServiceHours { get; set; }
        public AircraftType Type { get; set; }
        public string AirbaseGUID { get; set; }

        public IAircraft ToIAircraft(List<AirbaseDBSQL> airbases)
        {
            var airbase = airbases.SingleOrDefault(airbase => airbase.GUID.Equals(AirbaseGUID));
            return new Aircraft()
            {
                GUID = GUID,
                Model = Model,
                ServiceHours = ServiceHours,
                Type = Type,
                Airbase = airbase?.ToIAirbase()
            };
        }

    }
    class Aircraft : IAircraft
    {
        public string GUID { get; set; }
        public string Model { get; set; }
        public int ServiceHours { get; set; }
        public AircraftType Type { get; set; }
        public IAirbase Airbase { get; set; }
    }
}
