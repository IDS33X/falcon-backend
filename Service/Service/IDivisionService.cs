using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Service.Service
{
    public interface IDivisionService
    {
        Task<DivisionDto> Add(DivisionDto divisionDto);
        Task<bool> Removed(int id);
        Task<DivisionDto> GetById(int id);
        Task<IEnumerable<DivisionDto>> GetAll();
        Task<bool> Update(DivisionDto divisionDto);
    }
}
