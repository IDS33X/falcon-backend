namespace Util.Support.Requests.User
{
    public class UsersByDepartmentSearchRequest : PaginationRequest
    {
        public int DepartmentId { get; set; }
        public string Filter { get; set; }
    }
}
