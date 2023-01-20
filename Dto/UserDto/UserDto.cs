using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyTasksAPI.Dto.UserDto
{
    public class UserDto
    {
        public string email { get; set; }
        public string password { get; set; }
        public UserDto(IdentityUser user)
        {
            email = user.UserName;
            password = user.PasswordHash;
        }

        public UserDto()
        {
            
        }
    }   

    
}