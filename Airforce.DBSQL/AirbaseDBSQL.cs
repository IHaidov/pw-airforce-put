using Alesik.Haidov.Airforce.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alesik.Haidov.Airforce.DBSQL
{
    public class AirbaseDBSQL
    {
        [Key]
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public IAirbase ToIAirbase()
        {
            return new Airbase() { GUID = GUID, Name = Name, Location = Location};
        }
    }
    class Airbase : IAirbase
    {
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
