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


        public void CargaUsers()
        {
            AddUser(1, "Thiago", "Silva", new DateTime(), "61934568764");
            AddUser(2, "Roberto", "Barross", new DateTime(), "61984768764");
            AddUser(3, "Carlos", "Freita", new DateTime(), "61934575844");
            AddUser(4, "Sanssungo", "Lg", new DateTime(), "61934561209");
        }

        public void AddUser(int id, string firstName, string lastName, DateTime date, string phoneNumber)
        {

            _context.Users.Add(new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Id = id,
                PhoneNumber = phoneNumber,
                RegisterDate = date
            });
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
