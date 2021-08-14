using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

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
        public async Task<EmployeeDto> Add(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);

            employee = await _unitOfWork.Employees.Add(employee);
            await _unitOfWork.CompleteAsync();

            employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var employees = await _unitOfWork.Employees.GetAll();

            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();

            foreach (Employee employee in employees)
            {
                var employeeDto = _mapper.Map<EmployeeDto>(employee);

                employeeDtos.Add(employeeDto);
            }

            return employeeDtos;
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

        public async Task<bool> Update(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);

            var isUpdated = await _unitOfWork.Employees.Update(employee);
            await _unitOfWork.CompleteAsync();

            return isUpdated;
        }
    }
}
