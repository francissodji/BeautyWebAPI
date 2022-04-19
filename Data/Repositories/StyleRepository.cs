using BeautyWebAPI.Data.Context;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Data.Repositories
{
    public class StyleRepository : IStyleRepository
    {

        private readonly BeautyDataContext _context;
        public StyleRepository(BeautyDataContext context)
        {
            _context = context;
        }


        public void CreateStyle(Style style)
        {
            if (style == null)
            {
                throw new ArgumentNullException(nameof(style));
            }

            _context.Styles.Add(style);
        }

        public void DeleteStyle(Style style)
        {
            if (style == null)
            {
                throw new ArgumentNullException(nameof(style));
            }

            _context.Styles.Remove(style);
        }

        public IEnumerable<Style> GetAllStyle()
        {
            return _context.Styles.ToList();
        }

        public Style GetStyleById(int id)
        {
            return _context.Styles.FirstOrDefault(s => s.IdStyle == id);
        }

        public void UpdateStyle(Style style)
        {
            if (style == null)
            {
                throw new ArgumentNullException(nameof(style));
            }

            _context.Styles.Update(style);
        }
    }
}
