using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todo_api.Models;

namespace todo_api.Data
{
    public class ApplicationDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> User { get; set; }
    }
}