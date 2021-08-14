using System;
using System.Threading.Tasks;
using Repository.Context;
using Repository.Repository;
using Repository.Repository.RepositoryImpl;
using Repository.RepositoryImpl;
using Repository.UnitOfWork;

namespace Repository.UnitOfWorkImpl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FalconDBContext context;
 
        public IEmployeeRepository Employees {get;}

        public IAreaRepository Areas { get; }
        public IDivisionRepository Divisions { get; }
        public IDepartmentRepository Departments { get; }
        public IEmployeeRolRepository EmployeeRols { get; }

        public UnitOfWork(FalconDBContext context){
            this.context = context;
            
            Employees = new EmployeeRepository(context);
            Areas = new AreaRepository(context);
            Divisions = new DivisionRepository(context);
            Departments = new DepartmentRepository(context);
            EmployeeRols = new EmployeeRolRepository(context);
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}