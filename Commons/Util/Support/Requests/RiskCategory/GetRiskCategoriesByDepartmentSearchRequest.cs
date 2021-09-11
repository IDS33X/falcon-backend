namespace Util.Support.Requests.RiskCategory
{
    public class GetRiskCategoriesByDepartmentSearchRequest : PaginationRequest
    {
        public int DepartmentId { get; set; }
        public string Filter { get; set; }
    }
}
