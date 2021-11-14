using System.ComponentModel.DataAnnotations;
using Util.Dtos.AreaDtos;

namespace Util.Support.Requests.Area
{
    public class AddAreaRequest
    {
        [Required]
        public AreaCreateDto Area { get; set; }
    }
}
