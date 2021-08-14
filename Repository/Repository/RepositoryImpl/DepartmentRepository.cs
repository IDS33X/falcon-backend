using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.RepositoryImpl
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context) : base(context)
        {
        }

        public async Task<int> GetAnalystCount(int departmentId)
        {
            int count = await context.Set<Employee>().CountAsync(d => d.DepartmentId == departmentId);
            return count;
        }
    }
}
