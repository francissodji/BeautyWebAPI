using BeautyWebAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeautyWebAPI.Models;
using BeautyWebAPI.Data.Context;

namespace BeautyWebAPI.Data.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly BeautyDataContext _context;

        public DiscountRepository(BeautyDataContext context)
        {
            _context = context;
        }

        public void CreateDiscount(Discount discount)
        {
            if (discount == null)
            {
                throw new ArgumentNullException(nameof(discount));
            }
            _context.Discounts.Add(discount);
        }

        public void DeleteDiscount(Discount discount)
        {
            if (discount == null)
            {
                throw new ArgumentNullException(nameof(discount));
            }
            _context.Discounts.Remove(discount);
        }

        public IEnumerable<Discount> GetAllDiscount()
        {
            return _context.Discounts.ToList();
        }

        public Discount GetDiscountById(int Id)
        {
            return _context.Discounts.FirstOrDefault(d => d.IDDiscount == Id);
        }

        public void UpdateDiscount(Discount discount)
        {
            if (discount == null)
            {
                throw new ArgumentNullException(nameof(discount));
            }
            _context.Discounts.Update(discount);
        }
    }
}
