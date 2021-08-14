using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Repository.Repository
{
    public interface IAreaRepository : IGenericRepository<Area, int>
    {
        Task<int> GetDivisionsCount(int areaId);
    }
}
