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

    public class StateController : BaseController
    {
        private readonly IBeautyBaseRepository _beautyBaseRepos;

        private IMapper _mapper { get; }

        public StateController(IBeautyBaseRepository beautyBaseRepos, IMapper mapper)
        {
            _beautyBaseRepos = beautyBaseRepos;

            _mapper = mapper;
        }


        /*
        [HttpGet]
        public ActionResult<IEnumerable<StateReadDto>> LoadAllStates()
        {
            var listAllState = _beautyBaseRepos.StateRepository.GetAllState();

            return Ok(_mapper.Map<IEnumerable<StateReadDto>>(listAllState));
        }
        */
    }
}
