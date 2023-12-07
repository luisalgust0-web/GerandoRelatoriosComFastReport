namespace RelatoriosComFastReport.Models
{
    public class Trips
    {
        public int Id { get; set; }
        public DateTime StartTrip { get; set; }
        public DateTime EndTrip { get; set; }
        public string Destiny { get; set; }


        public int UserId { get; set; }
        public User user { get; set; }
    }
}
