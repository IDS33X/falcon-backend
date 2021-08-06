using System.Threading.Tasks;
using Domain.Models;

namespace Repository.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee,int>
    {
         Task<Employee> GetByCode(string code);
    }
}