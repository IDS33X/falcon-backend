namespace Util.Support.Requests.Risk
{
    public class GetRiskByCategoryAndCodeRequest : PaginationRequest
    {
        public int RiskCategoryId { get; set; }
        public string Filter { get; set; }
    }
}
