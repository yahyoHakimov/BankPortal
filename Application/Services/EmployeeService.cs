using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id) => await _employeeRepository.GetByIdAsync(id);

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() => await _employeeRepository.GetAllAsync();

        public async Task CreateEmployeeAsync(Employee employee) => await _employeeRepository.AddAsync(employee);

        public async Task UpdateEmployeeAsync(Employee employee) => _employeeRepository.Update(employee);

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee != null)
            {
                _employeeRepository.Delete(employee);
            }
        }
    }

}
