namespace Alesik.Haidov.Airforce.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IAircraft> GetAllAircrafts();
        IEnumerable<IAirforceBase> GetAllAirforceBases();

        IAircraft AddNewAircraft(IAircraft aircraft);
        IAirforceBase AddNewAirforceBase(IAirforceBase airforceBase);

        void RemoveAirforceBase(string guid);
        void RemoveAircraft(string guid);

        void UpdateAircraft(IAircraft aircraft);
        void UpdateAircraftBase(IAirforceBase airforceBase);
    }
}
