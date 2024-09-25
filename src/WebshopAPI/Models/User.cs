namespace WebshopAPI.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; } // Passwords should be hashed and salted in a real app
    }
}
