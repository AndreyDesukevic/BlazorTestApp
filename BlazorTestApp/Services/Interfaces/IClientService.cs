using BlazorTestApp.DAL.DbModels;

namespace BlazorTestApp.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<Client> GetAll();
        Client GetById(int id);
        Client GetByName(string name);
        bool Delete(Client client);
        bool Create(Client client);
        Client Save(Client client);
    }
}
