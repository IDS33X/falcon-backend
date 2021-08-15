using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Service.Service
{
    public interface IDepartmentService
    {
        Task<DepartmentDto> Add(DepartmentDto departmentDto);
        Task<bool> Removed(int id);
        Task<DepartmentDto> GetById(int id);
        Task<IEnumerable<DepartmentDto>> GetAll();
        Task<bool> Update(DepartmentDto departmentDto);
    }
}
