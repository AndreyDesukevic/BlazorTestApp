using BlazorTestApp.DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL.Repositories
{
    public class OrderRepository : IBaseRepository<Order>
    {
        private readonly WebDbContext _webDbContext;

        public OrderRepository(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public void Create(Order entity)
        {
             _webDbContext.Orders.AddAsync(entity);
             _webDbContext.SaveChanges();
        }

       public void Delete(Order entity)
        {
            _webDbContext.Orders.Remove(entity);
            _webDbContext.SaveChanges();
        }

        public IQueryable<Order> GetAll()
        {
            return _webDbContext.Orders.Include(x => x.Client);
        }

        public Order Update(Order entity)
        {
            _webDbContext.Orders.Update(entity);
            _webDbContext.SaveChanges();
            return entity;
        }
    }
}
