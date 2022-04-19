using AutoMapper;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;
using BeautyWebAPI.ModelsHelper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Controllers
{
    public class AppointmentController : BaseController
    {

        private readonly IBeautyBaseRepository _beautyBaseRepos;

        private IMapper _mapper { get; }

        public AppointmentController(IBeautyBaseRepository beautyBaseRepos, IMapper mapper)
        {
            _beautyBaseRepos = beautyBaseRepos;

            _mapper = mapper;
        }


        //POST  api/Appointment
        [HttpPost]
        public ActionResult<AppointmentReadDto> CreateNewAppointment(AppointmentCreateDto appointmentCreateDto)
        {
            
            var appointmentModel = _mapper.Map<Appointment>(appointmentCreateDto);
            _beautyBaseRepos.AppointmentRepository.CreateAppointment(appointmentModel);
            _beautyBaseRepos.SaveChanges();

            var appointReadDto = _mapper.Map<AppointmentReadDto>(appointmentModel);

            return CreatedAtRoute(nameof(LoadAppointmentById), new { Id = appointReadDto.IDAppoint }, appointReadDto);
            //return Ok(colorReadDto);
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppointmentReadDto>> LoadAllAppointment()
        {
            var listAllAppoint = _beautyBaseRepos.AppointmentRepository.GetAllAppoint();

            return Ok(_mapper.Map<IEnumerable<AppointmentReadDto>>(listAllAppoint));
        }


        [HttpGet("byidclient")]
        public ActionResult<IEnumerable<AppointmentReadDto>> LoadAllAppointmentByClient(int idClient)
        {
            var listAllAppoint = _beautyBaseRepos.AppointmentRepository.GetAllAppointmentByIdClient(idClient);

            return Ok(_mapper.Map<IEnumerable<AppointmentReadDto>>(listAllAppoint));
        }



        [HttpGet("byidclientandappointstate/{idClientAppoint}/{stateAppoint}")]
        //public async Task<ActionResult<AppointmentReadDto>> LoadAllAppointmentByClientAndAppointState(int idClientAppoint, string stateAppoint)
        public ActionResult<IEnumerable<AppointWithLibel>> LoadAllAppointmentByClientAndAppointState(int idClientAppoint, string stateAppoint)
        {
            
            var listAllAppoint = _beautyBaseRepos.AppointmentRepository.GetAppointmentByIDClientAppointAndStateAppoint(idClientAppoint, stateAppoint);

          
            List<AppointWithLibel> allClientAppoint = new List<AppointWithLibel>();

            if (listAllAppoint != null)
            {
                foreach (var appoint in listAllAppoint)
                {
                    AppointWithLibel appointwithlabel = new AppointWithLibel();

                    appointwithlabel.IDAppoint = appoint.IDAppoint;
                    appointwithlabel.IDBraiderAppoint = appoint.IDBraiderAppoint;
                    appointwithlabel.IdBraiderOwner = appoint.IdBraiderOwner;
                    appointwithlabel.IDClientAppoint = appoint.IDClientAppoint;
                    appointwithlabel.IDStyleAppoint = appoint.IDStyleAppoint;
                    appointwithlabel.IdSizeAppoint = appoint.IdSizeAppoint;
                    appointwithlabel.IDLenghtAppoint = appoint.IDLenghtAppoint;
                    appointwithlabel.AddTakeOffAppoint = appoint.AddTakeOffAppoint;
                    appointwithlabel.StateAppoint = appoint.StateAppoint;
                    appointwithlabel.NumberTrack = appoint.NumberTrack;
                    appointwithlabel.Typeservice = appoint.Typeservice;
                    appointwithlabel.DateAppoint = appoint.DateAppoint;

                    appointwithlabel.DesigStyle = _beautyBaseRepos.StyleRepository.GetStyleById(appoint.IDStyleAppoint).DesigStyle;
                    appointwithlabel.TitleSize = _beautyBaseRepos.SizeRepository.GetSizeById(appoint.IdSizeAppoint).TitleSize;
                    appointwithlabel.TitleExtrat = _beautyBaseRepos.ExtratRepository.GetExtratById(appoint.IDLenghtAppoint).TitleExtrat;


                    allClientAppoint.Add(appointwithlabel);
                    Console.WriteLine(appointwithlabel);
                }
            }

            
           // return Ok(allClientAppoint);
            return Ok(_mapper.Map<IEnumerable<AppointWithLibelReadDto>>(allClientAppoint));
        }


        //[HttpGet("byidappointstateanddates/{stateAppoint}/{dateBeginSearch}/{dataEndSearch}")]
        //public ActionResult<IEnumerable<AppointWithLibel>> LoadAllAppointmentByAppointStateAndDates(char stateAppoint, DateTime dateBeginSearch, DateTime dataEndSearch)
        [HttpGet("byappointstateanddates/{stateAppoint}")]
        public ActionResult<IEnumerable<AppointWithLibel>> LoadAllAppointmentByAppointStateAndDates(char stateAppoint)
        {
            try
            {

                //var listAllAppoint = _beautyBaseRepos.AppointmentRepository.GetAppointmentByStateAppointAndDates(stateAppoint, dateBeginSearch, dataEndSearch);
                var listAllAppoint = _beautyBaseRepos.AppointmentRepository.GetAppointmentByStateAppointAndDates(stateAppoint);

                List<AppointWithLibel> allClientAppoint = new List<AppointWithLibel>();

                if (listAllAppoint != null) 
                {
                    foreach (var appoint in listAllAppoint)
                    {
                        AppointWithLibel appointwithlabel = new AppointWithLibel();

                        appointwithlabel.IDAppoint = appoint.IDAppoint;
                        appointwithlabel.IDBraiderAppoint = appoint.IDBraiderAppoint;
                        appointwithlabel.IdBraiderOwner = appoint.IdBraiderOwner;
                        appointwithlabel.IDClientAppoint = appoint.IDClientAppoint;
                        appointwithlabel.IDStyleAppoint = appoint.IDStyleAppoint;
                        appointwithlabel.IdSizeAppoint = appoint.IdSizeAppoint;
                        appointwithlabel.IDLenghtAppoint = appoint.IDLenghtAppoint;
                        appointwithlabel.AddTakeOffAppoint = appoint.AddTakeOffAppoint;
                        appointwithlabel.StateAppoint = appoint.StateAppoint;
                        appointwithlabel.NumberTrack = appoint.NumberTrack;
                        appointwithlabel.Typeservice = appoint.Typeservice;
                        appointwithlabel.DateAppoint = appoint.DateAppoint;

                        if (appoint.IDStyleAppoint > 0)
                        {
                            appointwithlabel.DesigStyle = _beautyBaseRepos.StyleRepository.GetStyleById(appoint.IDStyleAppoint).DesigStyle;
                        }

                        if (appoint.IdSizeAppoint > 0)
                        {
                            appointwithlabel.TitleSize = _beautyBaseRepos.SizeRepository.GetSizeById(appoint.IdSizeAppoint).TitleSize;
                        }

                        if (appoint.IDLenghtAppoint > 0)
                        {
                            appointwithlabel.TitleExtrat = _beautyBaseRepos.ExtratRepository.GetExtratById(appoint.IDLenghtAppoint).TitleExtrat;
                        }


                        Client aClient = new Client();
                        
                        aClient = _beautyBaseRepos.ClientRepository.GetClientById(appoint.IDClientAppoint);
                        appointwithlabel.ClientFullName = aClient.FnameClient + " " + aClient.LnameClient;

                        allClientAppoint.Add(appointwithlabel);
                    }
                }

                return Ok(_mapper.Map<IEnumerable<AppointWithLibelReadDto>>(allClientAppoint));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }



        [HttpPut("{id}")]
        public ActionResult UpdateAppointment(int id, AppointmentUpdateDto appointmentUpdateDto)
        {
            var appointModelFromRepo = _beautyBaseRepos.AppointmentRepository.GetAppointmentById(id);

            if (appointModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(appointmentUpdateDto, appointModelFromRepo);

            _beautyBaseRepos.AppointmentRepository.UpdateAppointment(appointModelFromRepo);

            _beautyBaseRepos.SaveChanges();

            return NoContent();
        }

        //GET api/colors/2


        [HttpGet("{id}", Name = "LoadAppointmentById")]
        public ActionResult<AppointmentReadDto> LoadAppointmentById(int id)
        {
            var theAppoint = _beautyBaseRepos.AppointmentRepository.GetAppointmentById(id);

            if (theAppoint != null)
            {
                return Ok(_mapper.Map<AppointmentReadDto>(theAppoint));
            }

            return NotFound(); // Else

        }


        //Partial Update
        //PATCH api/colors/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialAppointmentUpdate(int id, JsonPatchDocument<AppointmentUpdateDto> patchDoc)
        {
            var appointModelFromRepo = _beautyBaseRepos.AppointmentRepository.GetAppointmentById(id);

            if (appointModelFromRepo == null)
            {
                return NotFound();
            }

            var appointToPatch = _mapper.Map<AppointmentUpdateDto>(appointModelFromRepo);
            patchDoc.ApplyTo(appointToPatch, ModelState);

            if (!TryValidateModel(appointToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(appointToPatch, appointModelFromRepo);

            _beautyBaseRepos.AppointmentRepository.UpdateAppointment(appointModelFromRepo);

            _beautyBaseRepos.SaveChanges();

            return NoContent();
        }
    }
}
