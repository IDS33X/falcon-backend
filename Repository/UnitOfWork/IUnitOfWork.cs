using System;
using System.Threading.Tasks;
using Repository.Repository;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
         IEmployeeRepository Employees {get;}
        IAreaRepository Areas { get; }
        IDivisionRepository Divisions { get; }
        IDepartmentRepository Departments { get; }
        IEmployeeRolRepository EmployeeRols { get; }

        Task CompleteAsync();
    }
}