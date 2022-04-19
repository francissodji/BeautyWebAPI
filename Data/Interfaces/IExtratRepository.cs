using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Data.Interfaces
{
    public interface IExtratRepository
    {
        IEnumerable<Extrat> GetAllExtrat();


        IEnumerable<Extrat> GetAllExtratByStyleAndSize(int IdStyle, int IdSize);
        

        Extrat GetExtratById(int id);

        void CreateExtrat(Extrat extrat);

        void UpdateExtrat(Extrat extrat);

        void DeleteExtrat(Extrat extrat);
    }
}
