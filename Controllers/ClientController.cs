using AutoMapper;
using AutoMapper.Configuration;
using BeautyWebAPI.Data.Interfaces;
using BookingLibrary.Data;
using ConnectivityLibrary.Data;
using ConnectivityLibrary.Dtos;
using ConnectivityLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;



namespace BeautyWebAPI.Controllers
{

    public class ClientController : BaseController
    {

        private readonly IConnectivityData _connectivityDataRepos;
        private IMapper _mapper { get; }
        IConfiguration _configuration;

        public ClientController(IConnectivityData connectivityDataRepos, IMapper mapper, IConfiguration configuration)
        {
            _connectivityDataRepos = connectivityDataRepos;
            _mapper = mapper;
            _configuration = configuration;
        }



        [HttpGet("{idCompany}")]
        public async Task<ActionResult<IEnumerable<ClientLibraryReadDto>>> LoadAllClients(int idCompany)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];
            var listAllClient = await _connectivityDataRepos.GetAllClientsByIdCompany(connectionString, idCompany);

            return Ok(_mapper.Map<IEnumerable<ClientLibraryReadDto>>(listAllClient));
        }


        //GET api/client/2

        [HttpGet("{idClient}", Name = "LoadClientById")]
        //[Route("loadbyId")]
        public async Task<ActionResult<ClientLibraryReadDto>> LoadClientById(int idClient)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];

            var theClient= await _connectivityDataRepos.GetClientByIdClient(connectionString, idClient);

            if (theClient != null)
            {
                return Ok(_mapper.Map<ClientLibraryReadDto>(theClient));
            }

            return NotFound(); // Else

        }


        [HttpGet("bycelphone/{idCompany}/{celphone}")]
        public async Task<ActionResult<ClientLibraryReadDto>> LoadClientByCelClient(int idCompany, string celphone)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];

            var theClient = await _connectivityDataRepos.GetClientByCelClient(connectionString, idCompany, celphone);


            if (theClient != null)
            {
                return Ok(_mapper.Map<ClientLibraryReadDto>(theClient));
            }

            return NotFound(); // Else
        }
        
        
        
        
        //PUT   api/client/{id}
        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateClient(int id, ClientLibraryUpdateDto client)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];

            var clientFound = await _connectivityDataRepos.GetClientByIdClient(connectionString, id); // Verify if the given client Id passed in exists

            if (clientFound == null)
            {
                return NotFound();
            }

            ClientLibrary clientToUpdate = _mapper.Map<ClientLibrary>(client);

            await _connectivityDataRepos.UpdateClient(connectionString, id, clientToUpdate);

            return NoContent();
        }


        //POST  api/users
        /*
        [HttpPost]
        public ActionResult<ClientLibraryReadDto> CreateClient(ClientLibraryCreateDto clientCreateDto)
        {
            // Create client
            clientCreateDto.IdUser = 2;//direct connect to fake id user client
            var clientModel = _mapper.Map<ClientLibrary>(clientCreateDto);
            _connectionLibraryBaseRepos.ClientRepository.CreateClient(clientModel);
            _connectionLibraryBaseRepos.SaveChanges();

            var clientReadDto = _mapper.Map<ClientLibraryReadDto>(clientModel);

            return CreatedAtRoute(nameof(LoadClientById), new { Id = clientReadDto.IdClient }, clientReadDto);
            //return Ok(colorReadDto);
        }
        */


        /*
        [HttpGet("bylnameandphone/{lastName}/{celphone}")] //[HttpGet("{id}/{first}/{second}")]
        public ActionResult<ClientLibraryReadDto> LoadClientByLastNameAndCelNumber(string lastName, string celphone)
        {
            var theClient = _connectionLibraryBaseRepos.ClientRepository.GetClientByLastNameAndCelClient(lastName, celphone);


            if (theClient != null)
            {
                return Ok(_mapper.Map<ClientLibraryReadDto>(theClient));
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
        */


    }
}
