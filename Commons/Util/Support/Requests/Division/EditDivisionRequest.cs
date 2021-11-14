using System.ComponentModel.DataAnnotations;
using Util.Dtos.DivisionDtos;

namespace Util.Support.Requests.Division
{
    public class EditDivisionRequest
    {
        [Required]
        public DivisionUpdateDto Division { get; set; }

    }
}
