namespace OnlineVaccineMVC.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
