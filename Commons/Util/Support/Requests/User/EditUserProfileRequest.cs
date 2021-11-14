using System.ComponentModel.DataAnnotations;
using Util.Dtos.User;

namespace Util.Support.Requests.User
{
    public class EditUserProfileRequest
    {
        [Required]
        public UpdateUserProfileDto User { get; set; }
    }
}
