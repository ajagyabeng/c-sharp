using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_api.DTOs.Users;
using todo_api.Models;

namespace todo_api.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User userItem);
        Task<User?> UpdateAsync(int id, UpdateUserDto userDto);
        Task<User?> GetByIdAsync(int id);
        Task<User?> DeleteAsync(int id);
    }
}