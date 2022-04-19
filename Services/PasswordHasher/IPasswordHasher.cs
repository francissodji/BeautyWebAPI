using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Services.PasswordHasher
{
    public interface IPasswordHasher
    {
        string HashPassword(string plainTextPassword);

        bool VerifyPassword(string plainTextPassword, string passwordHashed);
    }
}
