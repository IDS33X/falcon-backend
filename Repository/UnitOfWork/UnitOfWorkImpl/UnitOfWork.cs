using System;
using System.Threading.Tasks;
using Repository.Context;
using Repository.Repository;
using Repository.RepositoryImpl;
using Repository.UnitOfWork;

namespace Repository.UnitOfWorkImpl
{
    public class UnitOfWork : IUnitOfWork
    {
        private FalconDBContext context;
 
        public IEmployeeRepository Employees {get;}

        public UnitOfWork(FalconDBContext context){
            this.context = context;
            
            Employees = new EmployeeRepository(context);
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}