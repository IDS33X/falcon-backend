using Util.Dtos;

namespace Util.Support.Response
{
    public class LogInResponse
    {
        public EmployeeDto Employee { get; set; }
        public string Token { get; set; }
    }
}
