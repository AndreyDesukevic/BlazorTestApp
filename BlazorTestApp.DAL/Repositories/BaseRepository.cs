using BlazorTestApp.DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected WebDbContext _webDbContext;
        protected DbSet<T> _dbSet;

        protected BaseRepository(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
            _dbSet = _webDbContext.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _webDbContext.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _webDbContext.SaveChangesAsync();
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }
        public async Task<T> Update(T entity)
        {
            var item = _dbSet.Attach(entity);
            item.State= EntityState.Modified;

            await _webDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
