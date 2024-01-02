namespace RelatoriosComFastReport.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime StartTrip { get; set; }
        public DateTime EndTrip { get; set; }
        public string Destiny { get; set; }
        public int UserId { get; set; }


        public User User { get; set; }

        public Trip(string destiny, DateTime startTrip, DateTime endTrip, int userId, int id)
        {
            Id = id;
            StartTrip = startTrip;
            EndTrip = endTrip;
            Destiny = destiny;
            UserId = userId;
        }
    }
}
