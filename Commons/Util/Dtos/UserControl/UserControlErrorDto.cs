using System;

namespace Util.Dtos.UserControl
{
    public class UserControlErrorDto
    {
        public int UserId { get; set; }

        public Guid ControlId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
