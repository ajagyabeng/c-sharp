using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace todo_api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TodoStatus {
        Upcoming,
        Completed,
        Deleted
    }
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
        public TodoStatus Status { get; set; } = TodoStatus.Upcoming;

        [Required]
        public DateOnly Date { get; set; }
        
        [Required]
        public TimeOnly StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }

        // Foreign Key to User
        public int UserId { get; set; }

        // Navigation property to User
        [Required]
        public required User User { get; set; }
    }
}