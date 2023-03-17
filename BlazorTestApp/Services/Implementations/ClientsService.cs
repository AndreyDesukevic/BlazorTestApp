using BlazorTestApp.DAL.DbModels;
using BlazorTestApp.DAL.Repositories;
using BlazorTestApp.Services.Interfaces;

namespace BlazorTestApp.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IBaseRepository<Client> _clientRepository;

        public ClientService(IBaseRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public bool Create(Client client)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Client client)
        {
            if(client.Orders.Count==0)
            {
                _clientRepository.Delete(client);
                return true;
            }
            return false;
        }

        public Client Save(Client client)
        {
           return _clientRepository.Update(client);
        }

        public Client GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Client GetById(int id)
        {
            return _clientRepository.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }
    }
}
