using Marketum.Domain;
using Marketum.Domain.Exceptions;


namespace Marketum.Services
{
    public interface IClientService
    {
        Client AddClient(string name, string taxNr, string email, string phone, string address);
        List<Client> GetAllClients();
        Client GetById(int id);
        void UpdateClient(Client client);
        void RemoveClient(int id);
    }
}
