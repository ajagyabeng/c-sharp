using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_api.Data;
using todo_api.DTOs.Todos;
using todo_api.Helpers;
using todo_api.Interfaces;
using todo_api.Mappers;
using todo_api.Models;

namespace todo_api.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController(ApplicationDbContext context, ITodoRepository todoRepository) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ITodoRepository _todoRepository = todoRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? status, [FromQuery] string? search)
        {
            // Instantiate a new query object with search
            var query = new QueryObject {Search = search};

            if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<TodoStatus>(status, true, out var parsedStatus))
            {
                // add status to query object
                query.Status = parsedStatus;
            }

            var todos = await _todoRepository.GetAllAsync(query);
            var todoDto = todos.Select(todo => todo.ToTodoDto());

            return Ok(todoDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);

            if (todo == null)
            {
                return NotFound("Todo not found");
            }

            return Ok(todo.ToTodoDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var todo = await _todoRepository.DeleteAsync(id);
            
            if (todo == null) 
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTodoDto updateTodoDto)
        {
            var todo = await _todoRepository.UpdateAsync(id, updateTodoDto);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo.ToTodoDto());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoDto todoDto)
        {
            var todoItem = todoDto.ToTodoFromCreateDto();
            await _todoRepository.CreateAsync(todoItem);

            return CreatedAtAction(
                nameof(GetById),
                new { id = todoItem.Id },
                todoItem.ToTodoDto()
            );
        }


        [HttpGet("status-options")]
        public IActionResult GetStatusOptions()
        {
            var statusOptions = Enum.GetValues(typeof(TodoStatus)).Cast<TodoStatus>().Select(status => new
            {
                Name = status.ToString()
            });

            return Ok(statusOptions);
        }
    }
}