using Marketum.Domain;

namespace Marketum.Persistence
{
    /// <summary>
    /// Repositório para gestão de clientes com persistência em ficheiro.
    /// </summary>
    public class ClientRepository : IClientRepository
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clients.txt");
        private List<Client> _clients;

        public ClientRepository()
        {
            _clients = LoadFromFile();
        }

        public Client Add(Client client)
        {
            client.Id = _clients.Count > 0 ? _clients.Max(c => c.Id) + 1 : 1;
            _clients.Add(client);
            SaveToFile();
            return client;
        }

        public List<Client> GetAll()
        {
            return new List<Client>(_clients);
        }

        public Client? GetById(int id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Client client)
        {
            var existing = _clients.FirstOrDefault(c => c.Id == client.Id);
            if (existing == null) return;

            existing.Name = client.Name;
            existing.TaxNr = client.TaxNr;
            existing.Email = client.Email;
            existing.Phone = client.Phone;
            existing.Address = client.Address;

            SaveToFile();
        }

        public void Delete(int id)
        {
            var c = _clients.FirstOrDefault(x => x.Id == id);
            if (c == null) return;

            _clients.Remove(c);
            SaveToFile();
        }


        /// <summary>
        /// Carrega os clientes do ficheiro de texto.
        /// </summary>
        private List<Client> LoadFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Client>();

            var clients = new List<Client>();
            foreach (var line in File.ReadAllLines(_filePath))
            {
                var parts = line.Split(';');
                if (parts.Length == 6)
                {
                    clients.Add(new Client
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        TaxNr = parts[2],
                        Email = parts[3],
                        Phone = parts[4],
                        Address = parts[5]
                    });
                }
            }
            return clients;
        }

        /// <summary>
        /// Guarda os clientes no ficheiro de texto.
        /// </summary>
        private void SaveToFile()
        {
            var lines = _clients.Select(c => $"{c.Id};{c.Name};{c.TaxNr};{c.Email};{c.Phone};{c.Address}");
            File.WriteAllLines(_filePath, lines);
        }
    }
}
