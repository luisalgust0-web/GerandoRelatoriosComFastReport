using RelatoriosComFastReport.Models;

namespace RelatoriosComFastReport.Repository.Interfaces
{
    public interface IUserTripRelationshipRepository
    {
        public List<UserTripRelationship> GetUsersTripRelationship();
    }
}
