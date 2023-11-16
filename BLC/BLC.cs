using Alesik.Haidov.Airforce.Core;
using Alesik.Haidov.Airforce.Interfaces;
using System.Reflection;

namespace Alesik.Haidov.Airforce.BLC
{
    public class BLC
    {
        private IDAO dao;

        public BLC(string dllPath)
        {
            LoadLibrary(dllPath);
        }

        public void LoadLibrary(string dllPath)
        {
            var typeToCreate = FindDAOType(dllPath);

            if (typeToCreate != null)
            {
                dao = CreateDAOInstance(typeToCreate);
            }
            else
            {
                throw new InvalidOperationException("No compatible IDAO type found in assembly.");
            }
        }

        #region Handle DAO 
        private Type FindDAOType(string dllPath)
        {
            try
            {
                var assembly = Assembly.UnsafeLoadFrom(dllPath);
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(IDAO).IsAssignableFrom(type))
                    {
                        return type;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load assembly or find IDAO: " + ex.Message);
                throw;
            }

            return null;
        }

        private IDAO CreateDAOInstance(Type daoType)
        {
            try
            {
                return (IDAO)Activator.CreateInstance(daoType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create instance of IDAO: {daoType.Name}\n{ex.Message}");
                throw;
            }
        }
        #endregion

        public IEnumerable<IAircraft> GetAllAircrafts() => dao.GetAllAircrafts();

        public IEnumerable<IAirbase> GetAllAirbases() => dao.GetAllAirbases();

        public IEnumerable<IAircraft> GetAircraft(string guid) => dao.GetAllAircrafts().Where(aircraft => aircraft.GUID.Equals(guid));

        public IEnumerable<IAirbase> GetAirbase(string guid) => dao.GetAllAirbases().Where(airbase => airbase.GUID.Equals(guid));

        public IEnumerable<IAircraft> GetAircraftByModel(string model) => dao.GetAllAircrafts().Where(aircraft => aircraft.Model.Contains(model));

        public IEnumerable<IAircraft> GetAircraft(AircraftType type) => dao.GetAllAircrafts().Where(aircraft => aircraft.Type.Equals(type));

        public IEnumerable<IAircraft> GetAircraft(int serviceHours) => dao.GetAllAircrafts().Where(aircraft => aircraft.ServiceHours.Equals(serviceHours));

        public IEnumerable<IAircraft> GetAircraftByBaseName(string baseName) => dao.GetAllAircrafts().Where(aircraft => aircraft.Airbase.Name.Contains(baseName));

        public IEnumerable<IAircraft> GetAircraftByBaseLocation(string baseLocation) => dao.GetAllAircrafts().Where(aircraft => aircraft.Airbase.Location.Contains(baseLocation));

        public IEnumerable<IAirbase> GetAirbaseByName(string name) => dao.GetAllAirbases().Where(airbase => airbase.Name.Contains(name));
        public IEnumerable<IAirbase> GetAirbaseByLocation(string name) => dao.GetAllAirbases().Where(airbase => airbase.Location.Contains(name));

        public void RemoveAircraft(string guid) => dao.RemoveAircraft(guid);

        public void RemoveAirbase(string guid) => dao.RemoveAirbase(guid);

        public void CreateOrUpdateAircraft(IAircraft aircraft)
        {
            if (aircraft.GUID == null)
            {
                aircraft.GUID = Guid.NewGuid().ToString();
                dao.AddNewAircraft(aircraft);
            }
            else
            {
                dao.UpdateAircraft(aircraft);
            }
        }

        public void CreateOrUpdateAirbase(IAirbase airbase)
        {
            if (airbase.GUID == null)
            {
                airbase.GUID = Guid.NewGuid().ToString();
                dao.AddNewAirbase(airbase);
            }
            else
            {
                dao.UpdateAircraftBase(airbase);
            }
        }

        public IEnumerable<string> GetAllAirbasesNames() => from airbase in dao.GetAllAirbases() select airbase.Name;

    }
}
