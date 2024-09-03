using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_api.Models;

namespace todo_api.Helpers
{
    public class QueryObject
    {
        public TodoStatus? Status { get; set; } = null;
        public string? Search { get; set; } = null;
    }
}