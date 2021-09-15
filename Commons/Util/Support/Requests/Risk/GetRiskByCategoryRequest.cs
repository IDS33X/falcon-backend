namespace Util.Support.Requests.Risk
{
    public class GetRiskByCategoryRequest : PaginationRequest
    {
        public int RiskCategoryId { get; set; }
    }
}
