using Microsoft.EntityFrameworkCore;
using RelatoriosComFastReport.Context;
using RelatoriosComFastReport.Models;
using RelatoriosComFastReport.Repository.Interfaces;

namespace RelatoriosComFastReport.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly InMemoryContext _context;

        public UserRepository(InMemoryContext context) => _context = context;

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
