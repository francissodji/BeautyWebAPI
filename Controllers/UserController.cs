using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeautyWebAPI.Data.Repositories;
using AutoMapper;
using BeautyWebAPI.Models;
using BeautyWebAPI.Data.Interfaces;
using Microsoft.AspNetCore.Cors;
using BeautyWebAPI.Services.PasswordHasher;
using BeautyWebAPI.Services;
using BeautyWebAPI.Services.TokenGenrator;

using ConnectivityLibrary.Models;
using ConnectivityLibrary.Data;
using Microsoft.Extensions.Configuration;
using AutoMapper.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using ConnectivityLibrary.Dtos;
using ConnectivityLibrary.ModelsHelper;
using System.ComponentModel.Design;

namespace BeautyWebAPI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IConnectivityData _connectivityDataRepos;
        private readonly IPasswordHasher _passwordHasher;
        private readonly TokenGenerator _tokenGenerator;
        private IMapper _mapper { get; }


        public UserController(
            IConfiguration configuration,
            IConnectivityData connectivityDataRepos, 
            IMapper mapper, 
            IPasswordHasher passwordHasher,
            TokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _connectivityDataRepos = connectivityDataRepos;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;

        }


        //Load all user
        [HttpGet]
        public ActionResult<IEnumerable<UserLibrary>> LoadAllUsers()
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];

            var listAllUsers = _connectivityDataRepos.GetAllUsers(connectionString);

            return Ok(_mapper.Map<IEnumerable<UserLibrary>>(listAllUsers));
        }


        //Load user by Id  ==> GET api/colors/2      
        [HttpGet("{id}", Name = "LoadUserById")]
        public ActionResult<UserLibraryReadDto> LoadUserById(int id)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];

            var theUser = _connectivityDataRepos.GetUserById(connectionString, id);

            if (theUser != null)
            {
                return Ok(_mapper.Map<UserLibraryReadDto>(theUser));
            }

            return NotFound(); // Else

        }


        //Client registration Register//POST  api/users
        [HttpPost("register")]
        public async Task<ActionResult<UserCreated>> CreateUserClient(RegisterLibrary register)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong." });
            }

            if (register.Password != register.ConfPassword)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Password and confirmation does not match." });
            }

            //check the existing email
            UserLibrary existingUserByEmail = await _connectivityDataRepos.GetUserByEmail(connectionString, register.Email);
            if (existingUserByEmail != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Email already exist." });
            }

            // Check the existing password
            UserLibrary existingUserByUsername = await _connectivityDataRepos.GetUserByUsername(connectionString, register.Username);
            if (existingUserByUsername != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Username already exist." });
            }
            
            //registration of user - Create New User
            string hashedPassword = _passwordHasher.HashPassword(register.Password); //convert to a hash
            register.Password = hashedPassword;


            UserCreated createdUserClient = new UserCreated();
            try
            {
                //var registerNewUser = _mapper.Map<RegisterLibrary>(register);

                await _connectivityDataRepos.CreateNewUser(connectionString, register); //create the new user/client

                switch (register.Role)
                {
                    case "CLIENT":
                        var newUserClientCreated = await _connectivityDataRepos.GetCompanyClientInfoByUsername(connectionString, register.Username); //get
                        createdUserClient.IdUser = newUserClientCreated.IdUser;
                        createdUserClient.Username = newUserClientCreated.Username;
                        createdUserClient.Id = newUserClientCreated.IdClient;
                        createdUserClient.Email = newUserClientCreated.EmailClient;
                        createdUserClient.Fname = newUserClientCreated.FnameClient;
                        createdUserClient.Mname = newUserClientCreated.MnameClient;
                        createdUserClient.Lname = newUserClientCreated.LnameClient;
                        createdUserClient.IdComp = newUserClientCreated.IdComp;
                        createdUserClient.SubDomaine = newUserClientCreated.SubDomaine;
                        break;

                    case "OWNER":
                    case "ASSOCIATE":
                    case "ADMIN":
                    case "SUPERADMIN":
                        var newUserAssociateCreated = await _connectivityDataRepos.GetCompanyAssociateInfoByUsername(connectionString, register.Username); //get
                        createdUserClient.IdUser = newUserAssociateCreated.IdUser;
                        createdUserClient.Username = newUserAssociateCreated.Username;
                        createdUserClient.Id =      newUserAssociateCreated.IdAssociate;
                        createdUserClient.Email = newUserAssociateCreated.EmailAssociate;
                        createdUserClient.Fname = newUserAssociateCreated.FnameAssociate;
                        createdUserClient.Mname = newUserAssociateCreated.MnameAssociate;
                        createdUserClient.Lname = newUserAssociateCreated.LnameAssociate;
                        createdUserClient.IdComp = newUserAssociateCreated.IdComp;
                        createdUserClient.SubDomaine = newUserAssociateCreated.SubDomaine;
                        break;
                    default:
                        break;
                }

            }
            catch (Exception excp)
            {
                throw;
            }

            return Ok(createdUserClient);
            //return CreatedAtRoute(nameof(LoadUserById), new { Id = createdUserClient.IdUser }, createdUserClient);
        }


        


        //api/account/

        [HttpPost("auth")]
        public async Task<IActionResult> Login([FromBody] UserLibraryLoginDto userLoginDto)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];

            string secreteKey = _configuration["JWT:Secret"];
            string theIssuer = _configuration["JWT:ValidIssuer"];
            string theAudience = _configuration["JWT:ValidAudience"];

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Please provide username or password" });
                //return BadRequest();
            }

            //Get the user
            UserLibrary user = await _connectivityDataRepos.GetUserByUsername(connectionString, userLoginDto.Username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Provided user does not exist" });
            }
            UserLibraryReadDto userDto = _mapper.Map<UserLibraryReadDto>(user);

            //Verify the user password
            bool isPasswordCorrect = _passwordHasher.VerifyPassword(userLoginDto.Password, user.PasswordHash);
            if (!isPasswordCorrect)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, new Response { Status = "Error", Message = "Incorrect password provided." });
            }

            string generatedToken = _tokenGenerator.GenerateToken(secreteKey, theIssuer, theAudience, userDto); //generate the token for the connected user

            bool isTokenValid = _tokenGenerator.IsTokenValid(secreteKey,theIssuer,theAudience, generatedToken);
            if (isTokenValid)
            {
                user.TokenUser = generatedToken;
                user.PasswordHash = "";
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new Response { Status = "Error", Message = "User not recognized." });
            }


            UserAuthentResponse userAuth = new UserAuthentResponse();

            switch (user.Role)
            {
                case "CLIENT":
                    //ClientLibrary clientConnected = await _connectivityDataRepos.GetClientByIdUser(connectionString, user.IdUser);
                    //ClientLibraryReadDto client = _mapper.Map<ClientLibraryReadDto>(clientConnected);

                    UserClientInCompanyLibrary clientInCompany = await _connectivityDataRepos.GetCompanyClientInfoByIdUser(connectionString, user.IdUser);
                    userAuth.IdUser = user.IdUser;
                    userAuth.Role = user.Role;
                    userAuth.IdClientBraider = clientInCompany.IdClient;
                    userAuth.FirstNClientBraider = clientInCompany.FnameClient;
                    userAuth.MiddleNClientBraider = clientInCompany.MnameClient;
                    userAuth.LastNClientBraider = clientInCompany.LnameClient;
                    userAuth.IdCompany = clientInCompany.IdComp;
                    userAuth.AccessTocken = user.TokenUser;
                    break;

                case "OWNER":
                case "ASSOCIATE":
                case "ADMIN":
                case "SUPERADMIN":
                    //AssociateLibrary associateConnected = await _connectivityDataRepos.GetAssociateByIdUser(connectionString, user.IdUser);
                    //AssociateLibraryReadDto associate = _mapper.Map<AssociateLibraryReadDto>(associateConnected); //This two commented line need a third call to get the company id

                    UserAssociateInCompanyLibrary associateInCompany = await _connectivityDataRepos.GetCompanyAssociateInfoByIdUser(connectionString, user.IdUser);
                    userAuth.IdUser = user.IdUser;
                    userAuth.Role = user.Role;
                    userAuth.IdClientBraider = associateInCompany.IdAssociate;
                    userAuth.FirstNClientBraider = associateInCompany.FnameAssociate;
                    userAuth.MiddleNClientBraider = associateInCompany.MnameAssociate;
                    userAuth.LastNClientBraider = associateInCompany.LnameAssociate;
                    userAuth.IdCompany = associateInCompany.IdComp;
                    userAuth.AccessTocken = user.TokenUser;
                    break;

                default:
                    break;
            }
            
            

            return Ok(userAuth);
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
