using BlazorTestApp.BLL.Models;
using BlazorTestApp.BLL.Services.Interfaces;
using BlazorTestApp.DAL.DbModels;
using BlazorTestApp.DAL.Enum;
using BlazorTestApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(UserCreateViewModel UserCreateViewModel)
        {
            var dbUser = new User()
            {
                Name = UserCreateViewModel.Name,
                Email = UserCreateViewModel.Email,
                Password = UserCreateViewModel.Password,
                Role = UserRole.Manager,
                IsBlocked = false
            };
            _userRepository.Create(dbUser);
        }

        public void Delete(int id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Delete(user);
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            var dbUsers = _userRepository.GetAll();
            var userViewModels = dbUsers
                .Select(dbUser => new UserViewModel()
                {
                    Id = dbUser.Id,
                    Name = dbUser.Name,
                    Email = dbUser.Email,
                    Password = dbUser.Password,
                    Role = dbUser.Role,
                    IsBlocked = dbUser.IsBlocked
                });
            return userViewModels;
        }

        public UserViewModel GetByUserName(string UserName)
        {
            return GetAll().FirstOrDefault(x => x.Name == UserName);
        }

        public  string GetUserNameById(int userId)
        {
            return GetAll().FirstOrDefault(x => x.Id == userId).Name; 
        }

        public void Save(UserViewModel UserViewModel)
        {
            throw new NotImplementedException();
        }

    }
}
