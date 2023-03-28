using BlazorTestApp.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL.Repositories
{
    public interface IBaseRepository<T>
    {
        void Create(T entity);
        IEnumerable<T> GetAll();
        void Delete(T entity);
        T Update(T entity);
        T GetById(int id);
        IQueryable<T> GetHistoryById(int id);
        
    }
}
