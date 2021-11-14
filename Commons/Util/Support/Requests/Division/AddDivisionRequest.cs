using System.ComponentModel.DataAnnotations;
using Util.Dtos.DivisionDtos;

namespace Util.Support.Requests.Division
{
    public class AddDivisionRequest
    {
        [Required]
        public DivisionCreateDto Division { get; set; }
    }
}
