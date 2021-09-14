namespace Util.Support.Requests.Risk
{
    public class GetRiskByCategoryAndDescriptionRequest : PaginationRequest
    {
        public int RiskCategoryId { get; set; }
        public string Filter { get; set; }
    }
}