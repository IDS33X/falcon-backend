using System.ComponentModel.DataAnnotations;
using Util.Dtos.AreaDtos;

namespace Util.Support.Requests.Area
{
    public class EditAreaRequest
    {
        [Required]
        public AreaUpdateDto Area { get; set; }
    }
}
