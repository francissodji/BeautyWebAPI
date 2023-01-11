using AutoMapper;
using BeautyWebAPI.Models;
using ConnectivityLibrary.Dtos;
using ConnectivityLibrary.ModelsHelper;

namespace BeautyWebAPI.Profiles
{
    public class RegisterProfile: Profile
    {
        public RegisterProfile()
        {
            CreateMap<Register, RegisterLibrary>();

            CreateMap<RegisterLibrary, Register>();

        }
    }
}
