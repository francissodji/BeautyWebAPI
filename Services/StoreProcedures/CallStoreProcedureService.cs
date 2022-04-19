using BeautyWebAPI.Data.Context;
using BeautyWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Services.StoreProcedures
{
    public class CallStoreProcedureService
    {


        private readonly BeautyDataContext _context;
        public CallStoreProcedureService(BeautyDataContext context)
        {
            _context = context;
        }

        //Client
        public IEnumerable<Client> SpGetClientByNameLike(string namelike)
        {
            return _context.Clients
                .FromSqlRaw($"SELECT * FROM CLIENTS where Fnameclient like '" + namelike + "'");
                
        }

    }
}
