using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_api.DTOs.Users
{
    public class CreateUserDto
    {
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}