using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyWebAPI.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BeautyWebAPI.Data.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly BeautyDataContext _context;

        public SizeRepository(BeautyDataContext context)
        {
            _context = context;
        }

        /*
        public IEnumerable<Size> GetAllSize()
        {
            return _context.Sizes.ToList();
        }
        

        public void CreateSize(Size size)
        {
            throw new NotImplementedException();
        }

        public void DeleteSize(Size size)
        {
            throw new NotImplementedException();
        }

        

        public Size GetSizeById(int id)
        {
            return _context.Sizes.FirstOrDefault(s => s.IdSize == id);
        }


        public void UpdateSize(Size size)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Size> GetAllSizeByStyle(int idStyle)
        {
            string storedProc = "EXEC dbo.SpSizeGetSizePerStyle @IdStyle = " + idStyle;


            return _context.Sizes.FromSqlRaw(storedProc).ToList();
        }

        */
    }

}
