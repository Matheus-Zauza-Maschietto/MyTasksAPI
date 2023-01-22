using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTasksAPI.Dto.UserDto
{
    public class UserPasswordUpdateDto
    {
        public string email { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}