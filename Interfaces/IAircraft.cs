using Alesik.Haidov.Airforce.Core;

namespace Alesik.Haidov.Airforce.Interfaces
{
    public interface IAircraft
    {
        string GUID { get; set; }
        string Model { get; set; }
        int ServiceHours { get; set; }
        AircraftType Type { get; set; }
        IAirbase Airbase { get; set; }

    }
}
