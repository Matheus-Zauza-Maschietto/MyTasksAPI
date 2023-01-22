using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;

namespace MyTasksAPI.Services
{
    public class JwtCodeGenerator
    {
        public static string GenerateToken(ClaimsIdentity ClaimsToToken)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["JwtBearerTokenSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = ClaimsToToken,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["JwtBearerTokenSettings:Audience"],
                Issuer = _configuration["JwtBearerTokenSettings:Issuer"],
                Expires = DateTime.UtcNow.AddHours(1.5)
            };
            
            var TokenHandler = new JwtSecurityTokenHandler();

            var pretoken = TokenHandler.CreateToken(tokenDescriptor);
            token = TokenHandler.WriteToken(pretoken);
            return token;
        }
    }
}