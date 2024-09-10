using Microsoft.EntityFrameworkCore;
using WebToDoList.Models;
using System.Collections.Generic;

namespace WebToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoList> toDoLists { get; set; }
    }
}