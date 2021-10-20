using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Util.Support.Responses.MAutomationLevel
{
    public class GetAutomationLevelsResponse
    {

        public IEnumerable<MAutomationLevelDto> AutomationLevels { get; set; }

    }
}
