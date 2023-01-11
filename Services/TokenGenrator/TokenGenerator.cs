using BeautyWebAPI.Models;
using ConnectivityLibrary.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BeautyWebAPI.Services.TokenGenrator
{
    public class TokenGenerator
    {
       private readonly IConfiguration _configuration;
        public TokenGenerator(IConfiguration configuration)
        { 
            _configuration = configuration;
        }
        

        public string GenerateToken(string secreteKey, string theIssuer, string theAudience, UserLibraryReadDto user)
        {
            /*
            string secreteKey = _configuration["JWT:Secret"];
            string theIssuer = _configuration["JWT:ValidIssuer"];
            string theAudience = _configuration["JWT:ValidAudience"];
            */

            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteKey));
            SigningCredentials credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> theClaims = new List<Claim>()
            {

                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer:     theIssuer,
                audience:   theAudience,
                claims:     theClaims,
                notBefore:  DateTime.UtcNow,
                expires:    DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool IsTokenValid(string secreteKey, string theIssuer, string theAudience, string token)
        {

            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteKey));

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = theAudience,
                    ValidIssuer = theIssuer,
                    IssuerSigningKey = key
                }, out SecurityToken validatedToken);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
