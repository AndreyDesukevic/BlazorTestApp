using BlazorTestApp.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL.Repositories
{
    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(WebDbContext webDbContext) : base(webDbContext)
        {
        }
    }
}
