namespace Util.Support.Requests.Employee
{
    public class EmployeesByDepartmentSearchRequest : PaginationRequest
    {
        public int DepartmentId { get; set; }
        public string Filter { get; set; }
    }
}