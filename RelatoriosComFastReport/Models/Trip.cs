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
    }
}
