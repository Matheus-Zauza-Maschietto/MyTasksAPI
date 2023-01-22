using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksAPI.Dto.UserDto
{
    public class ResponseUserDto
    {
        public string email { get; set; }
        public string jwtToken { get; set; }
        public string[] erros { get; set; }
    }
}