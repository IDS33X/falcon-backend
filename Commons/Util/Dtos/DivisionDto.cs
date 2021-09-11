using System.Collections.Generic;

namespace Util.Dtos
{
    public class DivisionDto
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CountDepartments { get; set; }

    }
}
