using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyWebAPI.Data.Context;
using Microsoft.EntityFrameworkCore;
using BeautyWebAPI.DTOs;
using BeautyWebAPI.ModelsHelper;

namespace BeautyWebAPI.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private readonly BeautyDataContext _context;
        public AppointmentRepository(BeautyDataContext context)
        {
            _context = context;
        }


        public Task<Appointment> CreateAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }

            _context.Appointments.Add(appointment);

            return Task.FromResult(appointment);
        }


        public void DeleteAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Appointment> GetAllAppoint()
        {
            return _context.Appointments.ToList();
        }

        
        public IEnumerable<Appointment> GetAllAppointmentByIdClient(int id)
        {
            var allApprointByCli = _context.Appointments
               .FromSqlInterpolated($"exec [dbo].[SpAppointGetAppointByIdClient] @IDClientAppoint = {id}");

            return allApprointByCli;

        }
        

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments.FirstOrDefault(a => a.IDAppoint == id);
        }


        //public IEnumerable<Appointment> GetAppointmentByStateAppointAndDates(char stateAppoint, DateTime dateBeginSearch, DateTime dateEndSearch)
        public IEnumerable<Appointment> GetAppointmentByStateAppointAndDates(char stateAppoint)
        {
            string storedProc = "EXEC dbo.SpAppointGetAppointByStateAppointAndDates " +
                                "@StateAppoint = '" + stateAppoint + "'";
                                //"@DateBeginSearch = '" + dateBeginSearch + "', " +
                                //"@DateEndSearch = '" + dateEndSearch+"'";

            return _context.Appointments.FromSqlRaw(storedProc).ToList();
        }


        public IEnumerable<Appointment> GetAppointmentByIDClientAppointAndStateAppoint(int idClientAppoint, string stateAppoint)
        {
            string storedProc = "EXEC dbo.SpAppointGetAppointByIdClientAndStateAppoint " +
                                "@IDClientAppoint = " + idClientAppoint + ", " +
                                "@StateAppoint = '" + stateAppoint + "'";


            return _context.Appointments.FromSqlRaw(storedProc).ToList();
        }
        


        public void UpdateAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }
            _context.Appointments.Update(appointment);
        }

        
    }
}
