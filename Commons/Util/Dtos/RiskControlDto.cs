using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Dtos
{
    public class RiskControlDto
    {
        public int Id { get; set; }

        public Guid RiskId { get; set; }

        public Guid ControlId { get; set; }

        public DateTime AssignDate { get; set; }

        public DateTime? DeallocatedDate { get; set; }

    }
}
