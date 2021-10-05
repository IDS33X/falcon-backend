using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Support.Requests.Control;
using Util.Support.Responses.Control;

namespace Service.Service
{
    public interface IControlService
    {
        Task<AddControlResponse> Add(AddControlRequest request);
        Task<EditControlResponse> Update(EditControlRequest request);
        Task<ControlByCodeResponse> GetByCode(ControlByCodeRequest request);
        Task<GetControlsResponse> GetControls(GetControlsRequest request);
        Task<GetControlsByRiskResponse> GetControlsByRisk(GetControlsByRiskRequest request);
        Task<GetControlsByUserResponse> GetControlsByUser(GetControlsByUserRequest request);
    }
}
