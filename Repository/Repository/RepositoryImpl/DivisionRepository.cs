using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.RepositoryImpl;
using System.Threading.Tasks;
using Util.Exceptions;

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

        public new async Task<Division> GetById(int id)
        {
            Division division = await context.Set<Division>().Include(d => d.Employee).SingleOrDefaultAsync(e => e.DivisionId == id);

            if (division == null)
            {
                throw new DoesNotExistException("Not exist");
            }
            else
            {
                return division;
            }
        }
    }
}
