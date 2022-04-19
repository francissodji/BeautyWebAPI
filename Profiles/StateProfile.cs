using AutoMapper;
using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Profiles
{
    public class StateProfile: Profile
    {
        
        public StateProfile()
        {
            CreateMap<State, StateReadDto>();
        }
    }
}
