using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IRiskRepository : IGenericRepository<Risk, Guid>
    {
        Task<IEnumerable<Risk>> GetRiskByCategoryAndCode(string filter, int page, int perPage, int? riskCategoryId);
        Task<int> GetRiskByCategoryAndCodeCount(string filter, int? riskCategoryId);
        Task<IEnumerable<Risk>> GetRiskByCategoryAndDescription(string filter, int page, int perPage, int? riskCategoryId);
        Task<int> GetRiskByCategoryAndDescriptionCount(string filter, int? riskCategoryId);
        Task<int> GetRiskByCategoryCount(int? riskCategoryId);
        Task<IEnumerable<Risk>> GetRisksByCategory(int page, int perPage, int? riskCategoryId);
    }
}
