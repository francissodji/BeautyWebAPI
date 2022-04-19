using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Data.Interfaces
{
    public interface IExtratStyleRepository
    {
        IEnumerable<ExtratStyle> GetAllExtratStyle();


        IEnumerable<ExtratStyle> GetAllExtratPrices(int IdStyle, int IdSize, int IdExtrat);


        //IEnumerable<ExtratStyle> GetAllSizeByStyle(int IdStyle);


        ExtratStyle GetExtratStyleById(int id);

        void CreateExtratStyle(ExtratStyle extratStyle);

        void UpdateExtratStyle(ExtratStyle extratStyle);

        void DeleteExtratStyle(ExtratStyle extratStyle);
    }
}
