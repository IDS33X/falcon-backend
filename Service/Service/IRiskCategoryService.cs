using System.Threading.Tasks;
using Util.Support.Requests.RiskCategory;
using Util.Support.Responses.RiskCategory;

namespace Service.Service
{
    public interface IRiskCategoryService
    {
        Task<AddRiskCategoryResponse> Add(AddRiskCategoryRequest request);
        Task<GetRiskCategoriesByDepartmentSearchResponse> GetDepartmentsByDivisionAndSearch(GetRiskCategoriesByDepartmentSearchRequest request);
        Task<GetRiskCategoriesByDepartmentResponse> GetRiskCategoriesByDepartment(GetRiskCategoriesByDepartmentRequest request);
        Task<EditRiskCategoryResponse> Update(EditRiskCategoryRequest request);
    }
}
