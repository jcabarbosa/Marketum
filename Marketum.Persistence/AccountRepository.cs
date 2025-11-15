using Marketum.Domain;

namespace Marketum.Persistence
{
    /// <summary>
    /// Repositório para gestão de contas de utilizador com persistência em ficheiro.
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        private readonly string _filePath = "accounts.txt";
        private List<Account> _accounts;

        public AccountRepository()
        {
            _accounts = LoadFromFile();
        }

        public Account Add(Account account)
        {
            account.Id = _accounts.Count > 0 ? _accounts.Max(a => a.Id) + 1 : 1;
            _accounts.Add(account);
            SaveToFile();
            return account;
        }

        public Account? GetByUsername(string username)
        {
            return _accounts.FirstOrDefault(a => a.Username == username);
        }

        public List<Account> GetAll()
        {
            return new List<Account>(_accounts);
        }


        /// <summary>
        /// Carrega as contas do ficheiro de texto.
        /// </summary>
        private List<Account> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Account>();

            var accounts = new List<Account>();

            foreach (var line in File.ReadAllLines(_filePath))
            {
                var parts = line.Split(';');

                if (parts.Length == 5)
                {
                    accounts.Add(new Account(
                        id: int.Parse(parts[0]),
                        employeeId: int.Parse(parts[1]),
                        username: parts[2],
                        password: parts[3],
                        role: Enum.Parse<UserRole>(parts[4])
                    ));
                }
            }

            return accounts;
        }

        /// <summary>
        /// Guarda as contas no ficheiro de texto.
        /// </summary>
        private void SaveToFile()
        {
            var lines = _accounts.Select(a =>
                $"{a.Id};{a.EmployeeId};{a.Username};{a.Password};{a.Role}");

            File.WriteAllLines(_filePath, lines);
        }
    }
}
