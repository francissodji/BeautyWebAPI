using AutoMapper;
using BeautyWebAPI.Data.Interfaces;
using BeautyWebAPI.Models;
using BeautyWebAPI.Services.PasswordHasher;
using BeautyWebAPI.Services.TokenGenrator;
using BookingLibrary.Dtos;
using BookingLibrary.Models;
using ConnectionLibrary.ModelsHelper;
using ConnectivityLibrary.Data;
using ConnectivityLibrary.Dtos;
using ConnectivityLibrary.Models;
using ConnectivityLibrary.ModelsHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Controllers
{
    public class CompanyController : BaseController
    {

        private readonly IConnectivityData _connectivityDataRepos;
        private readonly IPasswordHasher _passwordHasher;
        private readonly TokenGenerator _accessTokenGenerator;
        private readonly IConfiguration _configuration;
        private IMapper _mapper { get; }

        public CompanyController(IConnectivityData connectivityDataRepos, 
            IMapper mapper, 
            IConfiguration configuration,
            IPasswordHasher passwordHasher,
            TokenGenerator accessTokenGenerator)
        {
            _connectivityDataRepos = connectivityDataRepos;
            _mapper = mapper;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
            _accessTokenGenerator = accessTokenGenerator;
        }


        /*
        [HttpGet]
        public ActionResult<IEnumerable<CompanyLibraryReadDto>> LoadAllCompanies()
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];

            var listAllColors = _connectivityDataRepos.GetAllCompanies();

            return Ok(_mapper.Map<IEnumerable<CompanyLibraryReadDto>>(listAllColors));
        }
        */

        //Create new Size
        //Client registration Register//POST  api/users
        
        [HttpPost("newcompany")]
        public async Task<ActionResult<CompanyLibraryReadDto>> CreateNewCompany(RegisterLibraryCreateDto register)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];

            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong." });
            }

            var componyExist = await _connectivityDataRepos.GetCompanyBySubdomaine(connectionString, register.SubDomaine);
            if (componyExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Company with subdomaine '"+register.SubDomaine+"' already exist." });
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
            string hashedPWSuperAdmin = _passwordHasher.HashPassword("@SuperAdministrator#"); //Superadminpassword
            register.Role = "OWNER";
            register.Password = hashedPassword;
            register.SuperAdminPW = hashedPWSuperAdmin;

            try
            {
                //First Create the Owner
                var registerNewUser = _mapper.Map<RegisterLibrary>(register);
                await _connectivityDataRepos.CreateNewCompany(connectionString, registerNewUser); //create the new Company and Owner
            }
            catch (Exception excp)
            {
                throw;
            }

            return NoContent();
        }

        //GET api/colors/2

        [HttpGet("{id}", Name = "LoadCompanyById")]
        //[Route("load")]
        public async Task<ActionResult<CompanyLibraryReadDto>> LoadCompanyById(int id)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];

            var theCompany = await _connectivityDataRepos.GetCompanyById(connectionString, id);

            if (theCompany != null)
            {
                return Ok(_mapper.Map<CompanyLibraryReadDto>(theCompany));
            }

            return NotFound(); // Else
        }


        [HttpGet("bysubdomain/{subdomain}", Name = "LoadCompanyBySubdomain")]
        //[Route("spload")]
        public async Task<ActionResult<CompanyLibraryReadDto>> LoadCompanyBySubdomain(string subdomain)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];

            var theCompany = await _connectivityDataRepos.GetCompanyBySubdomaine(connectionString, subdomain);

            if (theCompany != null)
            {
                return Ok(_mapper.Map<CompanyLibraryReadDto>(theCompany));
            }

            return NotFound(); // Else

        }

        [HttpPut("update/{idComp}")]
        public async Task<ActionResult<CompanyLibraryReadDto>> UpdateCompany(int idComp, CompanyLibraryUpdateDto companyLibraryUpdateDto)
        {
            string connectionString = _configuration["ConnectionStrings:BeautyConnection"];


            //Update the company's info
            var companytoUpdate = _mapper.Map<CompanyLibrary>(companyLibraryUpdateDto);
            await _connectivityDataRepos.UpdateCompany(connectionString, idComp, companytoUpdate);

            
            var updatedComp = await _connectivityDataRepos.GetCompanyById(connectionString, idComp); //Get the updated values

            CompanyLibraryReadDto companyLibraryReadDto = new CompanyLibraryReadDto();
            companyLibraryReadDto = _mapper.Map<CompanyLibraryReadDto>(updatedComp); //Remap the updated value into read dto form

            return CreatedAtRoute(nameof(LoadCompanyById), new { Id = companyLibraryReadDto.IdComp }, companyLibraryReadDto); // return info of the updated company
        }
        

        /*
        //Partial Update
        //PATCH api/colors/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialColorUpdate(int id, JsonPatchDocument<CompanyLibraryUpdateDto> patchDoc)
        {
            var companyModelFromRepo = _beautyBaseRepo.CompanyRepository.GetCompanyById(id);

            if (companyModelFromRepo == null)
            {
                return NotFound();
            }

            var colorToPatch = _mapper.Map<CompanyLibraryUpdateDto>(companyModelFromRepo);
            patchDoc.ApplyTo(colorToPatch, ModelState);

            if (!TryValidateModel(colorToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(colorToPatch, companyModelFromRepo);

            _beautyBaseRepo.CompanyRepository.UpdateCompany(companyModelFromRepo);

            _beautyBaseRepo.SaveChanges();

            return NoContent();
        }
        */

        /*
        //DELETE api/color/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteColor(int id)
        {
            var companyModelFromRepo = _beautyBaseRepo.CompanyRepository.GetCompanyById(id);
            if (companyModelFromRepo == null)
            {
                return NotFound();
            }
            _beautyBaseRepo.CompanyRepository.DeleteCompany(companyModelFromRepo);

            _beautyBaseRepo.SaveChanges();

            return NoContent();
        }
        */

        /*
        //POST  api/users
        [HttpPost("newcompany")]
        //public ActionResult<CompanyLibraryReadDto> CreateCompany(CompanyLibraryCreateDto companyCreateDto)
        public ActionResult<CompanyLibraryReadDto> UpdateCompany(CompanyNewSubscription compNewSubscr)
        {

            CompanyLibrary existingCompany = _beautyBaseRepo.CompanyRepository.GetCompanyBySubdomaine(compNewSubscr.SubDomaine);

            if (existingCompany != null)
            {
                return StatusCode(StatusCodes.Status208AlreadyReported, new Response { Status = "Error", Message = "A company with subdomaine "+ compNewSubscr.SubDomaine + " already exist." });
            }

            CompanyLibraryCreateDto companyCreateDto = new CompanyLibraryCreateDto();

            companyCreateDto.AcronymComp = compNewSubscr.AcronymComp;
            companyCreateDto.DesignationComp = compNewSubscr.DesignationComp;
            companyCreateDto.PhoneOffice = compNewSubscr.PhoneOffice;
            companyCreateDto.PhoneOwner = compNewSubscr.PhoneOwner;
            companyCreateDto.IdOwnerBraider = compNewSubscr.IdOwnerBraider;
            companyCreateDto.PartPayeBraid = compNewSubscr.PartPayeBraid;
            companyCreateDto.CostHairDeduct = compNewSubscr.CostHairDeduct;
            companyCreateDto.CostTakeDown = compNewSubscr.CostTakeDown;
            companyCreateDto.IdMainRegister = compNewSubscr.IdMainRegister;
            companyCreateDto.StateTaxOnSale = compNewSubscr.StateTaxOnSale;
            companyCreateDto.StateTaxOnBraiding = compNewSubscr.StateTaxOnBraiding;
            companyCreateDto.StreetComp = compNewSubscr.StreetComp;
            companyCreateDto.CountyComp = compNewSubscr.CountyComp;
            companyCreateDto.ZipcodeComp = compNewSubscr.ZipcodeComp;
            companyCreateDto.StateComp = compNewSubscr.StateComp;
            companyCreateDto.EmailComp = compNewSubscr.EmailComp;
            companyCreateDto.WebsiteComp = compNewSubscr.WebsiteComp;
            companyCreateDto.SubDomaine = compNewSubscr.SubDomaine;
            companyCreateDto.CreationDate = compNewSubscr.CreationDate;
            companyCreateDto.DateWorkMond = compNewSubscr.DateWorkMond;
            companyCreateDto.DateWorkTues = compNewSubscr.DateWorkTues;
            companyCreateDto.DateWorkWed = compNewSubscr.DateWorkWed;
            companyCreateDto.DateWorkThur = compNewSubscr.DateWorkThur;
            companyCreateDto.DateWorkFrid = compNewSubscr.DateWorkFrid;
            companyCreateDto.DateWorkSatu = compNewSubscr.DateWorkSatu;
            companyCreateDto.DateWorkSund = compNewSubscr.DateWorkSund;
            companyCreateDto.TimeWorkBegin = compNewSubscr.TimeWorkBegin;
            companyCreateDto.TimeWorkEnd = compNewSubscr.TimeWorkEnd;
            companyCreateDto.AcceptPartialPay = compNewSubscr.AcceptPartialPay;
            companyCreateDto.PercentPayPartialPay = compNewSubscr.PercentPayPartialPay;
            companyCreateDto.AmountPayPartialPay = compNewSubscr.AmountPayPartialPay;
            companyCreateDto.MaxBraider = compNewSubscr.MaxBraider;


            var companyModel = _mapper.Map<CompanyLibrary>(companyCreateDto);
            _beautyBaseRepo.CompanyRepository.CreateCompany(companyModel);
            _beautyBaseRepo.SaveChanges();

            var companyReadDto = _mapper.Map<CompanyLibraryReadDto>(companyModel);

            //Create a new account
            var accountReadDto = new AccountLibraryReadDto();

            DateTime dateNow = DateTime.Now;
            AccountLibraryCreateDto accountCreateDto = new AccountLibraryCreateDto(){ DateAddedAccount = dateNow };

            var account = _mapper.Map<AccountLibrary>(accountCreateDto);
            _connectionLibraryBaseRepos.AccountRepository.CreateAccount(account);
            _beautyBaseRepo.SaveChanges();
            accountReadDto = _mapper.Map<AccountLibraryReadDto>(account);


            //Create New Subscription
            SubscriptionLibraryReadDto subscriptionReadDto = new SubscriptionLibraryReadDto();
            SubscriptionLibraryCreateDto subscriptionCreateDto = new SubscriptionLibraryCreateDto();

            subscriptionCreateDto.IdAccount = accountReadDto.IdAccount;
            subscriptionCreateDto.TypeSuscript = compNewSubscr.TypeSubscripton;
            subscriptionCreateDto.PeriodSouscrip = compNewSubscr.PeriodSouscrip;
            subscriptionCreateDto.FreeTrial = compNewSubscr.FreeTrial;


            var subscription = _mapper.Map<SubscriptionLibrary>(subscriptionCreateDto);
            _connectionLibraryBaseRepos.SubscriptionRepository.CreateSubscription(subscription);
            _beautyBaseRepo.SaveChanges();
            subscriptionReadDto = _mapper.Map<SubscriptionLibraryReadDto>(subscription);


            return CreatedAtRoute(nameof(LoadCompanyById), new { Id = companyReadDto.IdComp }, companyReadDto); // return info of the created company

        }
        */
    }
}
