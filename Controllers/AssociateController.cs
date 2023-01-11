using AutoMapper;
using BookingLibrary.Data;
using ConnectivityLibrary.Data;
using ConnectivityLibrary.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Controllers
{
    public class AssociateController : BaseController
    {
        /*
        private readonly IConnectivityData _bookingDataRepos;
        private IMapper _mapper { get; }

        public AssociateController(IConnectivityData bookingDataRepos, IMapper mapper)
        {
            _bookingDataRepos = bookingDataRepos;

            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<AssociateLibraryReadDto>> LoadAllAssociates()
        {
            var listAllAssociate = _connectionLibraryBaseRepos.AssociateRepository.GetAllAssociate();

            return Ok(_mapper.Map<IEnumerable<AssociateLibraryReadDto>>(listAllAssociate));
        }

        //POST  api/users
        [HttpPost]
        public ActionResult<AssociateLibraryReadDto> CreateAssociate(AssociateLibraryCreateDto AssociateCreateDto)
        {
            // Create Associate
            AssociateCreateDto.IdUserAssociate = 2;//direct connect to fake id user client
            var associateModel = _mapper.Map<AssociateLibrary>(AssociateCreateDto);
            _connectionLibraryBaseRepos.AssociateRepository.CreateAssociate(associateModel);
            _connectionLibraryBaseRepos.SaveChanges();

            var clientReadDto = _mapper.Map<AssociateLibraryReadDto>(associateModel);

            return CreatedAtRoute(nameof(LoadAssociateById), new { Id = clientReadDto.IdAssociate }, clientReadDto);
            //return Ok(colorReadDto);
        }


        //GET api/client/2

        [HttpGet("{id}", Name = "LoadAssociateById")]
        //[Route("loadbyId")]
        public ActionResult<AssociateLibraryReadDto> LoadAssociateById(int id)
        {
            var theAssociate = _connectionLibraryBaseRepos.AssociateRepository.GetAssociateById(id);

            if (theAssociate != null)
            {
                return Ok(_mapper.Map<AssociateLibraryReadDto>(theAssociate));
            }

            return NotFound(); // Else

        }


        [HttpGet("bycelphone/{celphone}")]
        public ActionResult<AssociateLibraryReadDto> LoadAssociateByCelAssociate(string celphone)
        {
            var theAssociate = _connectionLibraryBaseRepos.AssociateRepository.GetAssociateByCelAssociate(celphone);


            if (theAssociate != null)
            {
                return Ok(_mapper.Map<AssociateLibraryReadDto>(theAssociate));
            }

            return NotFound(); // Else

        }


        [HttpGet("associatebynameandphone/{lastName}/{celphone}")] //[HttpGet("{id}/{first}/{second}")]
        public ActionResult<AssociateLibraryReadDto> LoadAssociateByLastNameAndCelNumber(string lastName, string celphone)
        {
            var theAssociate = _connectionLibraryBaseRepos.AssociateRepository.GetAssociateByLastNameAndCelAssociate(lastName, celphone);


            if (theAssociate != null)
            {
                return Ok(_mapper.Map<AssociateLibraryReadDto>(theAssociate));
            }

            return NotFound(); // Else

        }

        
        //PUT   api/colors/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateAssociate(int id, AssociateLibraryUpdateDto associateUpdateDto)
        {
            var theAssociate = _connectionLibraryBaseRepos.AssociateRepository.GetAssociateById(id);

            if (theAssociate == null)
            {
                return NotFound();
            }

            _mapper.Map(associateUpdateDto, theAssociate);

            _connectionLibraryBaseRepos.AssociateRepository.UpdateAssociate(theAssociate);

            _connectionLibraryBaseRepos.SaveChanges();

            return NoContent();
        }
        */

        /*
        [HttpGet("{id}", Name = "SpLoadColorById")]
        //[Route("spload")]
        public ActionResult<ColorReadDto> SpLoadColorById(int id)
        {
            var theColor = _beautyBaseRepos.ColorRepository.StoreProcGetColorById(id);

            if (theColor != null)
            {
                return Ok(_mapper.Map<ColorReadDto>(theColor));
            }

            return NotFound(); // Else

        }
        */



        /*

        //PATCH api/colors/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialColorUpdate(int id, JsonPatchDocument<ColorUpdateDto> patchDoc)
        {
            var colorModelFromRepo = _beautyBaseRepos.ColorRepository.GetColorById(id);

            if (colorModelFromRepo == null)
            {
                return NotFound();
            }

            var colorToPatch = _mapper.Map<ColorUpdateDto>(colorModelFromRepo);
            patchDoc.ApplyTo(colorToPatch, ModelState);

            if (!TryValidateModel(colorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(colorToPatch, colorModelFromRepo);

            _beautyBaseRepos.ColorRepository.UpdateColor(colorModelFromRepo);

            _beautyBaseRepos.SaveChanges();

            return NoContent();
        }

        //DELETE api/color/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteColor(int id)
        {
            var colorModelFromRepo = _beautyBaseRepos.ColorRepository.GetColorById(id);
            if (colorModelFromRepo == null)
            {
                return NotFound();
            }
            _beautyBaseRepos.ColorRepository.DeleteColor(colorModelFromRepo);

            _beautyBaseRepos.SaveChanges();

            return NoContent();
        }
        */
        
    }
}
