using BlazorTestApp.BLL.Models;
using BlazorTestApp.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAll();
        UserViewModel GetByUserName(string UserName);
        void Delete(int id);
        void Create(UserCreateViewModel UserCreateViewModel);
        void Save(UserViewModel UserViewModel);
        string GetUserNameById(int userId);
       
    }
}
