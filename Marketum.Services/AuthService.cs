using Marketum.Domain;
using Marketum.Persistence;

namespace Marketum.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _repository;

        public AuthService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public bool Register(string username, string password, UserRole role)
        {
            if (_repository.GetByUsername(username) != null)
                return false;

            var newAccount = new Account(0, username, password, role);
            _repository.Add(newAccount);
            return true;
        }

        public Account Login(string username, string password)
        {
            var account = _repository.GetByUsername(username);
            if (account == null)
                return null;

            if (account.Password != password)
                return null;

            return account;
        }
    }
}
