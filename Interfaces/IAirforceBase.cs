using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alesik.Haidov.Airforce.Interfaces
{
    public interface IAirforceBase
    {
        string GUID { get; set; }
        string Name { get; set; }
        string Location { get; set; }
    }
}
