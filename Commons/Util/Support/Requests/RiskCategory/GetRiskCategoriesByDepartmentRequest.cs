namespace Util.Support.Requests.RiskCategory
{
    public class GetRiskCategoriesByDepartmentRequest : PaginationRequest
    {
        public int DepartmentId { get; set; }
    }
}
