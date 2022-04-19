using AutoMapper;
using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Profiles
{
    public class ClientProfile : Profile
    {

        public ClientProfile()
        {
            CreateMap<Client, ClientReadDto>();

            CreateMap<ClientCreateDto, Client>();

            CreateMap<ClientUpdateDto, Client>();

            CreateMap<Client, ClientUpdateDto>();
        }
    }
}
