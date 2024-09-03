using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_api.Data;
using todo_api.DTOs.Users;
using todo_api.Interfaces;
using todo_api.Models;

namespace todo_api.Repository
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<User> CreateAsync(User userItem)
        {
            await _context.User.AddAsync(userItem);
            await _context.SaveChangesAsync();

            return userItem;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<User?> UpdateAsync(int id, UpdateUserDto userDto)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            user.FullName = userDto.FullName;
            user.Email = userDto.Email;

            await _context.SaveChangesAsync();

            return user;
        }
    }
}