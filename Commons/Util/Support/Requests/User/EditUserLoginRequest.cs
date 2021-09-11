using System;

namespace Util.Support.Requests.User
{
    public class EditUserLoginRequest
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
