using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.Employee;
using Util.Support.Responses.Employee;

namespace Service.Service.ServiceImpl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddEmployeeResponse> Add(AddEmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request.Employee);

            employee = await _unitOfWork.Employees.Add(employee);
            await _unitOfWork.CompleteAsync();

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return new AddEmployeeResponse { Employee = employeeDto };
        }

        public async Task<EmployeesByDepartmentResponse> GetEmployeesByDepartment(EmployeesByDepartmentRequest request)
        {
            var employees = await _unitOfWork.Employees.GetEmployeesByDepartment(request.DepartmentId, request.Page, request.ItemsPerPage);

            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();

            foreach (Employee employee in employees)
            {
                var employeeDto = _mapper.Map<EmployeeDto>(employee);

                employeeDtos.Add(employeeDto);
            }

            int employeesByDepartmentCount = await _unitOfWork.Employees.GetEmployeesByDepartmentCount(request.DepartmentId);
            int pages = Convert.ToInt32(Math.Ceiling((double)employeesByDepartmentCount / request.ItemsPerPage));

            EmployeesByDepartmentResponse response = new EmployeesByDepartmentResponse
            {
                AmountOfPages = pages,
                CurrentPage = employeeDtos.Count > 0 ? request.Page : 0,
                Employees = employeeDtos
            };

            return response;
        } 
        public async Task<EmployeesByDepartmentSearchResponse> GetEmployeesByDepartmentAndSearch(EmployeesByDepartmentSearchRequest request)
        {
            var employees = await _unitOfWork.Employees.GetEmployeesByDepartmentSearch(request.DepartmentId, request.Filter, request.Page, request.ItemsPerPage);

            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();

            foreach (Employee employee in employees)
            {
                var employeeDto = _mapper.Map<EmployeeDto>(employee);

                employeeDtos.Add(employeeDto);
            }

            int employeesByDepartmentAndSearchCount = await _unitOfWork.Employees.GetEmployeesByDepartmentSearchCount(request.DepartmentId, request.Filter);
            int pages = Convert.ToInt32(Math.Ceiling((double)employeesByDepartmentAndSearchCount / request.ItemsPerPage));

            EmployeesByDepartmentSearchResponse response = new EmployeesByDepartmentSearchResponse
            {
                AmountOfPages = pages,
                CurrentPage = employeeDtos.Count > 0 ? request.Page : 0,
                Employees = employeeDtos
            };

            return response;
        }

        public async Task<EmployeeDto> GetById(int id)
        {
            var employee = await _unitOfWork.Employees.GetById(id);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public async Task<bool> Removed(int id)
        {
            var isRemoved = await _unitOfWork.Employees.Removed(id);
            await _unitOfWork.CompleteAsync();

            return isRemoved;
        }

        public async Task<EditEmployeeResponse> Update(EditEmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request.Employee);

            var employeeUpdated = await _unitOfWork.Employees.Update(employee);
            var employeeUpdatedDto = _mapper.Map<EmployeeDto>(employeeUpdated);
            await _unitOfWork.CompleteAsync();

            return new EditEmployeeResponse { Employee = employeeUpdatedDto };
        }
    }
}
