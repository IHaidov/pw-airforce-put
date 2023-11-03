using Alesik.Haidov.Airforce.Interfaces;

namespace Alesik.Haidov.Airforce.AirforceDBMock
{
    [Serializable]
    public class AirforceBaseDBMock : IAirforceBase
    {
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
