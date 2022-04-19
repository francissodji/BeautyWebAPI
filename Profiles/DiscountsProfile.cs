using AutoMapper;
using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Profiles
{
    public class DiscountsProfile : Profile
    {

        public DiscountsProfile()
        {
            CreateMap<Discount, DiscountReadDto>();

            CreateMap<DiscountCreateDto, Discount>();

            CreateMap<DiscountUpdateDto, Discount>();

            CreateMap<Discount, DiscountUpdateDto>();
        }
    }
}
