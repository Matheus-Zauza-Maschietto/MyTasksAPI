using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyTasksAPI.Dto.UserDto
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public RegisterDto(IdentityUser user)
        {
            Email = user.UserName;
            Password = user.PasswordHash;
        }
        public RegisterDto()
        {
            
        }
    }
}