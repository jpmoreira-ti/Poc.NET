using System.Collections.Generic;
using System.Linq;

namespace WebAPI5.Models
{
    public class ClientRepository
    {
        private readonly List<Client> _clients;

        public ClientRepository()
        {
            _clients = new List<Client>();
            //Instancia uma nova lista de clientes
        }

        public void Add(Client client)
        {
            _clients.Add(client);
        }

        public void Remove(string Document)
        {
            var clientFromList = _clients.FirstOrDefault(c => c.Document == Document);
            _clients.Remove(clientFromList);
        }

        public Client ReturnOne(string Document)
        {
            return _clients.FirstOrDefault(c => c.Document == Document);
        }

        public List<Client> ReturnAll()
        {
            return _clients;
        }
    }
}

