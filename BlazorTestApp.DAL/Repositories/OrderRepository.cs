using BlazorTestApp.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(WebDbContext webDbContext) : base(webDbContext)
        {
        }
    }
}
