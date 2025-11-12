using Marketum.Domain;

namespace Marketum.Persistence
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string _filePath = "accounts.txt";
        private List<Account> _accounts;

        public AccountRepository()
        {
            _accounts = LoadFromFile();
        }

        public Account GetByUsername(string username)
        {
            return _accounts.FirstOrDefault(a => a.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public Account Add(Account account)
        {
            account.Id = _accounts.Count > 0 ? _accounts.Max(a => a.Id) + 1 : 1;
            _accounts.Add(account);
            SaveToFile();
            return account;
        }

        public List<Account> GetAll()
        {
            return new List<Account>(_accounts);
        }

        private List<Account> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Account>();

            var accounts = new List<Account>();
            foreach (var line in File.ReadAllLines(_filePath))
            {
                var parts = line.Split(';');
                if (parts.Length == 4)
                {
                    accounts.Add(new Account(
                        int.Parse(parts[0]),
                        parts[1],
                        parts[2],
                        (UserRole)int.Parse(parts[3])
                    ));
                }
            }
            return accounts;
        }

        private void SaveToFile()
        {
            var lines = _accounts.Select(a => $"{a.Id};{a.Username};{a.Password};{(int)a.Role}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}
