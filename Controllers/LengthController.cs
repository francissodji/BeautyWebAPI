using AutoMapper;
using BeautyWebAPI.Models;
using BookingLibrary.Data;
using BookingLibrary.Dtos;
using BookingLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using BookingLibrary.DTOs;
using BeautyWebAPI.Services.FindConfiguration;

namespace BeautyWebAPI.Controllers
{
    public class LengthController : BaseController
    {
        private readonly IBookingData _bookingDataRepos;
        private IMapper _mapper { get; }
        private readonly string _connectionString;

        public LengthController(IBookingData bookingDataRepos, IMapper mapper, IConfiguration configuration)
        {
            _bookingDataRepos = bookingDataRepos;
            _mapper = mapper;

            ConfigurationSettings configInfo = new ConfigurationSettings(configuration);
            _connectionString = configInfo.GetConnectionString();
        }


        //List all size
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<LengthLibraryReadDto>>> LoadAllLengths()
        {

            var listAllLength = await _bookingDataRepos.GetAllLengths(_connectionString);

            List<LengthLibraryReadDto> lengthlist = new List<LengthLibraryReadDto>();

            foreach (var length in listAllLength)
            {
                LengthLibraryReadDto aLength = new LengthLibraryReadDto();
                aLength.IdLength = length.IdLength;
                aLength.TitleLength = length.TitleLength;
                aLength.IdCompany = length.IdCompany;
                aLength.IsDefault = length.IsDefault;
                lengthlist.Add(aLength);
            }

            return Ok(lengthlist);
        }



        //Create new length
        //Client registration Register//POST  api/users
        [HttpPost("newlength")]
        public async Task<ActionResult<LengthLibraryReadDto>> CreateNewLength(LengthLibraryCreateDto length)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong." });
                //return BadRequest();
            }

            LengthLibraryReadDto createdLength = new LengthLibraryReadDto();

            try
            {
                var lengthToCreate = _mapper.Map<LengthLibrary>(length);
                await _bookingDataRepos.CreateNewLength(_connectionString, lengthToCreate); //create the new length

                var latestLength = await _bookingDataRepos.GetLatestAddedLength(_connectionString); //Find the latest created length
                createdLength = _mapper.Map<LengthLibraryReadDto>(latestLength);
            }
            catch (Exception excp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Issue while add the new length."  });
            }

            return Ok(createdLength);
        }


        //PUT   api/colors/{id}
        [HttpPut("update/{idLength}")]
        public async Task<ActionResult> UpdateLength(int idLength, LengthLibraryUpdateDto lengthUpdateDto)
        {

            LengthLibraryReadDto lengthLibraryReadDto = new LengthLibraryReadDto();
            try
            {
                var lengthFound = _bookingDataRepos.GetLengthById(_connectionString, idLength);

                if (lengthFound == null)
                {
                    return NotFound();
                }

                var lengthToUpdate = _mapper.Map<LengthLibrary>(lengthUpdateDto);
                await _bookingDataRepos.UpdateLength(_connectionString, idLength, lengthToUpdate);

                //var updatedLength = await _bookingDataRepos.GetLengthById(connectionString, idLength);
                //lengthLibraryReadDto = _mapper.Map<LengthLibraryReadDto>(updatedLength); //Remap the updated value into read dto form
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }


        //Get
        [HttpGet("{idLength}", Name = "LoadLengthById")]
        //[Route("loadbyId")]
        public async Task<ActionResult<LengthLibraryReadDto>> LoadLengthById(int idLength)
        {
            var length = await _bookingDataRepos.GetLengthById(_connectionString, idLength);

            LengthLibraryReadDto lengthFound = new LengthLibraryReadDto();

            if (length != null)
            {
                lengthFound = _mapper.Map<LengthLibraryReadDto>(length);
                return Ok(lengthFound);
            }

            return NotFound(); // Else

        }



        [HttpGet("bystyleandsize/{idStyle}/{idSize}/{idCompany}")]
        public async Task<ActionResult<IEnumerable<LengthLibraryReadDto>>> LoadAllLengthByStyleAndSize(int idStyle, int idSize, int idCompany)
        {

            var listAllLengths = await _bookingDataRepos.GetAllLengthByIdStyleAndIdSize(_connectionString, idStyle, idSize, idCompany);

            List<LengthLibraryReadDto> lengthlist = new List<LengthLibraryReadDto>();

            foreach (var length in listAllLengths)
            {
                LengthLibraryReadDto aLength = new LengthLibraryReadDto();
                aLength.IdLength = length.IdLength;
                aLength.TitleLength = length.TitleLength;
                aLength.IdCompany = length.IdCompany;
                aLength.IsDefault = length.IsDefault;
                lengthlist.Add(aLength);
            }

            //_mapper.Map<IEnumerable<LengthLibraryReadDto>>(listAllLengths)
            return Ok(lengthlist);
        }


        //DELETE api/color/{id}
        [HttpDelete("delete/{idLength}")]
        public async Task<ActionResult> DeleteLength(int idLength)
        {
            var lengthFound = await _bookingDataRepos.GetLengthById(_connectionString, idLength);

            if (lengthFound == null)
            {
                return NotFound();
            }
            await _bookingDataRepos.DeleteLength(_connectionString, idLength);

            return NoContent();
        }
    }
}
