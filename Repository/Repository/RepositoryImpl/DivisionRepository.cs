using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.RepositoryImpl;
using System.Threading.Tasks;

namespace Repository.Repository.RepositoryImpl
{
    public class DivisionRepository : GenericRepository<Division>,IDivisionRepository
    {
        public DivisionRepository(FalconDBContext context) : base(context)
        {

        }

        public async Task<int> GetDepartmentCount(int divisionId)
        {
            int count = await context.Set<Department>().CountAsync(d => d.DivisionId == divisionId);
            return count;
        }
    }
}
