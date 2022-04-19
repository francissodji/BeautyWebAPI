using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Services.PasswordHasher
{
    public class BcryptPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string plainTextPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        }

        public bool VerifyPassword(string plainTextPassword, string passwordHashed)
        {
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, passwordHashed);
        }
    }
}
