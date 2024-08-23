using Application.DTOs.Employee;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankPortal.API.Controllers
{
    [Authorize] // Authorize the entire controller or individual actions
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [Authorize(Roles = "Admin, HRAdmin")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto employee)
        {
            // Call the application service to create an employee
            var result = await _employeeService.AddEmployeeAsync(employee);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto employee)
        {
            var result = await _employeeService.UpdateEmployeeAsync(id, employee);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [Authorize(Roles = "Admin, HRAdmin, Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [Authorize(Roles = "Admin, HRAdmin, Manager, Employee")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee != null)
            {
                return Ok(employee);
            }

            return NotFound();
        }

        // Other controller actions

    }
}
