using AutoMapper;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Controllers
{

    public class ColorController : BaseController
    {
        /*
        private readonly IBeautyBaseRepository _beautyBaseRepos;

        private IMapper _mapper { get; } 

        public ColorController(IBeautyBaseRepository beautyBaseRepos, IMapper mapper)
        {
            _beautyBaseRepos = beautyBaseRepos;

            _mapper = mapper;
        }



        [HttpGet]
        public ActionResult<IEnumerable<ColorReadDto>> LoadAllColors()
        {
            var listAllColors = _beautyBaseRepos.ColorRepository.GetAllColor();

            return Ok(_mapper.Map<IEnumerable<ColorReadDto>>(listAllColors));
        }


        //GET api/colors/2
        
        [HttpGet("{id}", Name = "LoadColorById")]
        //[Route("load")]
        public ActionResult<ColorReadDto> LoadColorById(int id)
        {
            var theColor = _beautyBaseRepos.ColorRepository.GetColorById(id);

            if (theColor != null)
            {
                return Ok(_mapper.Map<ColorReadDto>(theColor));
            }

            return NotFound(); // Else

        }
        

        [HttpGet("{id}", Name = "SpLoadColorById")]
        //[Route("spload")]
        public ActionResult<ColorReadDto> SpLoadColorById(int id)
        {
            var theColor = _beautyBaseRepos.ColorRepository.StoreProcGetColorById(id);

            if (theColor != null)
            {
                return Ok(_mapper.Map<ColorReadDto>(theColor));
            }

            return NotFound(); // Else

        }

        //POST  api/users
        [HttpPost]
        public ActionResult<ColorReadDto> CreateColor(ColorCreateDto colorCreateDto)
        {
            var colorModel = _mapper.Map<Color>(colorCreateDto);
            _beautyBaseRepos.ColorRepository.CreateColor(colorModel);
            _beautyBaseRepos.SaveChanges();

            var colorReadDto = _mapper.Map<ColorReadDto>(colorModel);

            return CreatedAtRoute(nameof(SpLoadColorById), new { Id = colorReadDto.IdColor }, colorReadDto);
            //return Ok(colorReadDto);
        }


        

        
        //PUT   api/colors/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateColor(int id, ColorUpdateDto colorUpdateDto)
        {
            var colorModelFromRepo = _beautyBaseRepos.ColorRepository.GetColorById(id);

            if (colorModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(colorUpdateDto, colorModelFromRepo);

            _beautyBaseRepos.ColorRepository.UpdateColor(colorModelFromRepo);

            _beautyBaseRepos.SaveChanges();

            return NoContent();
        }

        //Partial Update
        //PATCH api/colors/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialColorUpdate(int id, JsonPatchDocument<ColorUpdateDto> patchDoc)
        {
            var colorModelFromRepo = _beautyBaseRepos.ColorRepository.GetColorById(id);

            if (colorModelFromRepo == null)
            {
                return NotFound();
            }

            var colorToPatch = _mapper.Map<ColorUpdateDto>(colorModelFromRepo);
            patchDoc.ApplyTo(colorToPatch, ModelState);

            if (!TryValidateModel(colorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(colorToPatch, colorModelFromRepo);

            _beautyBaseRepos.ColorRepository.UpdateColor(colorModelFromRepo);

            _beautyBaseRepos.SaveChanges();

            return NoContent();
        }

        //DELETE api/color/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteColor(int id)
        {
            var colorModelFromRepo = _beautyBaseRepos.ColorRepository.GetColorById(id);
            if (colorModelFromRepo == null)
            {
                return NotFound();
            }
            _beautyBaseRepos.ColorRepository.DeleteColor(colorModelFromRepo);

            _beautyBaseRepos.SaveChanges();

            return NoContent();
        }

        */
    }


}
