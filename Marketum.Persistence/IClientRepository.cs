using Marketum.Domain;

namespace Marketum.Persistence
{
    public interface IClientRepository
    {
        Client Add(Client client);
        List<Client> GetAll();
        Client? GetById(int id);
        void Update(Client client);
        void Delete(int id);
    }
}
