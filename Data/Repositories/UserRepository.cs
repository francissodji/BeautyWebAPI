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
    public class UserRepository : IUserRepository
    {
        
        private readonly BeautyDataContext _context;
        public UserRepository(BeautyDataContext context)
        {
            _context = context;
        }

        
        public async Task<User> Authenticate(string userName, string passWord)
        {
            string theHashPassword = ""; // apply the Hash password
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == userName && u.PasswordHash == theHashPassword);
        }
        

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.IDUser == id);
        }

        public Task<User> CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            //user.IDUser = Guid.NewGuid(); Will need this only if IDUser in User is type 'Guid' - 1/17/2021
            _context.Users.Add(user);

            return Task.FromResult(user);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Update(user);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Remove(user);
        }

        
        public Task<User> GetByUsername(string userName)
        {
            return Task.FromResult(_context.Users.FirstOrDefault(u => u.Username == userName));
        }
        


        public Task<User> GetByEmail(string email)
        {
            return Task.FromResult(_context.Users.FirstOrDefault(u => u.Email == email));
        }
    }
}
