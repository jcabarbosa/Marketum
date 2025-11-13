using Marketum.Domain;

namespace Marketum.Services
{
    /// <summary>
    /// Interface para serviços de autenticação
    /// </summary>
    public interface IAuthService
    {
        bool Register(string username, string password, UserRole role);

        Account? Login(string username, string password);
    }
}
