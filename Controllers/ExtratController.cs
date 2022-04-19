using AutoMapper;
using BeautyWebAPI.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyWebAPI.DTOs;

namespace BeautyWebAPI.Controllers
{

    public class ExtratController : BaseController
    {
        private readonly IBeautyBaseRepository _beautyBaseRepos;

        private IMapper _mapper { get; }

        public ExtratController(IBeautyBaseRepository beautyBaseRepos, IMapper mapper)
        {
            _beautyBaseRepos = beautyBaseRepos;
            _mapper = mapper;
        }


        //List all size
        [HttpGet]
        public ActionResult<IEnumerable<ExtratReadDto>> LoadAllExtrat()
        {
            var listAllextrat = _beautyBaseRepos.ExtratRepository.GetAllExtrat();

            return Ok(_mapper.Map<IEnumerable<ExtratReadDto>>(listAllextrat));
        }


        [HttpGet("bystyleandsize/{idStyle}/{idSize}")]
        public ActionResult<IEnumerable<ExtratReadDto>> LoadAllExtratByStyleAndSize(int idStyle, int idSize)
        {
            var listAllextrat = _beautyBaseRepos.ExtratRepository.GetAllExtratByStyleAndSize(idStyle, idSize);

            List<ExtratReadDto> listOfAllLengths = new List<ExtratReadDto>();

            if (listAllextrat != null)
            {
                foreach (var item in listAllextrat)
                {
                    ExtratReadDto aLength = new ExtratReadDto();

                    aLength.IDExtrat = item.IdExtrat;
                    aLength.TitleExtrat = item.TitleExtrat;

                    listOfAllLengths.Add(aLength);
                }
            }
            
            return Ok(_mapper.Map<IEnumerable<ExtratReadDto>>(listOfAllLengths));
        }
    }
}
