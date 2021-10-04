using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Support.Requests.Control
{
    public class GetControlsByRiskRequest: PaginationRequest
    {
        public Guid RiskId { get; set; }
    }
}
