using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using BeautyWebAPI.Models;
using System.Text;

using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;



namespace BeautyWebAPI.Services.TokenGenrator
{
    public class TokenGenerator
    {
        private string CreateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var Secret = "1qFXYlTI9SqTuT0m_PnvQmOxyUgsKM3D_2E4_uBSj_QpxQ2D3itJdeIlnArie6AtziFC_k2qmPEK6IaUr6tcbBgrWwc_-oWvfmHBTTcZgSsoKN3NT9I26E6Hf9MPlweWLvEpnIilAwEVbLB254lxsyRy-zexGdQFtmJ-C3xeD5s";
            var key = Encoding.ASCII.GetBytes(Secret);
            var identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.IDUser.ToString())
                });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddMinutes(120),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
