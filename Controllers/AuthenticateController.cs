using BeautyWebAPI.Authentication;
using BeautyWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
 
namespace BeautyWebAPI.Controllers
{
    public class AuthenticateController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;


        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        //User Registration
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var userExist = await _userManager.FindByIdAsync(register.UserName);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exist." });
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.UserName
            };

            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed." });
            }

           

            return Ok(new Response { Status = "Success", Message = "User created successfully." });

            
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var userExist = await _userManager.FindByNameAsync(login.Username);


            if (userExist != null && await _userManager.CheckPasswordAsync(userExist, login.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(userExist);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userExist.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userrole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userrole));
                }

                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),// expiring time
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                        );

                //******************1/16/2021 - Can be delete anytime - Just trying to retreive the user information
                //**************** For this I will use model 'User'
                //
                //User theConnectedUser = new User();


                //theConnectedUser.

                return Ok(new
                {

                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    username = userExist.UserName
                    //can put token expiration here
                });
            }
            //else
            return Unauthorized();

        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Register registerAdmin)
        {
            var userExist = await _userManager.FindByIdAsync(registerAdmin.UserName);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exist." });
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = registerAdmin.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerAdmin.UserName
            };

            var result = await _userManager.CreateAsync(user, registerAdmin.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed." });
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin)) // If the 'Admin' role does not exist in the roles table
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin)); // then create the role 'Admin'

            if (!await _roleManager.RoleExistsAsync(UserRoles.User)) // If the 'User' role does not exist in the roles table
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User)); // then create the role 'User'

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin)) // If the role 'Admin' exist
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin); // then assign the admin role to the user
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully." });
        }
    }
}
