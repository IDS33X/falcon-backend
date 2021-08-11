using System;
using System.Threading.Tasks;
using Repository.Repository;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
         IEmployeeRepository Employees {get;}

         Task CompleteAsync();
    }
}