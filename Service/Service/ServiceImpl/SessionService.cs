using System;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using Service.Service;
using Util.Dtos;
using Util.Exceptions;
using Util.Support;

namespace Service.ServiceImpl
{
    public class SessionService : ISessionService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public SessionService(IUnitOfWork unitOfWork,IMapper mapper){
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<EmployeeDto> Login(LogInRequest login)
        {
            Employee employee = await unitOfWork.Employees.FindByCode(login.Code);
            
            if(!employee.Password.Equals(login.Password)){
                throw new IncorrectPasswordException("Contrasena incorrecta");
            }
            else{
                EmployeeDto dto = mapper.Map<EmployeeDto>(employee);
                return dto;
            }
        }
    }
}