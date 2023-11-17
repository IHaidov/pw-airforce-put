using Alesik.Haidov.Airforce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alesik.Haidov.Airforce.DBFile
{
    [Serializable]
    internal class AirbaseDBFile : IAirbase
    {
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
