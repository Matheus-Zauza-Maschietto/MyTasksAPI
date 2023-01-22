using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksAPI.Dto.UserDto
{
    public class ResponseUserDto
    {
        public string Email { get; set; }
        public string JwtToken { get; set; }
        public List<string> Erros { get; set; }

        public ResponseUserDto(List<string> erros)
        {
            Email = null;
            JwtToken = "";
            Erros = erros;
        }

        public ResponseUserDto(string email, string jwtToken, List<string> erros)
        {
            Email = email;
            JwtToken = jwtToken;
            Erros = erros;
        }
    }
}