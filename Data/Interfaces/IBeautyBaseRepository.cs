using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Data.Interfaces
{
    public interface IBeautyBaseRepository
    {
        IUserRepository UserRepository { get; }

        IColorRepository ColorRepository { get; }

        IClientRepository ClientRepository { get; }

        IDiscountRepository DiscountRepository { get; }

        IStyleRepository StyleRepository { get; }

        ISizeRepository SizeRepository { get; }

        IExtratRepository ExtratRepository { get; }

        IExtratStyleRepository ExtratStyleRepository { get; }

        IAppointmentRepository AppointmentRepository { get; }

        IStateRepository StateRepository { get; }




        bool SaveChanges();

        Task<bool> SaveAsync();
    }
}
