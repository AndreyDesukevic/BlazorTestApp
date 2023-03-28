using BlazorTestApp.DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly WebDbContext _webDbContext;

        public UserRepository(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public void Create(User entity)
        {
            _webDbContext.Users.Add(entity);
            _webDbContext.SaveChanges(); ;
        }

        public void Delete(User entity)
        {
            _webDbContext.Users.Remove(entity);
            _webDbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _webDbContext.Users;
        }

        public User GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<User> GetHistoryById(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(User entity)
        {
            _webDbContext.Users.Update(entity);
            _webDbContext.SaveChanges();
            return entity;
        }
    }
}
