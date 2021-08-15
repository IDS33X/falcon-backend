using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos;

namespace Service.Service
{
    public interface IEmployeeRolService
    {
        Task<IEnumerable<EmployeeRolDto>> GetAll();
    }
}
