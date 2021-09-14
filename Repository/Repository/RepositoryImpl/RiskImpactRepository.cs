using Domain.Models;
using Repository.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository.RepositoryImpl
{
    public class RiskImpactRepository : IRiskImpactRepository
    {
        private readonly FalconDBContext _context;
        public RiskImpactRepository(FalconDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RiskImpact>> GetAll()
        {
            return await _context.RiskImpact.Include(ri => ri.ImpactType).ToListAsync();
        }
    }
}
