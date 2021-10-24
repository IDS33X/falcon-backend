using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Support.Responses.MAutomationLevel;

namespace Service.Service
{
    public interface IMAutomationLevelService
    {
        Task<GetAutomationLevelsResponse> GetAll();
    }
}
