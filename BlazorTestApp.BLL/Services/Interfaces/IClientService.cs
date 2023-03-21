using BlazorTestApp.BLL.Models;
using BlazorTestApp.DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientViewModel> GetAll();
        ClientViewModel GetById(int id);
        ClientViewModel GetByName(string name);
        bool Delete(int id);
        void Create(ClientCreateViewModel clientCreateViewModel);
        void Save(ClientViewModel clientViewModel);

    }
}
