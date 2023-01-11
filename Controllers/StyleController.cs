
using AutoMapper;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;
using BeautyWebAPI.Services.FindConfiguration;
using BookingLibrary.Data;
using BookingLibrary.Dtos;
using BookingLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ConnectivityLibrary.Data;
using BeautyWebAPI.Services.ImagePaths;
using AutoMapper.Internal;
using System.ComponentModel.Design;

namespace BeautyWebAPI.Controllers
{
    public class StyleController : BaseController
    {
        private readonly IBookingData _bookingDataRepos;
        private readonly IConfiguration _configuration;
        private readonly IConnectivityData _connectivityDataRepos;
        private readonly string _connectionString;

        
        private IMapper _mapper { get; }

        

        public StyleController(IBookingData bookingDataRepos,
                                IConfiguration configuration,
                                IConnectivityData connectivityDataRepos,
                                IMapper mapper)
        {
            _configuration = configuration;
            _connectivityDataRepos = connectivityDataRepos;
            _bookingDataRepos = bookingDataRepos;
            _mapper = mapper;

            ConfigurationSettings configInfo = new ConfigurationSettings(configuration);
            _connectionString = configInfo.GetConnectionString();
        }


        //List all style
        [HttpGet("all/{idComp}")]
        public async Task<ActionResult<IEnumerable<StyleLibraryReadDto>>> LoadAllStyle(int idComp)
        {
            var listAllStyles = await _bookingDataRepos.GetAllStyleByIdCompany(_connectionString, idComp);

            ImagePaths imagePaths = new ImagePaths(_configuration, _connectivityDataRepos);
            string directoryPath = await imagePaths.GetFilesPaths(idComp, "STYLE", "DIRECTORYPATH");
            /*
            foreach (var style in listAllStyles)
            {
                style.PictureStyle = directoryPath +@"\"+ style.PictureStyle;
                Console.WriteLine("link : "+ style.PictureStyle);
            }
            */
            return Ok(_mapper.Map<IEnumerable<StyleLibraryReadDto>>(listAllStyles));
        }


        //Create new Size
        //Client registration Register//POST  api/users
        //[Authorize("Owner")]
        [HttpPost("newstyle")]
        public async Task<ActionResult<StyleLibraryReadDto>> CreateNewStyle(StyleLibraryCreateDto style)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong." });
                //return BadRequest();
            }

            Console.WriteLine(style.isHairProvided);

            StyleLibraryReadDto createdstyle = new StyleLibraryReadDto();

            try
            {
                StyleLibrary styleToCreate = _mapper.Map<StyleLibrary>(style);
                await _bookingDataRepos.CreateNewStyle(_connectionString, styleToCreate); //create the new style

                var latestStyleAdded = await _bookingDataRepos.GetLatestAddedStyle(_connectionString);
                createdstyle = _mapper.Map<StyleLibraryReadDto>(latestStyleAdded);
            }
            catch (Exception excp)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Issue while add the new style."+excp.Message });
            }

            return Ok(createdstyle);
            //return CreatedAtRoute(nameof(LoadStyleById), new { id = createdstyle.IdStyle }, createdstyle);
        }


        
        [HttpGet("{idStyle}", Name = "LoadStyleById")]
        //[Route("loadbyId")]
        public async Task<ActionResult<StyleLibraryReadDto>> LoadStyleById(int idStyle)
        {

            var style = await _bookingDataRepos.GetStyleById(_connectionString, idStyle);

            if (style != null)
            {
                return Ok(_mapper.Map<StyleLibraryReadDto>(style));
            }

            return NotFound(); // Else
        }


        /*
        [HttpGet("bystyleandsize/{idStyle}/{idSize}/{idCompany}")]
        public ActionResult<IEnumerable<LengthReadDto>> LoadAllLengthByStyleAndSize(int idStyle, int idSize, int idCompany)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];

            var listAllLengths = _bookingDataRepos.GetAllLengthByIdStyleAndIdSize(connectionString, idStyle, idSize, idCompany);

            List<LengthReadDto> listOfAllLength = new List<LengthReadDto>();

            if (listAllLengths != null)
            {
                foreach (var length in listAllLengths.Result)
                {
                    LengthReadDto alength = new LengthReadDto();

                    alength.IdLength = length.IdLength;
                    alength.TitleLength = length.TitleLength;
                    alength.IsDefault = length.IsDefault; // Need to control on the default or not - in case some company does not have style. Check in the company

                    listOfAllLength.Add(alength);
                }
            }

            return Ok(_mapper.Map<IEnumerable<LengthReadDto>>(listOfAllLength));
        }
        */

        //PUT   api/colors/{id}
        [HttpPut("update/{idStyle}")]
        public async Task<ActionResult<StyleLibraryReadDto>> UpdateStyle(int idStyle, StyleLibraryUpdateDto styleUpdateDto)
        {

            var styleFound = await _bookingDataRepos.GetStyleById(_connectionString, idStyle);

            if (styleFound == null)
            {
                return NotFound();
            }

            StyleLibraryReadDto styleLibraryReadDto = new StyleLibraryReadDto();

            try
            {
                StyleLibrary styleToUpdate = _mapper.Map<StyleLibrary>(styleUpdateDto);

                await _bookingDataRepos.UpdateStyle(_connectionString, idStyle, styleToUpdate);

                var updatedstyle = await _bookingDataRepos.GetStyleById(_connectionString, idStyle);

                styleLibraryReadDto = _mapper.Map<StyleLibraryReadDto>(updatedstyle); //Remap the updated value into read dto form

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(styleLibraryReadDto);
            //return CreatedAtRoute(nameof(LoadStyleById), new { id = styleLibraryReadDto.IdStyle }, styleLibraryReadDto); // return info of the updated compan
        }


        //DELETE api/color/{id}
        [HttpDelete("delete/{idStyle}")]
        public async Task<ActionResult> DeleteStyle(int idStyle)
        {

            var styleFound = await _bookingDataRepos.GetStyleById(_connectionString, idStyle);
            if (styleFound == null)
            {
                return NotFound();
            }
            await _bookingDataRepos.DeleteStyle(_connectionString, idStyle);

            return NoContent();
        }

    }
}
