
using AutoMapper;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Controllers
{
    public class StyleController : BaseController
    {
        private readonly IBeautyBaseRepository _beautyBaseRepos;

        private IMapper _theMapper { get; }

        public StyleController(IBeautyBaseRepository beautyBaseRepos, IMapper themapper)
        {
            _beautyBaseRepos = beautyBaseRepos;
            _theMapper = themapper;

        }


        [HttpGet]
        public ActionResult<IEnumerable<StyleReadDto>> LoadAllStyles()
        {
            //List<Style> listAllStyles;
            var listAllStyles = _beautyBaseRepos.StyleRepository.GetAllStyle();

            return Ok(_theMapper.Map<IEnumerable<StyleReadDto>>(listAllStyles));

            //return Ok(_mapper.Map<IEnumerable<ExtratReadDto>>(listAllextrat));
        }


        //GET api/client/2

        [HttpGet("{id}", Name = "LoadStyleById")]
        //[Route("loadbyId")]
        public ActionResult<StyleReadDto> LoadStyleById(int id)
        {
            var theStyle = _beautyBaseRepos.StyleRepository.GetStyleById(id);

            if (theStyle != null)
            {
                return Ok(_theMapper.Map<StyleReadDto>(theStyle));
            }

            return NotFound(); // Else

        }
    }
}
