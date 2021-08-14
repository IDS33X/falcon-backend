using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Service.Service
{
    public interface IAreaService
    {
        Task<AreaDto> Add(AreaDto areaDto);
        Task<bool> Removed(int id);
        Task<AreaDto> GetById(int id);
        Task<IEnumerable<AreaDto>> GetAll();
        Task<bool> Update(AreaDto areaDto);
    }
}
