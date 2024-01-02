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
        
        public List<Trip> GetAllTrips()
        {
            return _context.Trips.Include(x => x.User).ToList();
        }
    }
}
