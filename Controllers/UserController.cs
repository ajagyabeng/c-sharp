using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_api.Data;
using todo_api.DTOs.Users;
using todo_api.Interfaces;
using todo_api.Mappers;

namespace todo_api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController(ApplicationDbContext context, IUserRepository userRepository) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IUserRepository _userRepository = userRepository;

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBYId([FromRoute] int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto userDto)
        {
            var user = userDto.ToUserFromCreateDto();

            await _userRepository.CreateAsync(user);

            return CreatedAtAction(
                nameof(GetBYId),
                new { id = user.Id },
                user.ToUserDto()
            );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.UpdateAsync(id, updateUserDto);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await _userRepository.DeleteAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}