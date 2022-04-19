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
    public class ExtratStyleRepository : IExtratStyleRepository
    {

        private readonly BeautyDataContext _context;

        public ExtratStyleRepository(BeautyDataContext context)
        {
            _context = context;
        }

        public void CreateExtratStyle(ExtratStyle extratStyle)
        {
            throw new NotImplementedException();
        }

        public void DeleteExtratStyle(ExtratStyle extratStyle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExtratStyle> GetAllExtratStyle()
        {
            return _context.ExtratStyles.ToList();
        }


        
        public IEnumerable<ExtratStyle> GetAllExtratPrices(int IdStyle, int IdSize, int IdExtrat)
        {
            string storedProc = "EXEC dbo.SpExtratStyleGetExtratPrices " +
                                "@IdStyle = " + IdStyle + ", " +
                                "@IdSize = " + IdSize + ", " +
                                "@IdExtrat = " + IdExtrat;


            return _context.ExtratStyles.FromSqlRaw(storedProc).ToList();
        }
        



        /*
        public IEnumerable<ExtratStyle> GetAllSizeByStyle(int IdStyle)
        {
            string storedProc = "EXEC dbo.SpExtratStyleGetSizePerStyle @IdStyle = " + IdStyle;


            return _context.ExtratStyles.FromSqlRaw(storedProc).ToList();
        }
        */


        public ExtratStyle GetExtratStyleById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateExtratStyle(ExtratStyle extratStyle)
        {
            throw new NotImplementedException();
        }
    }
}
