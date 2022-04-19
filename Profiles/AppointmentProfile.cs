using AutoMapper;
using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyWebAPI.DTOs;

namespace BeautyWebAPI.Profiles
{
    public class AppointmentProfile:Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentReadDto>();

            CreateMap<AppointWithLibel, AppointWithLibelReadDto>();

            CreateMap<AppointWithLibelReadDto, AppointWithLibel>();

            CreateMap<AppointmentCreateDto, Appointment>();

            CreateMap<AppointmentUpdateDto, Appointment>();

            CreateMap<Appointment, AppointmentUpdateDto>();



            CreateMap<AppointmentReadDto, AppointWithLibelReadDto>();
        }
    }
}

