using System;
using System.Threading.Tasks;
using Domain.Models;
using Util.Dtos;

namespace Service.Service
{
    public interface ILogIn
    {
        Task<EmployeeDto> Login(string code, string password);
    }
}