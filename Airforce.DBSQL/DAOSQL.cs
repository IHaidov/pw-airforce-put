using Alesik.Haidov.Airforce.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Alesik.Haidov.Airforce.DBSQL
{
    public class DAOSQL : DbContext, IDAO
    {
        public DbSet<AircraftDBSQL> AircraftRelation { get; set; }
        public DbSet<AirbaseDBSQL> AirbaseRelation { get; set; }

        public string DbPath { get; }

        public DAOSQL()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join("", "airforce.db");
        }

        public DAOSQL(string dbFilePath)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(dbFilePath);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                    => options.UseSqlite($"Data Source={DbPath}");

        public IAirbase AddNewAirbase(IAirbase airbase)
        {
            airbase.GUID = Guid.NewGuid().ToString();
            Add(new AirbaseDBSQL()
            {
                GUID = airbase.GUID,
                Name = airbase.Name,
                Location = airbase.Location
            });

            SaveChanges();
            return airbase;
        }

        public IAircraft AddNewAircraft(IAircraft aircraft)
        {
            aircraft.GUID = Guid.NewGuid().ToString();
            Add(new AircraftDBSQL()
            {
                GUID = aircraft.GUID,
                Model = aircraft.Model,
                Type = aircraft.Type,
                ServiceHours = aircraft.ServiceHours,
                AirbaseGUID = aircraft.Airbase.GUID
            });

            SaveChanges();
            return aircraft;
        }

        public IEnumerable<IAirbase> GetAllAirbases() => AirbaseRelation.Select(airbase => airbase.ToIAirbase());

        public IEnumerable<IAircraft> GetAllAircrafts() => AircraftRelation.Select(aircraft => aircraft.ToIAircraft(AirbaseRelation.ToList()));

        public void RemoveAirbase(string guid)
        {
            var airbase = AirbaseRelation.FirstOrDefault(airbase => airbase.GUID.Equals(guid));
            Remove(airbase);
            SaveChanges();
        }

        public void RemoveAircraft(string guid)
        {
            var aircraft = AircraftRelation.FirstOrDefault(aircraft => aircraft.GUID.Equals(guid));
            Remove(aircraft);
            SaveChanges();
        }

        public void UpdateAircraft(IAircraft updatedAircraft)
        {
            var aircraft = AircraftRelation.FirstOrDefault(a => a.GUID.Equals(updatedAircraft.GUID));
            aircraft.Model = updatedAircraft.Model;
            aircraft.ServiceHours = updatedAircraft.ServiceHours;
            aircraft.Type = updatedAircraft.Type;
            aircraft.AirbaseGUID = updatedAircraft.Airbase.GUID;

            Entry(aircraft).CurrentValues.SetValues(aircraft);
            SaveChanges();
        }

        public void UpdateAircraftBase(IAirbase updatedAirbase)
        {
            var airbase = AirbaseRelation.FirstOrDefault(a=>a.GUID.Equals(updatedAirbase.GUID));
            airbase.Name = updatedAirbase.Name;
            airbase.Location = updatedAirbase.Location;

            Entry(airbase).CurrentValues.SetValues(airbase);
            SaveChanges();
        }
    }
}
