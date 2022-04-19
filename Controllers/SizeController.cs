using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeautyWebAPI.Data.Interfaces;
using AutoMapper;
using BeautyWebAPI.DTOs;

namespace BeautyWebAPI.Controllers
{

    public class SizeController : BaseController
    {

        private readonly IBeautyBaseRepository _beautyBaseRepos;

        private IMapper _mapper { get; }

        public SizeController(IBeautyBaseRepository beautyBaseRepos, IMapper mapper)
        {
            _beautyBaseRepos = beautyBaseRepos;
            _mapper = mapper;
        }


        //List all size
        [HttpGet]
        public ActionResult<IEnumerable<SizeReadDto>> LoadAllSize()
        {
            var listAllsize = _beautyBaseRepos.SizeRepository.GetAllSize();

            return Ok(_mapper.Map<IEnumerable<SizeReadDto>>(listAllsize));
        }


        [HttpGet("bystyle/{idStyle}")]
        public ActionResult<IEnumerable<SizeReadDto>> LoadAllSizeByStyle(int idStyle)
        {
            var listAllsize = _beautyBaseRepos.SizeRepository.GetAllSizeByStyle(idStyle);

            List<SizeReadDto> listOfAllSizeByStyle = new List<SizeReadDto>();

            if (listAllsize != null)
            {
                foreach (var item in listAllsize)
                {
                    SizeReadDto aSigleSize = new SizeReadDto();

                    aSigleSize.IdSize = item.IdSize;
                    aSigleSize.TitleSize = item.TitleSize;

                    listOfAllSizeByStyle.Add(aSigleSize);
                }
            }
            

            return Ok(_mapper.Map<IEnumerable<SizeReadDto>>(listOfAllSizeByStyle));
        }


    }
}
