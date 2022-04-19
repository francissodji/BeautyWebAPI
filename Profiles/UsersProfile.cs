using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;


namespace BeautyWebAPI.Profiles
{
    public class UsersProfile: Profile
    {

        public UsersProfile()
        {
            CreateMap<User, UserReadDto>();

            CreateMap<UserCreateDto, User>();

            CreateMap<UserUpdateDto, User>();

            CreateMap<User, UserUpdateDto>();

            CreateMap<UserLoginReadDto, UserResponsDto>();
        }



    }
}
