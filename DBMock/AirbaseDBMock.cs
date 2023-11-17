using Alesik.Haidov.Airforce.Interfaces;

namespace Alesik.Haidov.Airforce.DBMock
{
    [Serializable]
    public class AirbaseDBMock : IAirbase
    {
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
