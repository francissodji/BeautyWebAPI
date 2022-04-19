using BeautyWebAPI.Data.Context;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {

        private readonly BeautyDataContext _context;
        public ClientRepository(BeautyDataContext context)
        {
            _context = context;
        }


        public Task<Client> CreateClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _context.Clients.Add(client);

            return Task.FromResult(client);
        }


        public void DeleteClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _context.Clients.Remove(client);
        }

        public IEnumerable<Client> GetAllClientByFirstNameLike(string namelike)
        {
            return _context.Clients
                .FromSqlRaw($"SELECT * FROM CLIENTS where Fnameclient like '"+ namelike + "'")
                .ToList();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        
        public Client GetClientByCelClient(string celClient)
        {
            string storedProc = "EXEC dbo.SpClientGetClientByCelPhoneNumber " +
                                "@CelPhoneClient = '" + celClient +"'";

             return _context.Clients.FromSqlRaw(storedProc).ToList().FirstOrDefault();

            //return theClient;

        }
        

        /*
        public Client GetClientByCelClient(string celClient)
        {

            return Task.FromResult(_context.Clients.FirstOrDefault(c => c.CelClient == celClient));


        }*/

        public Client GetClientById(int id)
        {
            return _context.Clients.FirstOrDefault(c => c.IDClient == id);
        }



        public Task<Client> GetClientByIdUser(int id)
        {
            return Task.FromResult(_context.Clients.FirstOrDefault(c => c.IDUser == id));
        }


        public Client GetClientByLastNameAndCelClient(string lastNameClient, string celClient)
        {
            string storedProc = "EXEC dbo.SpClientGetClientByLastNameAndCelPhoneNum " +
                                "@LastName = '" + lastNameClient + "', " +
                                "@CelClient = '" + celClient + "'";

            var theClient = _context.Clients.FromSqlRaw(storedProc).ToList().FirstOrDefault();

            return theClient;
        }


        public void UpdateClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _context.Clients.Update(client);
        }
    }
}
