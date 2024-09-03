using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_api.DTOs.Users;
using todo_api.Models;

namespace todo_api.DTOs.Todos
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string? EndTime { get; set; }
        public int UserId { get; set; }

        public UserDto User { get; set; } = new UserDto();
    }
}