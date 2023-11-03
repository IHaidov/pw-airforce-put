using Alesik.Haidov.Airforce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alesik.Haidov.Airforce.AirforceDBMock
{
    public class DAOMock : IDAO
    {
        private List<IAircraft> aircrafts;
        private List<IAirforceBase> airforceBases;

        public DAOMock()
        {
            airforceBases = new List<IAirforceBase>();

            AddNewAirforceBase(new AirforceBaseDBMock() { GUID = Guid.NewGuid().ToString(), Name = "Hill Air Force Base", Location = "UT"});
            AddNewAirforceBase(new AirforceBaseDBMock() { GUID = Guid.NewGuid().ToString(), Name = "Edwards Air Force Base", Location = "CA" });
            AddNewAirforceBase(new AirforceBaseDBMock() { GUID = Guid.NewGuid().ToString(), Name = "Robins Air Force Base", Location = "GA" });
            
            aircrafts = new List<IAircraft>();

            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "F-16 C/D Fighting Falcon", Type=Core.AircraftType.CAS, ServiceHours = 724, AirforceBase = airforceBases[0] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "B-1 Lancer", Type = Core.AircraftType.Bomber, ServiceHours = 1045, AirforceBase = airforceBases[1] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "C-130 Hercules", Type = Core.AircraftType.Transport, ServiceHours = 365, AirforceBase = airforceBases[1] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "F-35A Lighting II", Type = Core.AircraftType.CAS, ServiceHours = 570, AirforceBase = airforceBases[0] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "C-17 Globemaster III", Type = Core.AircraftType.Transport, ServiceHours = 1600, AirforceBase = airforceBases[2] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "B-2A Spirit", Type = Core.AircraftType.Bomber, ServiceHours = 1540, AirforceBase = airforceBases[0] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "B-21 Raider", Type = Core.AircraftType.Bomber, ServiceHours = 0, AirforceBase = airforceBases[2] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "F-15 C/D Eagle", Type = Core.AircraftType.CAS, ServiceHours = 809, AirforceBase = airforceBases[0] });
        }

        public IAircraft AddNewAircraft(IAircraft aircraft)
        {
            aircrafts.Add(aircraft);
            return aircraft;
        }

        public IAirforceBase AddNewAirforceBase(IAirforceBase airforceBase)
        {
            airforceBases.Add(airforceBase);
            return airforceBase;
        }

        public IEnumerable<IAirforceBase> GetAllAirforceBases() => airforceBases;

        public IEnumerable<IAircraft> GetAllAircrafts() => aircrafts;

        public void RemoveAircraft(string guid) => aircrafts.RemoveAll(aircraft => aircraft.GUID.Equals(guid));

        public void RemoveAirforceBase(string guid) => airforceBases.RemoveAll(airforceBase => airforceBase.GUID.Equals(guid));

        public void UpdateAircraft(IAircraft aircraft)
        {
            var index = aircrafts.FindIndex(currAircraft => currAircraft.GUID.Equals(aircraft.GUID));
            if (index != -1)
            {
                aircrafts[index] = aircraft;
            }
        }


        public void UpdateAircraftBase(IAirforceBase airforceBase)
        {
            var index = airforceBases.FindIndex(currAirforceBase => currAirforceBase.GUID.Equals(airforceBase.GUID));
            if (index != -1)
            {
                airforceBases[index] = airforceBase;
            }
        }
    }
}
