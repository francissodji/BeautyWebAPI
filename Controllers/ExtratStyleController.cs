using AutoMapper;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;
using BeautyWebAPI.ModelsHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Controllers
{

    public class ExtratStyleController : BaseController
    {

        private readonly IBeautyBaseRepository _beautyBaseRepos;

        private IMapper _mapper { get; }

        public ExtratStyleController(IBeautyBaseRepository beautyBaseRepos, IMapper mapper)
        {
            _beautyBaseRepos = beautyBaseRepos;

            _mapper = mapper;
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

        //Get Extrat prices
        [HttpGet("extratprices/{idStyle}/{idSize}/{idextrat}")]
        public ActionResult<IEnumerable<ExtratStyleReadDto>> LoadAllExtratPrices(int idStyle, int idSize, int idExtrat)
        {
            var listAllextrat = _beautyBaseRepos.ExtratStyleRepository.GetAllExtratPrices(idStyle, idSize, idExtrat);


            return Ok(_mapper.Map<IEnumerable<ExtratStyleReadDto>>(listAllextrat));
        }



        [HttpGet("braidingcost/{idStyle}/{idSize}/{idextrat}/{typeService}/{isTakeDown}")]
        public ActionResult<BraidingCost> LoadSpecificBraidingCost(int idStyle, int idSize, int idExtrat, char typeService, bool isTakeDown)
        {
            try
            {

                var priceForStyle = _beautyBaseRepos.StyleRepository.GetStyleById(idStyle);

                var priceInExtratStyle = _beautyBaseRepos.ExtratStyleRepository.GetAllExtratPrices(idStyle, idSize, idExtrat);

                BraidingCost theBraidingWithCost = new BraidingCost();

                if (priceInExtratStyle != null && priceForStyle != null)
                {
                    theBraidingWithCost.IdStyle = idStyle;
                    theBraidingWithCost.IdSize = idSize;
                    theBraidingWithCost.IdLength = idExtrat;
                    theBraidingWithCost.TypeService = typeService;
                    theBraidingWithCost.IsTakeDown = isTakeDown;

                    theBraidingWithCost.STCostStyle = (double)priceForStyle.CostStyle;
                    theBraidingWithCost.STCostTouchUp = (double)priceForStyle.CostTouchUp;
                    theBraidingWithCost.STPriceTakeOffHair = (double)priceForStyle.PriceTakeOffHair;

                    foreach (var abraidingPrice in priceInExtratStyle) // There should be only one line in 
                    {
                        theBraidingWithCost.ESCostExtra = abraidingPrice.CostExtra;
                        theBraidingWithCost.ESCostTouchUpExtra = abraidingPrice.CostExtra;
                        theBraidingWithCost.ESCostExtraSize = abraidingPrice.CostExtraSize;
                        theBraidingWithCost.ESCostBusyExtra = abraidingPrice.CostBusyExtra;
                        theBraidingWithCost.ESCostHairDeductExtra = abraidingPrice.CostHairDeductExtra;
                    }
                    
                    //Calculate Total Cost
                    theBraidingWithCost.TotalCost = 0;
                    theBraidingWithCost.TotalTouchUpCost = 0;
                    theBraidingWithCost.TotalExtraSizeLengthCost = 0;
                    switch (typeService)
                    {
                        case 'F': // Full Service
                            theBraidingWithCost.TotalExtraSizeLengthCost = theBraidingWithCost.ESCostExtra + theBraidingWithCost.ESCostExtraSize + theBraidingWithCost.ESCostBusyExtra;
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
    }
}
