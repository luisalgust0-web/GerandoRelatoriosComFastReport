using RelatoriosComFastReport.Models;

namespace RelatoriosComFastReport.Context.Repository
{
    public class GeneralRepository
    {

        public GeneralRepository()
        {
            using (InMemoryContext context = new())
            {
                //Carga Inicial de Viagens
                AddTrip(context, "buzios", new DateTime(), new DateTime(), 1, 1);
                AddTrip(context, "fortaleza", new DateTime(), new DateTime(), 1, 2);
                AddTrip(context, "buzios", new DateTime(), new DateTime(), 2, 3);
                AddTrip(context, "buzios", new DateTime(), new DateTime(), 2, 4);
                AddTrip(context, "buzios", new DateTime(), new DateTime(), 2, 5);
                AddTrip(context, "buzios", new DateTime(), new DateTime(), 3, 6);
                AddTrip(context, "buzios", new DateTime(), new DateTime(), 3, 7);
                AddTrip(context, "buzios", new DateTime(), new DateTime(), 3, 8);
                AddTrip(context, "buzios", new DateTime(), new DateTime(), 4, 9);
                AddTrip(context, "buzios", new DateTime(), new DateTime(), 4, 10);

                //Carga Inicail de Usuarios
                AddUser(context, 1, "Thiago", "Silva", new DateTime(), "61934568764");
                AddUser(context, 2, "Roberto", "Barross", new DateTime(), "61984768764");
                AddUser(context, 3, "Carlos", "Freita", new DateTime(), "61934575844");
                AddUser(context, 4, "Sanssungo", "Lg", new DateTime(), "61934561209");

                context.SaveChanges();
            };
        }

        public void AddTrip(InMemoryContext context, string destiny, DateTime startTrip, DateTime endTrip, int userId, int id)
        {
            context.Trips.Add(new Trips()
            {
                Destiny = destiny,
                StartTrip = startTrip,
                EndTrip = endTrip,
                UserId = userId,
                Id = id
            });
        }

        public List<Trips> GetAllTrips()
        {
            using(InMemoryContext context = new())
            {
                return context.Trips.ToList();
            }
        }

        public void AddUser(InMemoryContext context, int id, string firstName, string lastName, DateTime registerDate, string phoneNumber)
        {
            context.Users.Add(new User()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                RegisterDate = registerDate,
                PhoneNumber = phoneNumber
            });
        }

        public List<User> GetAllUsers()
        {
            using (InMemoryContext context = new())
            {
                return context.Users.ToList();
            }
        }
    }
}
