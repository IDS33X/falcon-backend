namespace Util.Support.Requests.Division
{
    public class DivisionsByAreaSearchRequest : PaginationRequest
    {
        public int AreaId { get; set; }
        public string Filter { get; set; }
    }
}
