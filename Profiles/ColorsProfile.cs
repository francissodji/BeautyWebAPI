using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Profiles
{
    public class ColorsProfile : Profile
    {

        public ColorsProfile()
        {
            CreateMap<Color, ColorReadDto>();

            CreateMap<ColorCreateDto, Color>();

            CreateMap<ColorUpdateDto, Color>();

            CreateMap<Color, ColorUpdateDto>();
        }
        
    }
}
