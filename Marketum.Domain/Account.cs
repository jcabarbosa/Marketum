namespace Marketum.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public Account(int id, string username, string password, UserRole role)
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
