using BlazorTestApp.DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL.Repositories
{
    public class ClientRepository : IBaseRepository<Client>
    {

        private readonly WebDbContext _webDbContext;

        public ClientRepository(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public void Create(Client entity)
        {
            _webDbContext.Clients.Add(entity);
            _webDbContext.SaveChanges();
        }

        public void Delete(Client entity)
        {
            _webDbContext.Clients.Remove(entity);
            _webDbContext.SaveChanges();
        }

        public IEnumerable<Client> GetAll()
        {
            return _webDbContext.Clients.Include(x => x.Orders);
        }

        public Client GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Client Update(Client entity)
        {
            _webDbContext.Clients.Update(entity);
            _webDbContext.SaveChanges();
            return entity;
        }
        public IQueryable<Client> GetHistoryById (int idClient)
        {
           return _webDbContext.Clients.TemporalAll().Where(x => x.Id == idClient);
        }
    }
}
