using EmployeeAPI.Data.Models;
using EmployeeAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employee;

        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {

            return Ok(await _employee.GetAllEmployeesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {

            return Ok(await _employee.CreateEmployeesAsync(employee));

        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _employee.GetEmployeesByIdAsync(id);
                if (employee == null)
                    return NotFound();
                return Ok(employee);
            }
            catch (Exception)
            {
                return NotFound();
            }


        }

        [HttpPut]
        public async Task<IActionResult> Put(Employee updatedEmployee)
        {

            var employee = await _employee.GetAllEmployeesAsync();
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(await _employee.UpdateEmployeeAsync(updatedEmployee));


        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            try
            {
                var employee = await _employee.GetEmployeesByIdAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }


                return await _employee.DeleteEmployeeIdAsync(id);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

    }
}
