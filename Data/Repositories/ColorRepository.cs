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
    public class ColorRepository : IColorRepository
    {

        private readonly BeautyDataContext _context;
        public ColorRepository(BeautyDataContext context)
        {
            _context = context;
        }



        public IEnumerable<Color> GetAllColor()
        {
            return _context.Colors.ToList();
        }

        public Color GetColorById(int id)
        {
            return _context.Colors.FirstOrDefault(c => c.IdColor == id);
        }

        public void CreateColor(Color color)
        {
            if (color == null)
            {
                throw new ArgumentNullException(nameof(color));
            }
            _context.Colors.Add(color);
        }

        public void UpdateColor(Color color)
        {
            if (color == null)
            {
                throw new ArgumentNullException(nameof(color));
            }

            _context.Colors.Update(color);
        }

        public void DeleteColor(Color color)
        {
            if (color == null)
            {
                throw new ArgumentNullException(nameof(color));
            }

            _context.Colors.Remove(color);

        }

        public Color StoreProcGetColorById(int id)
        {
            return _context.Colors.FromSqlRaw("EXEC dbo.SpColorGetColorById @IdColor =" + id)
                .ToList().FirstOrDefault();
        }
    }
}
