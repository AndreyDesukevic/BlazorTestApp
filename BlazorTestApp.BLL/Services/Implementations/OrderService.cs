using BlazorTestApp.BLL.Models;
using BlazorTestApp.BLL.Services.Interfaces;
using BlazorTestApp.DAL.DbModels;
using BlazorTestApp.DAL.Enum;
using BlazorTestApp.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
                    CannotDeleted=IsCannotDeleted(dbOrder.OrderStatus),
                    NameUserMadeChangeOrder = dbOrder.NameUserMadeChangeOrder,
                });
            return viewModels;
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
                OrderStatus = OrderStatus.New,
                NameUserMadeChangeOrder=orderCreateViewModel.NameUserMadeChangeOrder
            };
            _orderRepository.Create(dbOrder);
        }

        public void Save(OrderViewModel orderViewModel)
        {
            var dbOrder = _orderRepository.GetAll().FirstOrDefault(order => order.Id == orderViewModel.Id);
            dbOrder.OrderStatus = orderViewModel.OrderStatus;
            dbOrder.Description = orderViewModel.Description;
            dbOrder.NameUserMadeChangeOrder= orderViewModel.NameUserMadeChangeOrder;
            _orderRepository.Update(dbOrder);
        }

        public void Delete(int id, string currentUser)
        {
            var order = _orderRepository.GetById(id);
            order.NameUserMadeChangeOrder= currentUser;
            _orderRepository.Delete(order);
        }

        public OrderViewModel GetById(int id) => GetAll().FirstOrDefault(order => order.Id == id);

        public IEnumerable<OrderViewModel> GetListOrdersById(List<int> ids) => GetAll().Where(order => ids.Contains(order.Id));

        private static bool IsCannotDeleted(OrderStatus orderStatus) => orderStatus == OrderStatus.Done;

        public List<HistoryOrderViewModel> GetHistoryOrder(int idOrder)
        {
            var dbHistoriesOrder = _orderRepository.GetHistoryById(idOrder);
            var historyOrderViewMidel = new List<HistoryOrderViewModel>();
            if (dbHistoriesOrder != null)
            {
                historyOrderViewMidel = dbHistoriesOrder
                               .Select(dbHistoryOrder => new HistoryOrderViewModel()
                               {
                                   Description = dbHistoryOrder.Description,
                                   OrderStatus = dbHistoryOrder.OrderStatus,
                                   DateOfChange = EF.Property<DateTime>(dbHistoryOrder, "CreatedAt"),
                                   UserName = dbHistoryOrder.NameUserMadeChangeOrder,
                               }).OrderBy(x => x.DateOfChange).ToList();
                return historyOrderViewMidel;
            }
            return historyOrderViewMidel.ToList();
        }
    }
}
