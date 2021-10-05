using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Util.Support.Requests.RiskControl
{
    public class AddRangeRiskControlRequest
    {
        public IEnumerable<RiskControlDto> RiskControls { get; set; }
    }
}
