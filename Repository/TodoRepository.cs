using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_api.Data;
using todo_api.DTOs.Todos;
using todo_api.Helpers;
using todo_api.Interfaces;
using todo_api.Models;

namespace todo_api.Repository
{
    public class TodoRepository(ApplicationDbContext context) : ITodoRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<Todo> CreateAsync(Todo todoItem)
        {
            await _context.Todos.AddAsync(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }

        public async Task<Todo?> DeleteAsync(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(stock => stock.Id == id);

            if (todo == null)
            {
                return null;
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        public async Task<List<Todo>> GetAllAsync(QueryObject query)
        {
            var todos = _context.Todos.AsQueryable();

            if (query.Status.HasValue)
            {
                todos = todos.Where(
                    todo => todo.Status.Equals(query.Status.Value)
                );
            }

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                todos = todos.Where(
                    todo => todo.Name.Contains(query.Search)
                );
            }

            return await todos.ToListAsync();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<Todo?> UpdateAsync(int id, UpdateTodoDto todoDto)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == id);

            if (todo == null)
            {
                return null;
            }

            // Find a better way to do a partial update
            todo.Name = todoDto.Name;
            todo.Status = todoDto.Status;
            todo.Date = DateOnly.Parse(todoDto.Date);
            todo.StartTime = TimeOnly.Parse(todoDto.StartTime);
            todo.EndTime = todoDto.EndTime != null ? TimeOnly.Parse(todoDto.EndTime) : null;

            await _context.SaveChangesAsync();

            return todo;
        }
    }
}