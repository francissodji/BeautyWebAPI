using BeautyWebAPI.Data.Context;
using BeautyWebAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Data.Repositories
{
    public class BeautyBaseRepository : IBeautyBaseRepository
    {

        private readonly BeautyDataContext _context;

        public BeautyBaseRepository(BeautyDataContext context)
        {
            _context = context;
        }


        public IUserRepository UserRepository => 
            new UserRepository(_context);

        public IColorRepository ColorRepository =>
            new ColorRepository(_context);


        public IClientRepository ClientRepository =>
            new ClientRepository(_context);

        public IDiscountRepository DiscountRepository =>
            new DiscountRepository(_context);

        public IStyleRepository StyleRepository =>
            new StyleRepository(_context);

        public ISizeRepository SizeRepository =>
            new SizeRepository(_context);


        public IExtratRepository ExtratRepository =>
            new ExtratRepository(_context);

        public IExtratStyleRepository ExtratStyleRepository =>
            new ExtratStyleRepository(_context);

        public IAppointmentRepository AppointmentRepository =>
            new AppointmentRepository(_context);


        public IStateRepository StateRepository =>
            new StateRepository(_context);

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
        //public IUserRepository userRepository => throw new NotImplementedException();
    }
}
