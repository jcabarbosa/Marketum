using Marketum.Domain;
using Marketum.Domain.Exceptions;


namespace Marketum.Services
{
    /// <summary>
    /// Interface para serviços de autenticação
    /// </summary>
    public interface IAuthService
    {
        bool Register(int employeeId, string username, string password, UserRole role);

        Account? Login(string username, string password);
        
        List<Account> GetAllAccounts();
    }
}
