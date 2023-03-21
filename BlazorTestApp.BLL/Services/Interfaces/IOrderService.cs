using BlazorTestApp.BLL.Models;
using BlazorTestApp.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderViewModel> GetAll();
        OrderViewModel GetById(int id);
        void Delete(int id);
        void Create(OrderCreateViewModel orderCreateViewModel);
        void Save(OrderViewModel orderViewModel);
        IEnumerable<OrderViewModel> GetListOrdersById(List<int> ids);
    }
}
