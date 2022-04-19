using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyWebAPI.Models;
using BeautyWebAPI.DTOs;
using AutoMapper;


namespace BeautyWebAPI.Profiles
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<Size, SizeReadDto>();

            CreateMap<SizeCreateDto, Size>();

            CreateMap<SizeUpdateDto, Size>();

            CreateMap<Size, SizeUpdateDto>();
        }
    }
}
