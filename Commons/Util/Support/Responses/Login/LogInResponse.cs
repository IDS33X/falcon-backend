using Util.Dtos;

namespace Util.Support.Response
{
    public class LogInResponse
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
