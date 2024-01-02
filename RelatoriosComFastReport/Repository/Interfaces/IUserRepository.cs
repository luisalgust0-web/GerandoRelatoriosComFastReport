using RelatoriosComFastReport.Models;

namespace RelatoriosComFastReport.Repository.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public User GetUser(int id);
    }
}
