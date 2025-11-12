using Marketum.Domain;

namespace Marketum.Services
{
    public interface IAuthService
    {
        bool Register(string username, string password, UserRole role);
        Account Login(string username, string password);
    }
}
