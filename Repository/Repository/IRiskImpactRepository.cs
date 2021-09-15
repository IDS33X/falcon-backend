using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IRiskImpactRepository
    {
        Task<IEnumerable<RiskImpact>> GetAll();
    }
}
