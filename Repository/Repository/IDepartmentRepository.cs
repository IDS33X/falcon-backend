using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IDepartmentRepository : IGenericRepository<Department, int>
    {
        Task<int> GetAnalystCount(int departmentId);
    }
}
