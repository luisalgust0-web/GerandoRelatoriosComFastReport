using RelatoriosComFastReport.Models;

namespace RelatoriosComFastReport.Repository.Interfaces
{
    public interface IUserRepository
    {
        public void CargaUsers();
        public void AddUser(int id, string firstName, string lastName, DateTime date, string phoneNumber);
        public List<User> GetAllUsers();
        public User GetUser(int id);
    }
}
