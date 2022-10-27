using EmployeeAPI.Data;
using EmployeeAPI.Data.Models;
using EmployeeAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        public async Task<Employee> CreateEmployeesAsync(Employee employee)
        {
            _employeeDbContext.Employees.Add(employee);
            await _employeeDbContext.SaveChangesAsync();
            return employee;
        }

      

        public async Task<Employee> DeleteEmployeeIdAsync(int id)
        {
            var employee = await _employeeDbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                _employeeDbContext.Employees.Remove(employee);
                await _employeeDbContext.SaveChangesAsync();
            }

            return employee;
        }

     

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeesByIdAsync(int id)
        {
            var hero = await _employeeDbContext.Employees.FindAsync(id);

            return await _employeeDbContext.Employees.FirstOrDefaultAsync(em => em.Id == id);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var Dbemployee = await _employeeDbContext.Employees.FindAsync(employee.Id);

            Dbemployee.Name = employee.Name;
            Dbemployee.Age = employee.Age;
            Dbemployee.Role = employee.Role;
            Dbemployee.Image = employee.Image;
            await _employeeDbContext.SaveChangesAsync();
            return Dbemployee;



}

      
    }
}

