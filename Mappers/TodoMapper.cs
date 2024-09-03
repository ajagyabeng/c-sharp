using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_api.DTOs.Todos;
using todo_api.DTOs.Users;
using todo_api.Models;

namespace todo_api.Mappers
{
    public static class TodoMapper
    {
        public static TodoDto ToTodoDto(this Todo todoItem)
        {
            return new TodoDto
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                Status = todoItem.Status.ToString(),
                Date = todoItem.Date.ToString("yyyy-MM-dd"),
                StartTime = todoItem.StartTime.ToString("HH:mm:ss"),
                EndTime = todoItem.EndTime?.ToString("HH:mm:ss"),
                UserId = todoItem.UserId,

                User = todoItem.User != null ? new UserDto
                {
                    Id = todoItem.User.Id,
                    Email = todoItem.User.Email,
                    FullName = todoItem.User.FullName
                } : null
            };
        }

        public static Todo ToTodoFromCreateDto(this CreateTodoDto todoDto)
        {
            return new Todo
            {
                Name = todoDto.Name,
                Status = todoDto.Status,
                Date = DateOnly.Parse(todoDto.Date),
                StartTime = TimeOnly.Parse(todoDto.StartTime),
                EndTime = todoDto.EndTime != null ? TimeOnly.Parse(todoDto.EndTime) : null,
                UserId = todoDto.UserId,
                User = todoDto.User
            };
        }

        public static Todo ToTodoFromUpdate(this UpdateTodoDto todoDto)
        {
            return new Todo
            {
                Name = todoDto.Name,
                Status = todoDto.Status,
                Date = DateOnly.Parse(todoDto.Date),
                StartTime = TimeOnly.Parse(todoDto.StartTime),
                EndTime = todoDto.EndTime !=null ? TimeOnly.Parse(todoDto.EndTime) : null,
                UserId = todoDto.UserId,
                User = todoDto.User

            };
        }
    }
}