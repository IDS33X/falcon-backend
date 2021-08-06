using System.Threading.Tasks;
using Domain.Models;
using Util.dto;
using System;

namespace Service.Service
{
    public interface ILogIn
    {
         Task<Employee> LogIn(DtoLogin dto);
    }
}