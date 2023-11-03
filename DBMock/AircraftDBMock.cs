using Alesik.Haidov.Airforce.Core;
using Alesik.Haidov.Airforce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alesik.Haidov.Airforce.AirforceDBMock
{
    [Serializable]
    public class AircraftDBMock : IAircraft
    {
        public string GUID { get; set; }
        public string Model { get; set; }
        public int ServiceHours { get; set; }
        public AircraftType Type { get; set; }
        public IAirforceBase AirforceBase { get; set; }
    }
}
