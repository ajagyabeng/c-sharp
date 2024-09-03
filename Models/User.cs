using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty; // set to empty to prevent null value
        public string FullName { get; set; } = string.Empty;
    }
}