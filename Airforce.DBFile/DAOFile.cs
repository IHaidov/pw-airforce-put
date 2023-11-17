using Alesik.Haidov.Airforce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alesik.Haidov.Airforce.DBFile
{
    internal class DAOFile : IDAO
    {
        private List<IAircraft> aircrafts;
        private List<IAirbase> airbases;

        private const string FILE_AIRCRAFTS = "aircrafts.bin";
        private const string FILE_AIRBASES = "airbases.bin";

        public DAOFile()
        {
            try
            {
                aircrafts = Serializer.Deserialize<IAircraft>(FILE_AIRCRAFTS);
                airbases = Serializer.Deserialize<IAirbase>(FILE_AIRBASES);
            }
            catch (Exception)
            {
                airbases = new List<IAirbase>();

                AddNewAirbase(new AirbaseDBFile() { GUID = Guid.NewGuid().ToString(), Name = "Hill Air Force Base", Location = "UT" });
                AddNewAirbase(new AirbaseDBFile() { GUID = Guid.NewGuid().ToString(), Name = "Edwards Air Force Base", Location = "CA" });
                AddNewAirbase(new AirbaseDBFile() { GUID = Guid.NewGuid().ToString(), Name = "Robins Air Force Base", Location = "GA" });
                AddNewAirbase(new AirbaseDBFile() { GUID = Guid.NewGuid().ToString(), Name = "North Dakota Air Force Base", Location = "ND" });
                AddNewAirbase(new AirbaseDBFile() { GUID = Guid.NewGuid().ToString(), Name = "Florida Air Force Base", Location = "FL" });

                SaveAirbases();

                aircrafts = new List<IAircraft>();
                
                AddNewAircraft(new AircraftDBFile() { GUID = Guid.NewGuid().ToString(), Model = "F-16 C/D Fighting Falcon", Type = Core.AircraftType.CAS, ServiceHours = 724, Airbase = airbases[0] });
                AddNewAircraft(new AircraftDBFile() { GUID = Guid.NewGuid().ToString(), Model = "B-1 Lancer", Type = Core.AircraftType.Bomber, ServiceHours = 1045, Airbase = airbases[1] });
                AddNewAircraft(new AircraftDBFile() { GUID = Guid.NewGuid().ToString(), Model = "B-21 Raider 'Jimbo'", Type = Core.AircraftType.Bomber, ServiceHours = 0, Airbase = airbases[0] });
                AddNewAircraft(new AircraftDBFile() { GUID = Guid.NewGuid().ToString(), Model = "F-15 C/D Eagle 'Connor'", Type = Core.AircraftType.CAS, ServiceHours = 809, Airbase = airbases[3] });
                AddNewAircraft(new AircraftDBFile() { GUID = Guid.NewGuid().ToString(), Model = "C-130 Hercules", Type = Core.AircraftType.Transport, ServiceHours = 365, Airbase = airbases[1] });
                AddNewAircraft(new AircraftDBFile() { GUID = Guid.NewGuid().ToString(), Model = "F-35A Lighting II", Type = Core.AircraftType.CAS, ServiceHours = 570, Airbase = airbases[0] });
                AddNewAircraft(new AircraftDBFile() { GUID = Guid.NewGuid().ToString(), Model = "C-17 Globemaster III", Type = Core.AircraftType.Transport, ServiceHours = 1600, Airbase = airbases[2] });
                AddNewAircraft(new AircraftDBFile() { GUID = Guid.NewGuid().ToString(), Model = "B-2A Spirit", Type = Core.AircraftType.Bomber, ServiceHours = 1540, Airbase = airbases[0] });
                AddNewAircraft(new AircraftDBFile() { GUID = Guid.NewGuid().ToString(), Model = "B-21 Raider", Type = Core.AircraftType.Bomber, ServiceHours = 0, Airbase = airbases[2] });
                AddNewAircraft(new AircraftDBFile() { GUID = Guid.NewGuid().ToString(), Model = "F-15 C/D Eagle", Type = Core.AircraftType.CAS, ServiceHours = 809, Airbase = airbases[0] });

                SaveAircrafts();
            }

        }

        private void SaveAircrafts()
        {
            Serializer.Serialize(FILE_AIRCRAFTS, aircrafts);
        }

        private void SaveAirbases()
        {
            Serializer.Serialize(FILE_AIRBASES, airbases);
        }

        public IAircraft AddNewAircraft(IAircraft aircraft)
        {
            aircraft.GUID = Guid.NewGuid().ToString();
            aircrafts.Add(aircraft);
            SaveAircrafts();
            return aircraft;
        }

        public IAirbase AddNewAirbase(IAirbase airbase)
        {
            airbase.GUID = Guid.NewGuid().ToString();
            airbases.Add(airbase);
            SaveAirbases();
            return airbase;
        }

        public IEnumerable<IAirbase> GetAllAirbases() => airbases;

        public IEnumerable<IAircraft> GetAllAircrafts() => aircrafts;

        public void RemoveAircraft(string guid)
        {
            aircrafts.RemoveAll(aircraft => aircraft.GUID.Equals(guid));
            SaveAircrafts();
        }

        public void RemoveAirbase(string guid)
        {
            airbases.RemoveAll(Airbase => Airbase.GUID.Equals(guid));
            SaveAirbases();
        }

        public void UpdateAircraft(IAircraft aircraft)
        {
            var index = aircrafts.FindIndex(currAircraft => currAircraft.GUID.Equals(aircraft.GUID));
            if (index != -1)
            {
                aircrafts[index] = aircraft;
            }
            SaveAircrafts();
        }

        public void UpdateAircraftBase(IAirbase Airbase)
        {
            var index = airbases.FindIndex(currAirbase => currAirbase.GUID.Equals(Airbase.GUID));
            if (index != -1)
            {
                airbases[index] = Airbase;
            }
            SaveAirbases();
        }
    }
}
