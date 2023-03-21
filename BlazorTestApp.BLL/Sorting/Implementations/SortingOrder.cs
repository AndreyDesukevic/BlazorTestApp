using BlazorTestApp.BLL.Models;
using BlazorTestApp.BLL.Services.Interfaces;
using BlazorTestApp.BLL.Sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using BlazorTestApp.DAL.DbModels;

namespace BlazorTestApp.BLL.Sorting.Implementations
{
    public class SortingOrder : ISortingOrder
    {
        private readonly IOrderService _orderService;

        public SortingOrder(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IEnumerable<OrderViewModel> Sort(string sortBy)
        {
            var orders = _orderService.GetAll();
            if (sortBy == "NameClient" || sortBy == "NameClient desc") return sortBy.EndsWith(" desc") ? SortNameClientDesc(orders) : SortNameClient(orders);
            else if (sortBy == "OrderData" || sortBy == "OrderDatat desc") return sortBy.EndsWith(" desc") ? SortOrderDataDesc(orders) : SortOrderData(orders);
            else return sortBy.EndsWith(" desc") ? SortCostDesc(orders) : SortCost(orders);

        }
        private IEnumerable<OrderViewModel> SortNameClient(IEnumerable<OrderViewModel> orders) => orders.OrderBy(x => x.NameClient);
        private IEnumerable<OrderViewModel> SortNameClientDesc(IEnumerable<OrderViewModel> orders) => orders.OrderByDescending(x => x.NameClient);
        private IEnumerable<OrderViewModel> SortOrderData(IEnumerable<OrderViewModel> orders) => orders.OrderBy(x => x.OrderData);
        private IEnumerable<OrderViewModel> SortOrderDataDesc(IEnumerable<OrderViewModel> orders) => orders.OrderByDescending(x => x.OrderData);
        private IEnumerable<OrderViewModel> SortCost(IEnumerable<OrderViewModel> orders) => orders.OrderBy(x => x.Cost);
        private IEnumerable<OrderViewModel> SortCostDesc(IEnumerable<OrderViewModel> orders) => orders.OrderByDescending(x => x.Cost);

    }
}
