namespace Marketum.Domain
{
    /// <summary>
    /// Representa uma conta de utilizador no sistema
    /// </summary>
    public class Account
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRole Role { get; set; }

        public Account(int id, int employeeId, string username, string password, UserRole role)
        {
            Id = id;
            EmployeeId = employeeId;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
