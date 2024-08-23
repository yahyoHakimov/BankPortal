using Application.DTOs.Employee;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<(bool Success, string Message)> AddEmployeeAsync(CreateEmployeeDto employeeDto)
        {
            // Validate the employee data
            if (employeeDto == null)
            {
                return (false, "Invalid employee data provided.");
            }

            try
            {
                // Map the DTO to the Employee entity
                var employee = _mapper.Map<Employee>(employeeDto);

                // Check for duplicate email (assuming unique email is a requirement)
                var existingEmployee = await _employeeRepository.GetByEmailAsync(employeeDto.Email);
                if (existingEmployee != null)
                {
                    return (false, "An employee with this email already exists.");
                }

                // Add the new employee to the repository
                await _employeeRepository.AddAsync(employee);

                // Save changes to the database (assuming you are using Unit of Work or similar pattern)
                await _employeeRepository.SaveChangesAsync();

                return (true, "Employee added successfully.");
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an error message
                // Log the exception if needed
                return (false, $"An error occurred while adding the employee: {ex.Message}");
            }
        }


        public async Task<(bool Success, string Message)> UpdateEmployeeAsync(int id, UpdateEmployeeDto employeeDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                return (false, "Employee not found");
            }

            // Update the employee
            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.JobTitle = employeeDto.JobTitle;

            _employeeRepository.Update(employee);

            return (true, "Employee updated successfully");
        }



        public async Task<(bool Success, string Message)> DeleteEmployeeAsync(int id)
        {
            // Retrieve the employee from the repository
            var employee = await _employeeRepository.GetByIdAsync(id);

            // Check if the employee exists
            if (employee == null)
            {
                return (false, "Employee not found");
            }

            // Delete the employee
            _employeeRepository.Delete(employee);

            // Save changes (assuming you have a SaveChangesAsync method)
            await _employeeRepository.SaveChangesAsync();

            return (true, "Employee deleted successfully");
        }

    }
}
