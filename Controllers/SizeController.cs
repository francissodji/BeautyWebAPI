using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeautyWebAPI.Data.Interfaces;
using AutoMapper;
using BeautyWebAPI.DTOs;
using ConnectivityLibrary.Data;
using BookingLibrary.Dtos;
using BookingLibrary.Data;
using Microsoft.Extensions.Configuration;
using AutoMapper.Configuration;
using BeautyWebAPI.Models;
using ConnectivityLibrary.Dtos;
using ConnectivityLibrary.Models;
using ConnectivityLibrary.ModelsHelper;
using BookingLibrary.Models;
using BookingLibrary.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using BeautyWebAPI.Services.FindConfiguration;

namespace BeautyWebAPI.Controllers
{

    public class SizeController : BaseController
    {

        private readonly IBookingData _bookingDataRepos;
        private IMapper _mapper { get; }
        private readonly string _connectionString;


        public SizeController(IBookingData bookingDataRepos, IMapper mapper, IConfiguration configuration)
        {
            _bookingDataRepos = bookingDataRepos;
            _mapper = mapper;

            ConfigurationSettings configInfo = new ConfigurationSettings(configuration);
            _connectionString = configInfo.GetConnectionString();
        }


        //List all size
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<SizeLibraryReadDto>>> LoadAllSize()
        {
            var listAllsizes = await _bookingDataRepos.GetAllSizes(_connectionString);

            List<SizeLibraryReadDto> listOfSizes = new List<SizeLibraryReadDto>();

            if (listAllsizes != null)
            {
                foreach (var size in listAllsizes)
                {
                    SizeLibraryReadDto theSize = new SizeLibraryReadDto();
                    theSize.IdSize = size.IdSize;
                    theSize.TitleSize = size.TitleSize;
                    theSize.IdCompany = size.IdCompany;
                    theSize.IsDefault = size.IsDefault;
                    listOfSizes.Add(theSize);
                }
            }
            //return Ok(_mapper.Map<IEnumerable<SizeLibraryReadDto>>(listAllsizes));
            return Ok(listOfSizes);
        }


        //Create new Size
        //Client registration Register//POST  api/users
        [HttpPost("newsize")]
        public async Task<ActionResult<SizeLibraryReadDto>> CreateNewSize(SizeLibraryCreateDto size)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong." });
                //return BadRequest();
            }

            SizeLibraryReadDto createdSize = new SizeLibraryReadDto();

            try
            {
                var newSize = _mapper.Map<SizeLibrary>(size);
                await _bookingDataRepos.CreateNewSize(_connectionString, newSize); //create the new size

                var latestStyle = await _bookingDataRepos.GetLatestAddedSize(_connectionString); //create the new size
                createdSize = _mapper.Map<SizeLibraryReadDto>(latestStyle);
            }
            catch (Exception excp)
            {
                throw;
            }

            return Ok(createdSize);
            //return CreatedAtRoute(nameof(LoadSizeById), new { Id = createdSize.IdSize }, createdSize);
        }


        [HttpGet("{id}", Name = "LoadSizeById")]
        //[Route("loadbyId")]
        public async Task<ActionResult<SizeLibraryReadDto>> LoadSizeById(int id)
        {

            var size = await _bookingDataRepos.GetSizeById(_connectionString, id);

            if (size != null)
            {
                return Ok(_mapper.Map<SizeLibraryReadDto>(size));
            }

            return NotFound(); // Else

        }


        [HttpGet("bystyle/{idCompany}/{idStyle}")]
        public ActionResult<IEnumerable<SizeLibraryReadDto>> LoadAllSizeByStyle(int idCompany, int idStyle)
        {
            var listAllsizes = _bookingDataRepos.GetAllSizesByIdStyle(_connectionString, idCompany, idStyle);

            List<SizeLibraryReadDto> listOfAllSizeByStyle = new List<SizeLibraryReadDto>();

            if (listAllsizes != null)
            {
                foreach (var size in listAllsizes.Result)
                {
                    SizeLibraryReadDto aSize = new SizeLibraryReadDto();

                    aSize.IdSize = size.IdSize;
                    aSize.TitleSize = size.TitleSize;
                    aSize.IsDefault = size.IsDefault; // Need to control on the default or not - in case some company does not have style. Check in the company
                    aSize.IdCompany = size.IdCompany;

                    listOfAllSizeByStyle.Add(aSize);
                }
            }

            return Ok(listOfAllSizeByStyle);
            //return Ok(_mapper.Map<IEnumerable<SizeLibraryReadDto>>(listOfAllSizeByStyle));
        }



        //PUT   api/colors/{id}
        [HttpPut("update/{idSize}")]
        public async Task<ActionResult<SizeLibraryReadDto>> UpdateSize(int idSize, SizeLibraryUpdateDto sizeUpdateDto)
        {

            var sizeFound = _bookingDataRepos.GetSizeById(_connectionString, idSize);

            if (sizeFound == null)
            {
                return NotFound();
            }

            //Update the size
            SizeLibrary sizeToUpdate = _mapper.Map<SizeLibrary>(sizeUpdateDto);
            await _bookingDataRepos.UpdateSize(_connectionString, idSize, sizeToUpdate);


            var updatedSize = await _bookingDataRepos.GetSizeById(_connectionString, idSize);//Get the update size
            SizeLibraryReadDto sizeLibraryReadDto = _mapper.Map<SizeLibraryReadDto>(updatedSize); //Remap the updated value into read dto form

            return Ok(sizeLibraryReadDto);
            //return CreatedAtRoute(nameof(LoadSizeById), new { Id = sizeLibraryReadDto.IdSize }, sizeLibraryReadDto); // return info of the updated company

        }

        //DELETE api/color/{id}
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteSize(int id)
        {

            var sizeFound = _bookingDataRepos.GetSizeById(_connectionString, id);
            if (sizeFound == null)
            {
                return NotFound();
            }

            _bookingDataRepos.DeleteSize(_connectionString, id);

            return NoContent();
        }

        /*
        //Partial Update
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
