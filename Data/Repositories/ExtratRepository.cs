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
    public class ExtratRepository : IExtratRepository
    {

        private readonly BeautyDataContext _context;
        public ExtratRepository(BeautyDataContext context)
        {
            _context = context;
        }

        /*
        public void CreateExtrat(Length extrat)
        {
            _context.Extrats.Add(extrat);
        }

        public void DeleteExtrat(Length extrat)
        {
            if (extrat == null)
            {
                throw new ArgumentNullException(nameof(extrat));
            }

            _context.Extrats.Remove(extrat);
        }

        public IEnumerable<Length> GetAllExtrat()
        {
            return _context.Extrats.ToList();
        }

        public IEnumerable<Length> GetAllExtratByStyleAndSize(int IdStyle, int IdSize)
        {
            string storedProc = "EXEC dbo.SpExtratGetLengthPerStyleAndSize " +
                                "@IdStyle = " + IdStyle + ", " +
                                "@IdSize = " + IdSize;


            return _context.Extrats.FromSqlRaw(storedProc).ToList();
        }



        public Length GetExtratById(int id)
        {
            return _context.Extrats.FirstOrDefault(e => e.IdExtrat == id);
        }

        public void UpdateExtrat(Length extrat)
        {
            if (extrat == null)
            {
                throw new ArgumentNullException(nameof(extrat));
            }

            _context.Extrats.Update(extrat);
        }

        */

    }
}
