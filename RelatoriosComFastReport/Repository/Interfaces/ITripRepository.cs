using RelatoriosComFastReport.Models;

namespace RelatoriosComFastReport.Repository.Interfaces
{
    public interface ITripRepository
    {
        public List<Trip> GetAllTrips();
    }
}
