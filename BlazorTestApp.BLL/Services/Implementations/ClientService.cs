using BlazorTestApp.BLL.Models;
using BlazorTestApp.BLL.Services.Interfaces;
using BlazorTestApp.DAL.DbModels;
using BlazorTestApp.DAL.Enum;
using BlazorTestApp.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
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
                    CannotDeleted = IsCannotDeleted(dbClient.Orders),
                    NameUserMadeChange=dbClient.NameUserMadeChange
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
                ClientStatus = ClientStatus.Potential,
                NameUserMadeChange = clientCreateViewModel.NameUserMadeChange
            };
            _clientRepository.Create(dbClient);
        }

        public bool Delete(int idClient,string currentUser)
        {
            var client = _clientRepository.GetById(idClient);
            if (client.Orders.Count == 0)
            {
                client.NameUserMadeChange = currentUser;
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
            dbClient.NameUserMadeChange = clientViewModel.NameUserMadeChange;
            _clientRepository.Update(dbClient);
        }

        public List<HistoryClientViewModel> GetHistoryClient(int idClient)
        {
            
            var dbHistoriesClient = _clientRepository.GetHistoryById(idClient);
            var historyClientViewMidel =new List<HistoryClientViewModel>();
            if (dbHistoriesClient != null)
            {
                historyClientViewMidel = dbHistoriesClient
                               .Select(dbHistoryClient => new HistoryClientViewModel()
                               {
                                   Description = dbHistoryClient.Description,
                                   ClientStatus = dbHistoryClient.ClientStatus,
                                   DateOfChange = EF.Property<DateTime>(dbHistoryClient, "CreatedAt"),
                                   UserName = dbHistoryClient.NameUserMadeChange,
                               }).OrderBy(x => x.DateOfChange).ToList();
                return historyClientViewMidel;
            }
            return historyClientViewMidel.ToList();
        }

        public ClientViewModel GetById(int id) => GetAll().FirstOrDefault(client => client.Id == id);

        public ClientViewModel GetByName(string name) => GetAll().FirstOrDefault(client => client.Name == name);
        private static bool IsCanBeNotActive(List<Order> orders) => orders.Any(x => x.OrderStatus == OrderStatus.New);
        private static bool IsCannotDeleted(List<Order> orders) => orders.Count!=0;



    }
}
