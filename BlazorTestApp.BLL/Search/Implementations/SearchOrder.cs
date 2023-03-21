using BlazorTestApp.BLL.Models;
using BlazorTestApp.BLL.Search.Interfaces;
using BlazorTestApp.BLL.Services.Implementations;
using BlazorTestApp.BLL.Services.Interfaces;
using BlazorTestApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Search.Implementations
{
    public class SearchOrder : ISearchOrder
    {
        private readonly IOrderService _orderService;

        public SearchOrder(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IEnumerable<OrderViewModel> SearchByName (string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return _orderService.GetAll();

            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

            return _orderService.GetAll().Where(order => order.NameClient.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
