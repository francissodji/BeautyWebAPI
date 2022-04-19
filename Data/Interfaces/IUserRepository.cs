using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        

        //Users
        IEnumerable<User> GetAllUsers();

        User GetUserById(int id);

        Task<User> CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        Task<User> Authenticate(string userName, string password);


        Task<User> GetByUsername(string userName);

        Task<User> GetByEmail(string email);


    }
}
