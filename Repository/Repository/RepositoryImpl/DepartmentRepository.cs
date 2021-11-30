using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryImpl;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Exceptions;

namespace Repository.Repository.RepositoryImpl
{
    public class DepartmentRepository : GenericRepository<Department, int>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context) : base(context)
        {
        }
        public async Task<int> GetDepartmentsByDivisionCount(int? divisionId)
        {
            int count = await context.Set<Department>().CountAsync(d => d.DivisionId == divisionId);
            return count;
        }
        public async Task<int> GetDepartmentsByDivisionSearchCount(int? divisionId, string filter)
        {
            int count = await context.Set<Department>().CountAsync(d => d.DivisionId == divisionId && d.Title.Contains(filter));
            return count;
        }
        public async Task<IEnumerable<Department>> GetDepartmentsByDivision(int? divisionId, int page, int perPage)
        {
            return await context.Set<Department>()
                                 .Where(d => d.DivisionId == divisionId)
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();
        }
        public async Task<IEnumerable<Department>> GetDepartmentsByDivisionSearch(int? divisionId, string filter, int page, int perPage)
        {
            return await context.Set<Department>()
                                .Where(d => d.DivisionId == divisionId && d.Title.Contains(filter))
                                .Skip((page - 1) * perPage)
                                .Take(perPage)
                                .ToListAsync();
        }

        public new async Task<Department> Update(Department department)
        {
            var previousDepartment = await context.Set<Department>().FirstOrDefaultAsync(d => d.Id == department.Id);

            if(previousDepartment == null)
            {
                throw new DoesNotExistException("Not Exist");
            }

            if (department.Title != null)
            {
                var sameTitle = await context.Set<Department>().Where(d => d.Title == department.Title).FirstOrDefaultAsync();

                if (sameTitle != null && department.Id != sameTitle.Id)
                {
                    throw new AlreadyExistException($"A department with that title already exists, change the TITLE:({sameTitle.Title}) to another one.");
                }
            }

            previousDepartment.Title = department.Title ?? previousDepartment.Title;
            previousDepartment.Description = department.Description ?? previousDepartment.Description;

            await Task.Run(() => context.Set<Department>().Update(previousDepartment));

            return previousDepartment;
        }

        public async new Task<Department> Add(Department department)
        {
            var sameTitle = await context.Set<Department>().FirstOrDefaultAsync(d => d.Title == department.Title);

            if (sameTitle != null)
            {
                throw new AlreadyExistException($"A department with that title already exists, change the TITLE:({sameTitle.Title}) to another one.");
            }

            var division = await context.Set<Division>().FirstOrDefaultAsync(di => di.Id == department.DivisionId);

            if (division == null)
            {
                throw new DoesNotExistException("You are trying to add a department in a non existing division");
            }

            await context.Set<Department>().AddAsync(department);

            return department;
        }
    }
}
