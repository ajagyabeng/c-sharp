using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_api.Models;

namespace todo_api.DTOs.Todos
{
    public class UpdateTodoDto
    {
        public string Name { get; set; } = string.Empty;
        public TodoStatus Status { get; set; } = TodoStatus.Upcoming;
        public string Date { get; set; } = string.Empty;
        public string StartTime { get; set; } = string.Empty;
        public string? EndTime { get; set; } = string.Empty;
        public int UserId { get; set; }
        public required User User { get; set; }


    }
}