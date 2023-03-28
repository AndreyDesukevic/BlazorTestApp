using BlazorTestApp.BLL.Models;
using BlazorTestApp.BLL.Services.Implementations;
using BlazorTestApp.BLL.Services.Interfaces;
using BlazorTestApp.DAL.DbModels;
using BlazorTestApp.DAL.Enum;
using BlazorTestApp.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Protocol.Core.Types;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.Tests.Services
{
    public class ClientServiceTest
    {
        [Fact]
        public void GetAllReturnsResultWithAListOfUsers()
        {
            // Arrange
            var mock = new Mock<IBaseRepository<Client>>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestClients());
            var clientService = new ClientService(mock.Object);

            // Act
            var result = clientService.GetAll();

            // Assert
            var finishResult = Assert.IsType<IEnumerable<Client>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ClientViewModel>>(
                finishResult);
           
        }

        [Fact]
        public void GetByIdReturnsClientViewModel()
        {
            // Arrange
            int testClientId = 2;
            var mock = new Mock<IBaseRepository<Client>>();
            mock.Setup(repo => repo.GetById(testClientId))
              .Returns(GetTestClients().FirstOrDefault(x=>x.Id==testClientId));
            var servise = new ClientService(mock.Object);

            // Act
            var result = servise.GetById(testClientId);

            // Assert
            var model = Assert.IsType<ClientViewModel>(result);
            Assert.Equal("Андрей"+"Петров", model.Name);
            Assert.Equal(ClientStatus.Active, model.ClientStatus);
            Assert.Equal(testClientId, model.Id);
            Assert.NotEmpty(model.OrdersId);
        }

        private IEnumerable<Client> GetTestClients()
        {
            var ordersForClient1 = new List<Order>
            {
                new Order{ Id = 1,ClientId=1,Description="Adffd",OrderData=DateTime.Now,Cost=1231,OrderStatus=OrderStatus.New},
                new Order{ Id = 2,ClientId=1,Description="dffd",OrderData=DateTime.Now,Cost=1143,OrderStatus=OrderStatus.New}
            };

            var ordersForClient2= new List<Order>
            {
                new Order{ Id = 4,ClientId=2,Description="Asfjkaff",OrderData=DateTime.Now,Cost=312,OrderStatus=OrderStatus.Done},
            };

            var ordersForClient3 = new List<Order>
            {
                new Order{ Id = 3,ClientId=3,Description="Assfd",OrderData=DateTime.Now,Cost=3232,OrderStatus=OrderStatus.New},
            };

            var ordersForClient4 = new List<Order>
            {
                new Order{ Id = 7,ClientId=4,Description="Asfjknbvff",OrderData=DateTime.Now,Cost=3432,OrderStatus=OrderStatus.Done},
            };

            User user = new User() { Id = 1, Name = "admin", Email = "admin", Password = "admin", Role = UserRole.Administrator, IsBlocked = false };

            var clients = new List<Client>
            {
                new Client { Id=1,FirstName="Андрей",LastName="Петров",DateCreate=DateTime.Now,ClientStatus=ClientStatus.Active,NameUserMadeChange="admin",Orders=ordersForClient1,User=user},
                new Client { Id=2,FirstName="Василий",LastName="Девяткин",DateCreate=DateTime.Now,ClientStatus=ClientStatus.Potential,NameUserMadeChange = "admin",User=user},
                new Client { Id=3,FirstName="Михаил",LastName="Сафонов",DateCreate=DateTime.Now,ClientStatus=ClientStatus.NotActive, NameUserMadeChange = "admin",User=user},
                new Client { Id=4,FirstName="Алексей",LastName="Зайцев",DateCreate=DateTime.Now,ClientStatus=ClientStatus.Active,NameUserMadeChange="admin" ,Orders=ordersForClient4, User = user},
            };
            return clients;
        }
    }
}
