using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Support.Requests.RiskControl;
using Util.Support.Responses.RiskControl;

namespace Service.Service
{
    public interface IRiskControlService
    {
        Task<AddRiskControlResponse> Add(AddRiskControlRequest request);

        Task<AddRangeRiskControlResponse> AddRange(AddRangeRiskControlRequest request);

        Task<EditRiskControlResponse> Remove(EditRiskControlRequest request);

        Task<EditRangeRiskControlResponse> RemoveRange(EditRangeRiskControlRequest request);

    }
}
