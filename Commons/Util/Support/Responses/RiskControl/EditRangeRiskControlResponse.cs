﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Util.Support.Responses.RiskControl
{
    public class EditRangeRiskControlResponse
    {
        public IEnumerable<RiskControlDto> RiskControls { get; set; }
    }
}