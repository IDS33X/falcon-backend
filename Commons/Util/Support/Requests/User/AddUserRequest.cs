using System.ComponentModel.DataAnnotations;
using Util.Dtos.User;

namespace Util.Support.Requests.User
{
    public class AddUserRequest
    {
        [Required]
        public AddUserDto User { get; set; }
    }
}
