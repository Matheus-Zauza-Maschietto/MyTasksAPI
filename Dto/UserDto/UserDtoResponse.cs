using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MyTasksAPI.Dto.UserDto
{
    public class UserDtoResponse
    {
        public string Email { get; set; }
        public string Nome { get; set; }

        public UserDtoResponse(IdentityUser user)
        {
            Email = user.Email;
            Nome = user.UserName;
        }
    }
}