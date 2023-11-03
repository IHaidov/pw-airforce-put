using Alesik.Haidov.Airforce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
