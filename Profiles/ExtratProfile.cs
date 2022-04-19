
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeautyWebAPI.Models;
using BeautyWebAPI.DTOs;
using AutoMapper;
using System;

namespace BeautyWebAPI.Profiles
{
    public class ExtratProfile : Profile
    {
        public ExtratProfile()
        {
            CreateMap<Extrat, ExtratReadDto>();

            CreateMap<ExtratCreateDto, Color>();

            CreateMap<ExtratUpdateDto, Color>();

            CreateMap<Color, ExtratUpdateDto>();
        }

    }
}
