namespace Alesik.Haidov.Airforce.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IAircraft> GetAllAircrafts();
        IEnumerable<IAirbase> GetAllAirbases();

        IAircraft AddNewAircraft(IAircraft aircraft);
        IAirbase AddNewAirbase(IAirbase Airbase);

        void RemoveAirbase(string guid);
        void RemoveAircraft(string guid);

        void UpdateAircraft(IAircraft aircraft);
        void UpdateAircraftBase(IAirbase Airbase);
    }
}
