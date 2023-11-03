using Alesik.Haidov.Airforce.Interfaces;

namespace Alesik.Haidov.Airforce.DBMock
{
    public class DAOMock : IDAO
    {
        private List<IAircraft> aircrafts;
        private List<IAirbase> Airbases;

        public DAOMock()
        {
            Airbases = new List<IAirbase>();

            AddNewAirbase(new AirbaseDBMock() { GUID = Guid.NewGuid().ToString(), Name = "Hill Air Force Base", Location = "UT"});
            AddNewAirbase(new AirbaseDBMock() { GUID = Guid.NewGuid().ToString(), Name = "Edwards Air Force Base", Location = "CA" });
            AddNewAirbase(new AirbaseDBMock() { GUID = Guid.NewGuid().ToString(), Name = "Robins Air Force Base", Location = "GA" });
            
            aircrafts = new List<IAircraft>();

            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "F-16 C/D Fighting Falcon", Type=Core.AircraftType.CAS, ServiceHours = 724, Airbase = Airbases[0] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "B-1 Lancer", Type = Core.AircraftType.Bomber, ServiceHours = 1045, Airbase = Airbases[1] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "C-130 Hercules", Type = Core.AircraftType.Transport, ServiceHours = 365, Airbase = Airbases[1] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "F-35A Lighting II", Type = Core.AircraftType.CAS, ServiceHours = 570, Airbase = Airbases[0] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "C-17 Globemaster III", Type = Core.AircraftType.Transport, ServiceHours = 1600, Airbase = Airbases[2] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "B-2A Spirit", Type = Core.AircraftType.Bomber, ServiceHours = 1540, Airbase = Airbases[0] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "B-21 Raider", Type = Core.AircraftType.Bomber, ServiceHours = 0, Airbase = Airbases[2] });
            AddNewAircraft(new AircraftDBMock() { GUID = Guid.NewGuid().ToString(), Model = "F-15 C/D Eagle", Type = Core.AircraftType.CAS, ServiceHours = 809, Airbase = Airbases[0] });
        }

        public IAircraft AddNewAircraft(IAircraft aircraft)
        {
            aircrafts.Add(aircraft);
            return aircraft;
        }

        public IAirbase AddNewAirbase(IAirbase Airbase)
        {
            Airbases.Add(Airbase);
            return Airbase;
        }

        public IEnumerable<IAirbase> GetAllAirbases() => Airbases;

        public IEnumerable<IAircraft> GetAllAircrafts() => aircrafts;

        public void RemoveAircraft(string guid) => aircrafts.RemoveAll(aircraft => aircraft.GUID.Equals(guid));

        public void RemoveAirbase(string guid) => Airbases.RemoveAll(Airbase => Airbase.GUID.Equals(guid));

        public void UpdateAircraft(IAircraft aircraft)
        {
            var index = aircrafts.FindIndex(currAircraft => currAircraft.GUID.Equals(aircraft.GUID));
            if (index != -1)
            {
                aircrafts[index] = aircraft;
            }
        }


        public void UpdateAircraftBase(IAirbase Airbase)
        {
            var index = Airbases.FindIndex(currAirbase => currAirbase.GUID.Equals(Airbase.GUID));
            if (index != -1)
            {
                Airbases[index] = Airbase;
            }
        }
    }
}
