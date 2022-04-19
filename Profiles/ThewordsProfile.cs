using AutoMapper;
using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Profiles
{
    public class ThewordsProfile: Profile
    {
        public ThewordsProfile()
        {
            CreateMap<Theword, ThewordReadDto>();

            CreateMap<ThewordCreateDto, Theword>();

            CreateMap<ThewordUpdateDto, Theword>();

            CreateMap<Theword, ThewordUpdateDto>();
        }
       
    }
}
