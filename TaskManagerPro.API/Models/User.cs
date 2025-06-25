namespace TaskManagerPro.API.Models
{
    public class User
    {
        public int Id { get; set; }  // Primary Key
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }  // Hashed password
        public byte[] PasswordSalt { get; set; }  // Salt to enhance security
    }
}
