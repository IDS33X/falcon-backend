using System;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using Service.Service;
using Util.Dtos;
using Util.Exceptions;
using Util.Support;
using Util.Support.Requests;

namespace Service.ServiceImpl
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SessionService(IUnitOfWork unitOfWork,IMapper mapper){
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Login(LogInRequest login)
        {
            Employee employee = await _unitOfWork.Employees.FindByCode(login.Code);
            
            if(!employee.Password.Equals(login.Password)){
                throw new IncorrectPasswordException("Contrasena incorrecta");
            }
            else{
                EmployeeDto dto = _mapper.Map<EmployeeDto>(employee);
                return dto;
            }
        }
    }
}