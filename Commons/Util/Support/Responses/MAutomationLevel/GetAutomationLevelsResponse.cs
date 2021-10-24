using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Dtos.AutomationLevelDtos;

namespace Util.Support.Responses.MAutomationLevel
{
    public class GetAutomationLevelsResponse
    {

        public IEnumerable<MAutomationLevelReadDto> AutomationLevels { get; set; }

    }
}
