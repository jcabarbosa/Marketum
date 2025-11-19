using Marketum.Domain;
using Marketum.Persistence;
using Marketum.Domain.Exceptions;


namespace Marketum.Services
{
    /// <summary>
    /// Implementação do serviço de autenticação
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _repository;

        public AuthService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public bool Register(int employeeId, string username, string password, UserRole role)
        {
            if (_repository.GetByUsername(username) != null)
                return false;

            var newAccount = new Account(
                id: 0,
                employeeId: employeeId,
                username: username,
                password: password,
                role: role
            );

            _repository.Add(newAccount);
            return true;
        }

        /// <summary>
        /// Autentica o utilizador verificando as credenciais
        /// </summary>
        /// <returns>Account do utilizador ou null se falhar</returns>
        public Account? Login(string username, string password)
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
