using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Data.Interfaces
{
    public interface IStyleRepository
    {
        IEnumerable<Style> GetAllStyle();

        Style GetStyleById(int id);

        void CreateStyle(Style style);

        void UpdateStyle(Style style);

        void DeleteStyle(Style style);
    }
}
