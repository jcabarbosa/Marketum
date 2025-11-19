using Marketum.Domain;
using Marketum.Domain.Exceptions;
using Marketum.Persistence;

namespace Marketum.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public Client AddClient(string name, string taxNr, string email, string phone, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("O nome do cliente é obrigatório.");

            if (string.IsNullOrWhiteSpace(taxNr))
                throw new ValidationException("O NIF é obrigatório.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ValidationException("O email é obrigatório.");

            var client = new Client
            {
                Name = name,
                TaxNr = taxNr,
                Email = email,
                Phone = phone,
                Address = address
            };

            return _repository.Add(client);
        }

        public List<Client> GetAllClients()
        {
            return _repository.GetAll();
        }

        public Client GetById(int id)
        {
            var client = _repository.GetById(id);
            if (client == null)
                throw new NotFoundException($"Cliente com o ID {id} não encontrado.");

            return client;
        }

        public void UpdateClient(Client client)
        {
            var exists = _repository.GetById(client.Id);
            if (exists == null)
                throw new NotFoundException($"Cliente com o ID {client.Id} não existe.");

            _repository.Update(client);
        }

        public void RemoveClient(int id)
        {
            var exists = _repository.GetById(id);
            if (exists == null)
                throw new NotFoundException($"Cliente com o ID {id} não existe.");

            _repository.Delete(id);
        }
    }
}
