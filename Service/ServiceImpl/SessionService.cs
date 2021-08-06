using System;
using System.Threading.Tasks;
using Domain.Models;
using Repository.UnitOfWork;
using Service.Service;
using Util.dto;
using Util.exceptions;

namespace Service.ServiceImpl
{
    public class SessionService : ISessionService
    {

        private IUnitOfWork unitOfWork;

        public SessionService(IUnitOfWork unitOfWork){
            this.unitOfWork = unitOfWork;
        }

        public async Task<Employee> LogIn(DtoLogin dto)
        {
            var employee = await unitOfWork.Employees.GetByCode(dto.Code);

            if(!employee.Equals(dto.Password)){
                throw new IncorrectPasswordException("Incorrect Password");
            }
            else{
                await unitOfWork.CompleteAsync();
                return employee;
            }  
        }
    }
}