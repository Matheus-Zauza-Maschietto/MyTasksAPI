using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyTasksAPI.Services
{
    public class JwtCodeGenerator
    {
        public static string GenerateToken(ClaimsIdentity subject)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["JwtBearerTokenSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["JwtBearerTokenSettings:Audience"],
                Issuer = _configuration["JwtBearerTokenSettings:Issuer"],
                Expires = DateTime.UtcNow.AddMinutes(6)
            };
            
            var TokenHandler = new JwtSecurityTokenHandler();

            var pretoken = TokenHandler.CreateToken(tokenDescriptor);
            token = TokenHandler.WriteToken(pretoken);
            return token;
        }
    }
}