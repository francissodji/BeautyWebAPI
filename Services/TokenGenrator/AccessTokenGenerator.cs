using BeautyWebAPI.Models;
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
    public class AccessTokenGenerator
    {

        public string GenerateToken(User user)
        {
            string secreteKey = "1qFXYlTI9SqTuT0m_PnvQmOxyUgsKM3D_2E4_uBSj_QpxQ2D3itJdeIlnArie6AtziFC_k2qmPEK6IaUr6tcbBgrWwc_-oWvfmHBTTcZgSsoKN3NT9I26E6Hf9MPlweWLvEpnIilAwEVbLB254lxsyRy-zexGdQFtmJ-C3xeD5s";
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteKey));
            SigningCredentials credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>()
            {
                new Claim("id", user.IDUser.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                "https://localhost:5001",
                "http://localhost:5001",
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(30),
                credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
