using BookingLibrary.Dtos;
using BookingLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using AutoMapper;
using BookingLibrary.Data;
using Microsoft.Extensions.Configuration;
using BeautyWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Net.Http.Headers;
using BeautyWebAPI.Services.FindConfiguration;
using BookingLibrary.ModelsHelper;
using System.Drawing;

namespace BeautyWebAPI.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly IBookingData _bookingDataRepos;
        private IMapper _mapper { get; }
        private readonly string _connectionString;

        public CatalogController(IBookingData bookingDataRepos, IMapper mapper, IConfiguration configuration)
        {
            _bookingDataRepos = bookingDataRepos;
            _mapper = mapper;

            ConfigurationSettings configInfo = new ConfigurationSettings(configuration);
            _connectionString = configInfo.GetConnectionString();
        }


        //Create new length
        //Client registration Register//POST  api/users
        [HttpPost("newcatalog")]
        public async Task<ActionResult<CatalogLibraryReadDto>> CreateNewCatalog(CatalogLibraryCreateDto catalog)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong." });
            }

            CatalogLibraryReadDto createdcatalog = new CatalogLibraryReadDto();

            try
            {
                var catalogToCreate = _mapper.Map<CatalogLibrary>(catalog);
                await _bookingDataRepos.CreateNewCatalog(_connectionString, catalogToCreate); //create the new catalog

                var latestCatalog = await _bookingDataRepos.GetLatestAddedCatalog(_connectionString); //Find the latest created catalog
                createdcatalog = _mapper.Map<CatalogLibraryReadDto>(latestCatalog);
            }
            catch (Exception excp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Issue while add the new catalog." });
            }

            return Ok(createdcatalog);
        }



        //PUT   api/colors/{id}
        [HttpPut("update/{idCatalog}")]
        public async Task<ActionResult> UpdateLength(int idCatalog, CatalogLibraryUpdateDto lengthUpdateDto)
        {
            CatalogLibraryReadDto catalogLibraryReadDto = new CatalogLibraryReadDto();
            try
            {
                var catalogFound = _bookingDataRepos.GetCatalogById(_connectionString, idCatalog);

                if (catalogFound == null)
                {
                    return NotFound();
                }

                var catalogToUpdate = _mapper.Map<CatalogLibrary>(lengthUpdateDto);
                await _bookingDataRepos.UpdateCatalog(_connectionString, idCatalog, catalogToUpdate);

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
        [HttpGet("{idCatalog}", Name = "LoadCatalogById")]
        //[Route("loadbyId")]
        public async Task<ActionResult<CatalogLibraryReadDto>> LoadCatalogById(int idCatalog)
        {

            var catalog = await _bookingDataRepos.GetCatalogById(_connectionString, idCatalog);

            CatalogLibraryReadDto CatalogFound = new CatalogLibraryReadDto();

            if (catalog != null)
            {
                CatalogFound = _mapper.Map<CatalogLibraryReadDto>(catalog);
                return Ok(CatalogFound);
            }

            return NotFound(); // Else

        }

        
        
        [HttpGet("byallparams/{idCompany}/{idStyle}/{idSize}/{idLength}")]
        public async Task<ActionResult<IEnumerable<CatalogCombine>>> LoadAllCatalogByAllParams(int idCompany, int idStyle, int idSize, int idLength)
        {

            var listAllcatalog = await _bookingDataRepos.GetAllCatalogByAllParams(_connectionString, idCompany, idStyle, idSize, idLength);

            List<CatalogCombine> cataloglist = new List<CatalogCombine>();

            foreach (var catalog in listAllcatalog)
            {
                CatalogCombine aCatalog = new CatalogCombine();
                aCatalog.IdCatalog = catalog.IdCatalog;
                aCatalog.ImageLink = catalog.ImageLink;
                aCatalog.IdCombine = catalog.IdCombine;
                aCatalog.IdCompany = catalog.IdCompany;
                aCatalog.IdStyle = catalog.IdStyle;
                aCatalog.TitleStyle = catalog.TitleStyle;
                aCatalog.IdSize = catalog.IdSize;
                aCatalog.TitleSize = catalog.TitleSize;
                aCatalog.IdLength = catalog.IdLength;
                aCatalog.TitleLength = catalog.TitleLength;
                aCatalog.CostStyle = catalog.CostStyle;
                aCatalog.CostTakeDown = catalog.CostTakeDown;
                aCatalog.CostTouchUp = catalog.CostTouchUp;
                aCatalog.CostHairDeduct = catalog.CostHairDeduct;
                aCatalog.CostStyleBusyTime = catalog.CostStyleBusyTime;

                cataloglist.Add(aCatalog);
            }

            return Ok(cataloglist);
        }

        [HttpGet("bycompanyandstyle/{idCompany}/{idStyle}")]
        public async Task<ActionResult<IEnumerable<CatalogLibraryReadDto>>> LoadAllCatalogByIdCompanyAndStyle(int idCompany, int idStyle)
        {

            var listAllcatalog = await _bookingDataRepos.GetAllCatalogByIdCompanyAndStyle(_connectionString, idCompany, idStyle);

            List<CatalogLibraryReadDto> cataloglist = new List<CatalogLibraryReadDto>();

            foreach (var catalog in listAllcatalog)
            {
                CatalogLibraryReadDto aCatalog = new CatalogLibraryReadDto();
                aCatalog.IdCatalog = catalog.IdCatalog;
                aCatalog.ImageLink = catalog.ImageLink;
                //aCatalog.IdStyle = catalog.IdCombine;
                aCatalog.IdCompany = catalog.IdCompany;

                cataloglist.Add(aCatalog);
            }

            return Ok(cataloglist);
        }

        //[Authorize]
        [HttpGet("bycompany/{idCompany}")]
        public async Task<ActionResult<IEnumerable<CatalogLibraryReadDto>>> LoadAllCatalogByIdCompany(int idCompany)
        {

            var listAllcatalog = await _bookingDataRepos.GetAllCatalogByIdCompany(_connectionString, idCompany);

            List<CatalogLibraryReadDto> cataloglist = new List<CatalogLibraryReadDto>();

            foreach (var catalog in listAllcatalog)
            {
                CatalogLibraryReadDto aCatalog = new CatalogLibraryReadDto();
                aCatalog.IdCatalog = catalog.IdCatalog;
                aCatalog.ImageLink = catalog.ImageLink;
                //aCatalog.IdStyle = catalog.IdStyle;
                aCatalog.IdCompany = catalog.IdCompany;

                cataloglist.Add(aCatalog);
            }

            return Ok(cataloglist);
        }



        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CatalogLibraryReadDto>>> LoadAllCatalog()
        {

            var listAllcatalog = await _bookingDataRepos.GetAllCatalog(_connectionString);

            List<CatalogLibraryReadDto> cataloglist = new List<CatalogLibraryReadDto>();

            foreach (var catalog in listAllcatalog)
            {
                CatalogLibraryReadDto aCatalog = new CatalogLibraryReadDto();
                aCatalog.IdCatalog = catalog.IdCatalog;
                //aCatalog.ImageLink = catalog.ImageLink;
                //aCatalog.IdStyle = catalog.IdStyle;

                cataloglist.Add(aCatalog);
            }

            return Ok(cataloglist);
        }


        [HttpDelete("delete/{idCatalog}")]
        public async Task<ActionResult> DeleteCatalog(int idCatalog)
        {

            var catalogFound = await _bookingDataRepos.GetCatalogById(_connectionString, idCatalog);

            if (catalogFound == null)
            {
                return NotFound();
            }

            await _bookingDataRepos.DeleteCatalog(_connectionString, idCatalog);

            return NoContent();
        }

    }
}
