using Microsoft.EntityFrameworkCore;
using RelatoriosComFastReport.Context;
using RelatoriosComFastReport.Models;
using RelatoriosComFastReport.Repository.Interfaces;

namespace RelatoriosComFastReport.Repository
{
    public class UserTripRelationshipRepository : IUserTripRelationshipRepository
    {
        private readonly InMemoryContext _context;
        private readonly IUserRepository _userRepository;

        public UserTripRelationshipRepository(InMemoryContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public List<UserTripRelationship> GetUserTripRelationship()
        {

            List<UserTripRelationship> userTripRelationships = new List<UserTripRelationship>();
            List<User> users = _userRepository.GetAllUsers();

            foreach (var item in users)
            {
                UserTripRelationship userTripRealationship = new UserTripRelationship();
                User user = _userRepository.GetUser(item.Id);
                userTripRealationship.UserId = user.Id;
                userTripRealationship.FirstName = user.FirstName;
                userTripRealationship.LastName = user.LastName;
                userTripRealationship.NumberTrips = _context.Trips.Where(x => x.UserId == item.Id).Count();

                userTripRelationships.Add(userTripRealationship);
            }

            return userTripRelationships;
        }
    }
}
