using AutoMapper;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Controllers
{
    public class DiscountController : BaseController
    {
        private readonly IBeautyBaseRepository _beautyBaseRepos;
        private IMapper _mapper { get; }

        public DiscountController(IBeautyBaseRepository beautyBaseRepos, IMapper mapper)
        {
            _beautyBaseRepos = beautyBaseRepos;
            _mapper = mapper;
        }

        /*
        [HttpGet("disc")]
        public ActionResult<IEnumerable<Discount>> LoadAllDiscount()
        {
            
            var listAllDiscount = _beautyBaseRepos.DiscountRepository.GetAllDiscount();

            return Ok(_mapper.Map<IEnumerable<DiscountReadDto>>(listAllDiscount));
            
        
        }
        */
    }
}
