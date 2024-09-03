using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_api.DTOs.Todos;
using todo_api.Helpers;
using todo_api.Models;

namespace todo_api.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync(QueryObject query);
        Task<Todo> CreateAsync(Todo todoItem);
        Task<Todo?> GetByIdAsync(int id);
        Task<Todo?> UpdateAsync(int id, UpdateTodoDto todoDto);
        Task<Todo?> DeleteAsync(int id);

    }
}