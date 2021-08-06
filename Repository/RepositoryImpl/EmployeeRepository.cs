using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Context;
using Repository.Repository;
using System;
using Microsoft.EntityFrameworkCore; //The EF Core async extension methods are defined in the Microsoft.EntityFrameworkCore
using Util.exceptions;

namespace Repository.RepositoryImpl
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(FalconDbContext context): base(context){
        }

        //casting the inherit context as FalconDbContext
        public FalconDbContext FalconContext{
            get{return context as FalconDbContext;}
        }

        public async Task<Employee> GetByCode(string code)
        {
            var employee = await FalconContext.Employees.Where(e => e.Code.Equals(code)).SingleAsync();

            if(employee == null){
                throw new DoesNotExistException("the user is not registered in the system");
            }else{
                return employee;
            }
        }

        
    }
}