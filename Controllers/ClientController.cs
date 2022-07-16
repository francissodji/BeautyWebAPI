using AutoMapper;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Controllers
{

    public class ClientController : BaseController
    {

        private readonly IBeautyBaseRepository _beautyBaseRepos;

        private IMapper _mapper { get; }

        public ClientController(IBeautyBaseRepository beautyBaseRepos, IMapper mapper)
        {
            _beautyBaseRepos = beautyBaseRepos;

            _mapper = mapper;
        }



        [HttpGet]
        public ActionResult<IEnumerable<ClientReadDto>> LoadAllClients()
        {
            var listAllClient = _beautyBaseRepos.ClientRepository.GetAllClients();

            return Ok(_mapper.Map<IEnumerable<ClientReadDto>>(listAllClient));
        }


        //POST  api/users
        [HttpPost]
        public ActionResult<ClientReadDto> CreateClient(ClientCreateDto clientCreateDto)
        {


            // Create client
            clientCreateDto.IDUser = 2;//direct connect to fake id user client
            var clientModel = _mapper.Map<Client>(clientCreateDto);
            _beautyBaseRepos.ClientRepository.CreateClient(clientModel);
            _beautyBaseRepos.SaveChanges();

            var clientReadDto = _mapper.Map<ClientReadDto>(clientModel);

            return CreatedAtRoute(nameof(LoadClientById), new { Id = clientReadDto.IDClient }, clientReadDto);
            //return Ok(colorReadDto);
        }


        //GET api/client/2

        [HttpGet("{id}", Name = "LoadClientById")]
        //[Route("loadbyId")]
        public ActionResult<ClientReadDto> LoadClientById(int id)
        {
            var theClient= _beautyBaseRepos.ClientRepository.GetClientById(id);

            if (theClient != null)
            {
                return Ok(_mapper.Map<ClientReadDto>(theClient));
            }

            return NotFound(); // Else

        }


        [HttpGet("bycelphone/{celphone}")]
        public ActionResult<ClientReadDto> LoadClientByCelClient(string celphone)
        {
            var theClient = _beautyBaseRepos.ClientRepository.GetClientByCelClient(celphone);


            if (theClient != null)
            {
                return Ok(_mapper.Map<ClientReadDto>(theClient));
            }

            return NotFound(); // Else

        }
        
        
        [HttpGet("bylnameandphone/{lastName}/{celphone}")] //[HttpGet("{id}/{first}/{second}")]
        public ActionResult<ClientReadDto> LoadClientByLastNameAndCelNumber(string lastName, string celphone)
        {
            var theClient = _beautyBaseRepos.ClientRepository.GetClientByLastNameAndCelClient(lastName, celphone);


            if (theClient != null)
            {
                return Ok(_mapper.Map<ClientReadDto>(theClient));
            }

            return NotFound(); // Else

        }
        

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
        //PUT   api/colors/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateColor(int id, ColorUpdateDto colorUpdateDto)
        {
            var colorModelFromRepo = _beautyBaseRepos.ColorRepository.GetColorById(id);

            if (colorModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(colorUpdateDto, colorModelFromRepo);

            _beautyBaseRepos.ColorRepository.UpdateColor(colorModelFromRepo);

            _beautyBaseRepos.SaveChanges();

            return NoContent();
        }

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
