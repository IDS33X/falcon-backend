namespace Util.Support.Requests.Department
{
    public class DepartmentsByDivisionSearchRequest : PaginationRequest
    {
        public int DivisionId { get; set; }
        public string Filter { get; set; }
    }
}