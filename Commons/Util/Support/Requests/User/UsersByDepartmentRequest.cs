namespace Util.Support.Requests.User
{
    public class UsersByDepartmentRequest : PaginationRequest
    {
        public int DepartmentId { get; set; }
    }
}
