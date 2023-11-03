using Alesik.Haidov.Airforce.Core;
using Alesik.Haidov.Airforce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alesik.Haidov.Airforce.BLC
{
    public class BLC
    {
        private IDAO dao;

        public BLC(string dllPath)
        {
            Type? typeToCreate = null;
            Assembly assembly = Assembly.UnsafeLoadFrom(dllPath);

            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsAssignableTo(typeof(IDAO)))
                {
                    typeToCreate = type;
                    break;
                }
            }

            dao = (IDAO)Activator.CreateInstance(typeToCreate);


        }

        public IEnumerable<IAircraft> GetAllAircrafts()
        {
            return dao.GetAllAircrafts();
        }

        public IEnumerable<IAirforceBase> GetAllAirforceBases()
        {
            return dao.GetAllAirforceBases();
        }

        public IEnumerable<IAircraft> GetAircraft(string guid)
        {
            return dao.GetAllAircrafts().Where(aircraft => aircraft.GUID.Equals(guid));
        }

        public IEnumerable<IAirforceBase> GetAirforceBase(string guid)
        {
            return dao.GetAllAirforceBases().Where(airbase => airbase.GUID.Equals(guid));
        }

        public IEnumerable<IAircraft> GetAircraftByModel(string model)
        {
            return dao.GetAllAircrafts().Where(aircraft => aircraft.Model.Equals(model));
        }

        public IEnumerable<IAircraft> GetAircraft(AircraftType type)
        {
            return dao.GetAllAircrafts().Where(aircraft => aircraft.Type.Equals(type));
        }

        public IEnumerable<IAirforceBase> GetAirforceBaseByName(string name)
        {
            return dao.GetAllAirforceBases().Where(airbase => airbase.Name.Equals(name));
        }

        public void RemoveAircraft(string guid)
        {
            dao.RemoveAircraft(guid);
        }
        public void RemoveAirforceBase(string guid)
        {
            dao.RemoveAirforceBase(guid);
        }

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

        public void CreateOrUpdateAirforceBase(IAirforceBase airbase)
        {
            if (airbase.GUID == null)
            {
                airbase.GUID = Guid.NewGuid().ToString();
                dao.AddNewAirforceBase(airbase);
            }
            else
            {
                dao.UpdateAircraftBase(airbase);
            }
        }

    }
}
