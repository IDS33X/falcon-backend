using System;
using System.Threading.Tasks;
using Domain.Models;
using Util.Dtos;
using Util.Support;

namespace Service.Service
{
    public interface ILogIn
    {
        Task<EmployeeDto> Login(LogInRequest login);
    }
}