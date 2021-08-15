using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Repository;
using Util.Exceptions;

namespace Repository.RepositoryImpl
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        public EmployeeRepository(FalconDBContext context): base(context){

        }

        public async Task<Employee> FindByCode(string code)
        {
            
            Employee employee = await Task.Run(() => context.Set<Employee>().Include(e => e.EmployeeRol)
                                            .Where(e => e.Code == code)
                                            .FirstOrDefault());

            if(employee == null){
                throw new DoesNotExistException("El usuario no existe");
            }
            else{
                return employee;
            }                              
        }

        public new async Task<Employee> GetById(int id)
        {
            Employee entity = await context.Set<Employee>().Include(e => e.EmployeeRol).SingleOrDefaultAsync(e => e.EmployeeId == id);

            if (entity == null)
            {
                throw new DoesNotExistException("Not exist");
            }
            else
            {
                return entity;
            }
        }
    }
}