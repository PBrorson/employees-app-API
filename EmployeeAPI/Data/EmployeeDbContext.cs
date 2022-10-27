using EmployeeAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeAPI.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
