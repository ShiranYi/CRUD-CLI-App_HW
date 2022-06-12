using CRUD_CLI_App_HW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_CLI_App_HW
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student>? Students{get; set;}
        public DbSet<Course> Courses{get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7BG5TLL;Database=SchoolDB;Trusted_Connection=True;");
        }
    }
}
