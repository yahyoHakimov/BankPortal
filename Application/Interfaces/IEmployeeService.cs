using Application.DTOs.Employee;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<(bool Success, string Message)> AddEmployeeAsync(CreateEmployeeDto employeeDto);
        Task<(bool Success, string Message)> UpdateEmployeeAsync(int id, UpdateEmployeeDto employeeDto);
        Task<(bool Success, string Message)> DeleteEmployeeAsync(int id);
    }

}
