using System.ComponentModel.DataAnnotations;
using Util.Dtos.User;

namespace Util.Support.Requests.User
{
    public class EditUserLoginRequest
    {
        [Required]
        public UpdateUserPasswordDto UserPassword { get; set; }
    }
}
