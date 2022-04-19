using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeautyWebAPI.Data.Repositories;
using AutoMapper;
using BeautyWebAPI.DTOs;
using BeautyWebAPI.Models;
using BeautyWebAPI.Data.Interfaces;
using Microsoft.AspNetCore.Cors;
using BeautyWebAPI.Services.PasswordHasher;
using BeautyWebAPI.Services;
using BeautyWebAPI.Services.TokenGenrator;

namespace BeautyWebAPI.Controllers
{

    public class AccountController : BaseController
    {

        private readonly IBeautyBaseRepository _beautyBaseRepos;
        private readonly IPasswordHasher _passwordHasher;
        private readonly AccessTokenGenerator _accessTokenGenerator;

        private IMapper _mapper { get; }


        public AccountController(IBeautyBaseRepository beautyBaseRepos, IMapper mapper, IPasswordHasher passwordHasher,
            AccessTokenGenerator accessTokenGenerator)
        {
            _beautyBaseRepos = beautyBaseRepos;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _accessTokenGenerator = accessTokenGenerator;
        }


        //Load all user
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> LoadAllUsers()
        {
            var listAllUsers = _beautyBaseRepos.UserRepository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(listAllUsers));
        }


        //Load user by Id  ==> GET api/colors/2      
        [HttpGet("{id}", Name = "LoadUserById")]
        public ActionResult<UserReadDto> LoadUserById(int id)
        {
            var theUser = _beautyBaseRepos.UserRepository.GetUserById(id);

            if (theUser != null)
            {
                return Ok(_mapper.Map<UserReadDto>(theUser));
            }

            return NotFound(); // Else

        }


        //Client registration Register//POST  api/users
        [HttpPost("registerclient")]
        public async Task<ActionResult<UserReadDto>> CreateUser(Register register)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong." });
                //return BadRequest();
            }

            if (register.Password != register.ConfPassword)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Password and confirmation does not match." });
                //return BadRequest();
            }

            //check the existing email
            User existingUserByEmail = await _beautyBaseRepos.UserRepository.GetByEmail(register.Email);
            if (existingUserByEmail != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Email already exist." });
                //return Conflict();
            }

            // Check the existing password
            User existingUserByUsername = await _beautyBaseRepos.UserRepository.GetByUsername(register.UserName);
            if (existingUserByUsername != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Username already exist." });
                //return Conflict();
            }

            //registration of user - Create New User
            string hashedPassword = _passwordHasher.HashPassword(register.Password); //convert to a hash

            UserCreateDto userCreatedDto = new UserCreateDto 
            {
                Email = register.Email,
                Username = register.UserName,
                PasswordHash = hashedPassword,
                Dateuserexpire = DateTime.Today,
                Connectstate = false,
                IdProfil = 3
            };

            var userModel = _mapper.Map<User>(userCreatedDto);
            await _beautyBaseRepos.UserRepository.CreateUser(userModel);
            _beautyBaseRepos.SaveChanges();//user is created

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            if (userReadDto != null)
            {
                //***********Add Client
                ClientCreateDto clientCreateDto = new ClientCreateDto
                {
                    FnameClient = register.FirstName,
                    MnameClient = register.MiddleName,
                    LnameClient = register.LastName,
                    PhoneClient = register.Phone,
                    CelClient = register.Cel,
                    DOBClient = register.DOB,
                    SexClient = register.Sex,
                    EmailClient = register.Email,
                    StreetClient = register.Street,
                    StateClient = register.State,
                    CountyClient = register.County,
                    ZipCodeClient = register.ZipCode,
                    IDUser = userReadDto.IDUser
                };
             

                var clientAddedModel = _mapper.Map<Client>(clientCreateDto);
                await _beautyBaseRepos.ClientRepository.CreateClient(clientAddedModel);
                _beautyBaseRepos.SaveChanges();//client is created

                //***********************************
            }

            return CreatedAtRoute(nameof(LoadUserById), new { Id = userReadDto.IDUser }, userReadDto);
        }


        //api/account/
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginReadDto userLoginDto)
        {

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Please provide username or password" });
                //return BadRequest();
            }

            //Get the user
            User user = await _beautyBaseRepos.UserRepository.GetByUsername(userLoginDto.Username);

            if (user == null)
            {
                return Unauthorized();
            }

            //Verify the user password
            bool isPasswordCorrect = _passwordHasher.VerifyPassword(userLoginDto.Password, user.PasswordHash);
            if (!isPasswordCorrect)
            {
                return Unauthorized();
            }

            //recherche the user's other information

            string accessToken = _accessTokenGenerator.GenerateToken(user);

            //Find Client By Username
            Client client = await _beautyBaseRepos.ClientRepository.GetClientByIdUser(user.IDUser);


            //UserAuthentResponse user = new UserAuthentResponse();

            return Ok(new UserAuthentResponse()
            {
                AccessTocken = accessToken,
                //AccessUser = user
            }); 

            

            //***

            /*
            var user = await _beautyBaseRepos.UserRepository.Authenticate(userLoginDto.Username, userLoginDto.Password);
            

            if (user == null)
            {
                return NotFound();
            }

            var loginRes = new UserResponsDto();
            loginRes.Username = user.Username;
            loginRes.Token = "Token to be generated";


            return Ok(loginRes);
            */
        }


        /*
        //PUT   api/colors/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateColor(int id, ColorUpdateDto colorUpdateDto)
        {
            var colorModelFromRepo = _colorServiceReposit.GetColorById(id);

            if (colorModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(colorUpdateDto, colorModelFromRepo);

            _colorServiceReposit.UpdateColor(colorModelFromRepo);

            _colorServiceReposit.SaveChanges();

            return NoContent();
        }

        //PATCH api/colors/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialColorUpdate(int id, JsonPatchDocument<ColorUpdateDto> patchDoc)
        {
            var colorModelFromRepo = _colorServiceReposit.GetColorById(id);

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

            _colorServiceReposit.UpdateColor(colorModelFromRepo);

            _colorServiceReposit.SaveChanges();

            return NoContent();
        }

        //DELETE api/color/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteColor(int id)
        {
            var colorModelFromRepo = _colorServiceReposit.GetColorById(id);
            if (colorModelFromRepo == null)
            {
                return NotFound();
            }
            _colorServiceReposit.DeleteColor(colorModelFromRepo);

            _colorServiceReposit.SaveChanges();

            return NoContent();
        }

        */

    }
}
