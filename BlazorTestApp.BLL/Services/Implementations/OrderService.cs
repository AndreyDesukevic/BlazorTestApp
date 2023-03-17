using BlazorTestApp.BLL.Models;
using BlazorTestApp.BLL.Services.Interfaces;
using BlazorTestApp.DAL.DbModels;
using BlazorTestApp.DAL.Enum;
using BlazorTestApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IBaseRepository<Client> _clientRepository;

        public OrderService(IBaseRepository<Order> orderRepository, IBaseRepository<Client> clientRepository)
        {
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
        }

        public void Create(OrderCreateViewModel orderCreateViewModel)
        {
            var dbClient = _clientRepository.GetById(orderCreateViewModel.ClientId);
            var dbOrder = new Order()
            {
                ClientId = orderCreateViewModel.ClientId,
                Client = dbClient,
                Description = orderCreateViewModel.Description,
                OrderData = DateTime.Now,
                Cost = orderCreateViewModel.Cost,
                OrderStatus = OrderStatus.New
            };
            _orderRepository.Create(dbOrder);
        }

        public void Delete(int id)
        {
            var order = _orderRepository.GetById(id);
            _orderRepository.Delete(order);
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            var dbOdrers = _orderRepository.GetAll();
            var viewModels = dbOdrers
                .Select(dbOrder => new OrderViewModel()
                {
                    Id = dbOrder.Id,
                    ClientId = dbOrder.ClientId,
                    NameClient = string.Join(" ", new string[] { dbOrder.Client.FirstName, dbOrder.Client.LastName }),
                    Description = dbOrder.Description,
                    Cost = dbOrder.Cost,
                    OrderData = dbOrder.OrderData,
                    OrderStatus = dbOrder.OrderStatus,
                });
            return viewModels;
        }

        public OrderViewModel GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

        public IEnumerable<OrderViewModel> GetListOrdersById(List<int> ids)
        {
            return GetAll().Where(x => ids.Contains(x.Id));
        }

        public void Save(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
