namespace Util.Support.Requests.Employee
{
    public class EmployeesByDepartmentRequest : PaginationRequest
    {
        public int DepartmentId { get; set; }
    }
}
