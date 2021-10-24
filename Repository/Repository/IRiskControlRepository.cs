using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IRiskControlRepository : IGenericRepository<RiskControl,int>
    {
        Task<(IEnumerable<RiskControl> riskControlsAdded, IEnumerable<(RiskControl riskControl, string errorMessage)> riskControlsNotAdded)> AddRange(IEnumerable<RiskControl> risksControls);
        Task<(IEnumerable<RiskControl> riskControlsRemoved, IEnumerable<(RiskControl riskControl, string errorMessage)> riskControlsNotRemoved)> UpdateRange(IEnumerable<RiskControl> risksControls);
    }
}
