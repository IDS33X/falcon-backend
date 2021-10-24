using System;

namespace Util.Dtos.UserControl
{
    public class UserControlDto
    {
        public int UserId { get; set; }

        public Guid ControlId { get; set; }

        public DateTime AssignDate { get; set; }

        public DateTime? DeallocatedDate { get; set; }

    }
}
