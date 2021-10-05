using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IRiskControlRepository : IGenericRepository<RiskControl,int>
    {

        Task<IEnumerable<RiskControl>> AddRange(IEnumerable<RiskControl> risksControls);

        Task<IEnumerable<RiskControl>> UpdateRange(IEnumerable<RiskControl> risksControls);

    }
}
