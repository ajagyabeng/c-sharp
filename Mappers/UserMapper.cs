using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_api.DTOs.Users;
using todo_api.Models;

namespace todo_api.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userItem)
        {
            return new UserDto
            {
                Id = userItem.Id,
                FullName = userItem.FullName,
                Email = userItem.Email
            };
        }

        public static User ToUserFromCreateDto(this CreateUserDto userDto)
        {
            return new User
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
            };
        }
    }

}