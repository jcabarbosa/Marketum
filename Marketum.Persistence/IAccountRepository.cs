using Marketum.Domain;

namespace Marketum.Persistence
{
    public interface IAccountRepository
    {
        Account GetByUsername(string username);
        Account Add(Account account);
        List<Account> GetAll();
    }
}
