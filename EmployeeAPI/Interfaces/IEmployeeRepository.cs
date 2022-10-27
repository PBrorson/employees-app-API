using EmployeeAPI.Data.Models;

namespace EmployeeAPI.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeesByIdAsync(int id);
        Task<Employee> CreateEmployeesAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<Employee> DeleteEmployeeIdAsync(int id);
    }
}
