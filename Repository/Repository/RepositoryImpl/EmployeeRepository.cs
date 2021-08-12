using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
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
            Employee employee = await Task.Run(() => context.Set<Employee>()
                                            .Where(e => e.Code == code)
                                            .FirstOrDefault());

            if(employee == null){
                throw new DoesNotExistException("El usuario no existe");
            }
            else{
                return employee;
            }                              
        }
    }
}