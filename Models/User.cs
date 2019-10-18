namespace DatingApp.API.Models
{
    public class User
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[] passwordSalt { get; set; }
    }
}