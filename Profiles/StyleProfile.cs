using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyWebAPI.Models;
using BeautyWebAPI.DTOs;
using AutoMapper;


namespace BeautyWebAPI.Profiles
{
    public class StyleProfile : Profile
    {
        public StyleProfile()
        {
            CreateMap<Style, StyleReadDto>();

            CreateMap<StyleCreateDto, Style>();

            CreateMap<StyleUpdateDto, Style>();

            CreateMap<Style, StyleUpdateDto>();
        }
    }
}
