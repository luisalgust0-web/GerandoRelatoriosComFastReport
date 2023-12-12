using RelatoriosComFastReport.Models;

namespace RelatoriosComFastReport.Repository.Interfaces
{
    public interface ITripRepository
    {
        public void CargaTrip();
        public void AddTrip(string destiny, DateTime startTrip, DateTime endTrip, int userId, int id);
        public List<Trip> GetAllTrips();
    }
}
