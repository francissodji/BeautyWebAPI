using BeautyWebAPI.Data.Context;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Data.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly BeautyDataContext _context;

        public StateRepository(BeautyDataContext context)
        {
            _context = context;
        }

        public IEnumerable<State> GetAllState()
        {
            return _context.States.ToList();
        }
    }
}
