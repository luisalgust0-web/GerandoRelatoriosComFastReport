namespace RelatoriosComFastReport.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public string PhoneNumber { get; set; }

        public User(int id, string firstName, string lastName, DateTime registerDate, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            RegisterDate = registerDate;
            PhoneNumber = phoneNumber;
        }
    }
}
