namespace Util.Support.Requests.Department
{
    public class DepartmentsByDivisionRequest : PaginationRequest
    {
        public int DivisionId { get; set; }
    }
}
