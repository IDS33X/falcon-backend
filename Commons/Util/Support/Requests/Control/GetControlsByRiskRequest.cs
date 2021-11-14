using System;
using System.ComponentModel.DataAnnotations;

namespace Util.Support.Requests.Control
{
    public class GetControlsByRiskRequest: PaginationRequest
    {
        [Required]
        public Guid? RiskId { get; set; }
    }
}
