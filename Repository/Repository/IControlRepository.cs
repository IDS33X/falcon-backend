using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IControlRepository : IGenericRepository<Control,Guid>
    {
        Task<Control> GetControlByCode(string code);
        Task<IEnumerable<Control>> GetControls(int page, int perPage);
        Task<int> GetControlsCount();
        Task<IEnumerable<Control>> GetControlsByRisk(Guid riskId, int page, int perPage);
        Task<int> GetControlsByRiskCount(Guid riskId);
        Task<IEnumerable<Control>> GetControlsByUser(int userId, int page, int perPage);
        Task<int> GetControlsByUserCount(int userId);
        Task<IEnumerable<Control>> GetControlsByCodeSearch(int riskCategoryId, string filter, int page, int perPage);
        Task<int> GetControlsByCodeSearchCount(int riskCategoryId,string filter);
        Task<IEnumerable<Control>> GetControlsByRiskCategory(int riskCategoryId,int page, int perPage);
        Task<int> GetControlsByRiskCategoryCount(int riskCategoryId);
    }
}
