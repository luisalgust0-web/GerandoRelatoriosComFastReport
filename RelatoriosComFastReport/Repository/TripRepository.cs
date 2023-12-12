using Microsoft.EntityFrameworkCore;
using RelatoriosComFastReport.Context;
using RelatoriosComFastReport.Models;
using RelatoriosComFastReport.Repository.Interfaces;

namespace RelatoriosComFastReport.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly InMemoryContext _context;
        public TripRepository(InMemoryContext context) => _context = context;
        
        public void AddTrip(string destiny, DateTime startTrip, DateTime endTrip, int userId, int id)
        {
            _context.Trips.Add(new Trip
            {
                Destiny = destiny,
                StartTrip = startTrip,
                EndTrip = endTrip,
                UserId = userId,
                Id = id
            });

            _context.SaveChanges();
        }

        public void CargaTrip()
        {
            AddTrip("buzios", new DateTime(), new DateTime(), 1, 1);
            AddTrip("fortaleza", new DateTime(), new DateTime(), 2, 2);
            AddTrip("guaruja", new DateTime(), new DateTime(), 2, 3);
            AddTrip("salvador", new DateTime(), new DateTime(), 2, 4);
            AddTrip("brasilia", new DateTime(), new DateTime(), 4, 10);
            AddTrip("mogi das cruzes", new DateTime(), new DateTime(), 2, 5);
            AddTrip("bauru", new DateTime(), new DateTime(), 3, 6);
            AddTrip("capao", new DateTime(), new DateTime(), 3, 7);
            AddTrip("ceilandia", new DateTime(), new DateTime(), 3, 8);
            AddTrip("valparaiso", new DateTime(), new DateTime(), 4, 9);
        }

        public List<Trip> GetAllTrips()
        {
            return _context.Trips.Include(x => x.User).ToList();
        }
    }
}
