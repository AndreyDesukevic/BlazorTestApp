using BlazorTestApp.BLL.Models;
using BlazorTestApp.BLL.Services.Interfaces;
using BlazorTestApp.DAL.DbModels;
using BlazorTestApp.DAL.Enum;
using BlazorTestApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IBaseRepository<Client> _clientRepository;

        public ClientService(IBaseRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<ClientViewModel> GetAll()
        {
            var dbClients = _clientRepository.GetAll();
            var viewModels = dbClients
                .Select(dbClient => new ClientViewModel()
                {
                    Id = dbClient.Id,
                    Name = string.Join(" ", new string[] { dbClient.FirstName, dbClient.LastName }),
                    Description = dbClient.Description,
                    OrdersId = dbClient.Orders.Select(order => order.Id).ToList(),
                    ClientStatus = dbClient.ClientStatus,
                    DateCreate = dbClient.DateCreate,
                    CannotBeNotActive = IsCanBeNotActive(dbClient.Orders),
                    CannotDeleted = IsCannotDeleted(dbClient.Orders)
                });
            return viewModels;
        }

        public void Create(ClientCreateViewModel clientCreateViewModel)
        {

            var dbClient = new Client()
            {
                FirstName = clientCreateViewModel.FirstName,
                LastName = clientCreateViewModel.LastName,
                Description = clientCreateViewModel.Description,
                DateCreate = DateTime.Now,
                ClientStatus = ClientStatus.Potential
            };
            _clientRepository.Create(dbClient);
        }

        public bool Delete(int id)
        {
            var client = _clientRepository.GetById(id);
            if (client.Orders.Count == 0)
            {
                _clientRepository.Delete(client);
                return true;
            }
            return false;
        }

        public void Save(ClientViewModel clientViewModel)
        {
            var dbClient = _clientRepository.GetAll().FirstOrDefault(client=>client.Id==clientViewModel.Id);
            dbClient.ClientStatus = clientViewModel.ClientStatus;
            dbClient.Description = clientViewModel.Description;
            _clientRepository.Update(dbClient);
        }

        public ClientViewModel GetById(int id) => GetAll().FirstOrDefault(client => client.Id == id);

        public ClientViewModel GetByName(string name) => GetAll().FirstOrDefault(client => client.Name == name);
        public static bool IsCanBeNotActive(List<Order> orders) => orders.Any(x => x.OrderStatus == OrderStatus.New);
        public static bool IsCannotDeleted(List<Order> orders) =>orders.Count!=0 ;



    }
}
