using AutoMapper;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.DTOs;
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


        [HttpGet("braidingcost/{idStyle}/{idSize}/{idextrat}")]
        public ActionResult<BraidingCost> LoadSpecificBraidingCost(int idStyle, int idSize, int idExtrat, char typeService, bool isTakeDown)
        {
            try
            {

                var priceForStyle = _beautyBaseRepos.StyleRepository.GetStyleById(idStyle);

                var priceInExtratStyle = _beautyBaseRepos.ExtratStyleRepository.GetAllExtratPrices(idStyle, idSize, idExtrat);


                BraidingCost theBraidingCost = new BraidingCost();
                if (listAllextsdsrat != null && priceForStyle != null)
                {
                    theBraidingCost.IdStyle = idStyle;
                    theBraidingCost.IdSize = idSize;
                    theBraidingCost.IdLength = idExtrat;
                    theBraidingCost.TypeService = typeService;
                    theBraidingCost.IsTakeDown = isTakeDown;
                    theBraidingCost.STCostStyle = (double)priceForStyle.CostStyle;
                    theBraidingCost.STCostTouchUp = (double)priceForStyle.CostTouchUp;
                    theBraidingCost.STPriceTakeOffHair = (double)priceForStyle.PriceTakeOffHair;
                    theBraidingCost.ESCostExtra = listAllextrat.;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

            return Ok(BraidingCost);
        }
    }
}
