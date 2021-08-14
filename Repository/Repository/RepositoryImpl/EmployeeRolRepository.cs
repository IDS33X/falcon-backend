using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryImpl;

namespace Repository.Repository.RepositoryImpl
{
    public class EmployeeRolRepository : GenericRepository<EmployeeRol>, IEmployeeRolRepository
    {
        public EmployeeRolRepository(DbContext context) : base(context)
        {
        }
    }
}
