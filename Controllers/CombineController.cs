using AutoMapper;
using BeautyWebAPI.Data.Interfaces;
using BookingLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BookingLibrary.Data;
using Microsoft.Extensions.Configuration;
using BookingLibrary.Dtos;
using BeautyWebAPI.Models;
using System.Threading.Tasks;
using BookingLibrary.Models;
using Microsoft.AspNetCore.Http;
using BeautyWebAPI.Services.FindConfiguration;

namespace BeautyWebAPI.Controllers
{
    public class CombineController : BaseController
    {
        private readonly IBookingData _bookingDataRepos;
        private readonly string _connectionString;
        private IMapper _mapper { get; }
        IConfiguration _configuration;

        public CombineController(IBookingData bookingDataRepos, IMapper mapper, IConfiguration configuration)
        {
            _bookingDataRepos = bookingDataRepos;
            _mapper = mapper;
            _configuration = configuration;
            ConfigurationSettings configInfo = new ConfigurationSettings(configuration);
            _connectionString = configInfo.GetConnectionString();
        }


        //Create Combine
        [HttpPost("newcombine")]
        public async Task<ActionResult<LengthLibraryReadDto>> CreateNewCombine(CombineLibraryCreateDto combine)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong." });
                //return BadRequest();
            }

            //check style exist
            StyleLibrary styleExist = await _bookingDataRepos.GetStyleById(_connectionString, combine.IdStyle);
            if (styleExist == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "The style does not exist. Imposible to continue." });
            }

            //check size exist
            SizeLibrary sizeExist = await _bookingDataRepos.GetSizeById(_connectionString, combine.IdSize);
            if (sizeExist == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "The size does not exist. Imposible to continue." });
            }

            //check length exist
            LengthLibrary lengthExist = await _bookingDataRepos.GetLengthById(_connectionString, combine.IdLength);
            if (lengthExist == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "The length does not exist. Imposible to continue." });
            }

            //check combine exist
            CombineLibrary combineExist = await _bookingDataRepos.GetCombinePricesByIDs(_connectionString, combine.IdCompany, combine.IdStyle, combine.IdSize, combine.IdLength);
            if (combineExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "The combination already exist. Imposible to continue." });
            }

            CombineLibraryReadDto createdCombine = new CombineLibraryReadDto();

            try
            {
                var combineToCreate = _mapper.Map<CombineLibrary>(combine);
                await _bookingDataRepos.CreateNewCombine(_connectionString, combineToCreate); //create the new combine

                var latestCombine = await _bookingDataRepos.GetLatestAddedCombine(_connectionString); //Find the latest created length
                createdCombine = _mapper.Map<CombineLibraryReadDto>(latestCombine);
            }
            catch (Exception excp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Issue while add the new length." });
            }

            return Ok(createdCombine);
        }


        //Get combine prices
        [HttpGet("pricing/{idCompany}/{idStyle}/{idSize}/{idLength}")]
        public async Task<ActionResult<CombineLibraryReadDto>> LoadCombinePricesByIDs(int idCompany, int idStyle, int idSize, int idLength)
        {
            var listAllCombine = await _bookingDataRepos.GetCombinePricesByIDs(_connectionString, idCompany, idStyle, idSize, idLength);

            CombineLibraryReadDto braidingPricing = new CombineLibraryReadDto();

            braidingPricing = _mapper.Map<CombineLibraryReadDto>(listAllCombine);

            return Ok(braidingPricing);
        }

        //Get combine length by Style and Size
        [HttpGet("combinelength/{idCompany}/{idStyle}/{idSize}")]
        public async Task<ActionResult<CombineLibraryReadDto>> LoadCombineLengthsByStyleAndSize(int idCompany, int idStyle, int idSize)
        {
            var listAllCombine = await _bookingDataRepos.GetAllLengthByIdStyleAndIdSize(_connectionString, idCompany, idStyle, idSize);

            CombineLibraryReadDto braidingPricing = new CombineLibraryReadDto();

            braidingPricing = _mapper.Map<CombineLibraryReadDto>(listAllCombine);

            return Ok(braidingPricing);
        }


 

        /*

        [HttpGet("bystyle/{idStyle}")]
        public ActionResult<IEnumerable<ExtratStyleReadDto>> LoadAllSizeByStyle(int idStyle)
        {
            var listAllsize = _beautyBaseRepos.ExtratStyleRepository.GetAllSizeByStyle(idStyle);

            List<ExtratStyleReadDto> listAllSizeWithLib = new List<ExtratStyleReadDto>();

            int theIdSize = 0; int k = 0;
            foreach (var item in listAllsize)
            {
                ExtratStyleReadDto anExtratStyle = new ExtratStyleReadDto();

                anExtratStyle.IdExtratStyle = item.IdExtratStyle;
                anExtratStyle.IdStyle = item.IdStyle;
                anExtratStyle.IdSize = item.IdSize;
                anExtratStyle.TitleSize = _beautyBaseRepos.SizeRepository.GetSizeById(item.IdSize).TitleSize;

                listAllSizeWithLib.Add(anExtratStyle);
            }

            return Ok(_mapper.Map<IEnumerable<ExtratStyleReadDto>>(listAllSizeWithLib));
        }

        */




        /*
        [HttpGet("braidingcost/{idStyle}/{idSize}/{idextrat}/{typeService}/{isTakeDown}")]
        public ActionResult<BraidingCost> LoadSpecificBraidingCost(int idStyle, int idSize, int idLength, char typeService, bool isTakeDown, int idCompany = 0)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];
            try
            {
                //CombineReadDto priceInCombine = new CombineReadDto();
                var priceForStyle = _bookingDataRepos.GetStyleById(connectionString,idStyle);

                var priceInCombine = _bookingDataRepos.GetCombinePricesByIDs(connectionString, idCompany, idStyle, idSize, idLength);
                CombineLibraryReadDto combineReadDto = _mapper.Map<CombineLibraryReadDto>(priceInCombine);


                BraidingCost theBraidingWithCost = new BraidingCost();

                if (priceInCombine != null && priceForStyle != null)
                {
                    theBraidingWithCost.IdStyle = idStyle;
                    theBraidingWithCost.IdSize = idSize;
                    theBraidingWithCost.IdLength = idLength;
                    theBraidingWithCost.TypeService = typeService;
                    theBraidingWithCost.IsTakeDown = isTakeDown;

                    theBraidingWithCost.CostStyle = (double)combineReadDto.CostStyle;
                    theBraidingWithCost.CostTakeDown = (double)combineReadDto.CostTakeDown;
                    theBraidingWithCost.CostTouchUp = (double)combineReadDto.CostTouchUp;
                    theBraidingWithCost.CostHairDeduct = (double)combineReadDto.CostHairDeduct;
                    theBraidingWithCost.CostStyleBusyTime = (double)combineReadDto.CostStyleBusyTime;


                    //Calculate Total Cost
                    theBraidingWithCost.TotalCost = 0;
                    theBraidingWithCost.TotalTouchUpCost = 0;
                    theBraidingWithCost.TotalExtraSizeLengthCost = 0;
                    
                    switch (typeService)
                    {
                        case 'F': // Full Service
                            theBraidingWithCost.TotalExtraSizeLengthCost = theBraidingWithCost.CostStyle + theBraidingWithCost.ESCostExtraSize + theBraidingWithCost.ESCostBusyExtra;
                            theBraidingWithCost.TotalCost += theBraidingWithCost.STCostStyle;
                            theBraidingWithCost.TotalCost += theBraidingWithCost.TotalExtraSizeLengthCost;

                            theBraidingWithCost.TotalCost -= theBraidingWithCost.ESCostHairDeductExtra; // Only when the hair is provided

                            if (isTakeDown)
                                theBraidingWithCost.TotalCost += theBraidingWithCost.STPriceTakeOffHair;
                            else
                                theBraidingWithCost.STPriceTakeOffHair = 0;
                            break;

                        case 'T': //Touch UP
                            theBraidingWithCost.TotalTouchUpCost = theBraidingWithCost.STCostTouchUp + theBraidingWithCost.ESCostTouchUpExtra;
                            theBraidingWithCost.TotalCost = theBraidingWithCost.TotalTouchUpCost;
                            theBraidingWithCost.STCostStyle = 0;
                            theBraidingWithCost.ESCostExtraSize = 0;
                            theBraidingWithCost.ESCostExtra = 0;
                            theBraidingWithCost.ESCostBusyExtra = 0;
                            theBraidingWithCost.ESCostHairDeductExtra = 0;
                            theBraidingWithCost.STPriceTakeOffHair = 0;
                            break;
                    }
                    
                }

                return Ok(theBraidingWithCost);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        */
    }
}
