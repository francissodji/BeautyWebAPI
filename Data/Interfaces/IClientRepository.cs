using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Data.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();

        IEnumerable<Client> GetAllClientByFirstNameLike(string namelike);

        Client GetClientById(int id);

        Task<Client> CreateClient(Client client);

        void UpdateClient(Client client);

        void DeleteClient(Client client);


        Task<Client> GetClientByIdUser(int id);

        Client GetClientByCelClient(string celClient);

        Client GetClientByLastNameAndCelClient(string lastNameClient, string celClient);

    }
}
