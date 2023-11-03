using Alesik.Haidov.Airforce.Core;
using Alesik.Haidov.Airforce.Interfaces;

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
