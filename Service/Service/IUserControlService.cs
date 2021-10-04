using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Support.Requests.UserControl;
using Util.Support.Responses.UserControl;

namespace Service.Service
{
    public interface IUserControlService
    {
        Task<AddUserControlResponse> Add(AddUserControlRequest request);

        Task<AddRangeUserControlResponse> AddRange(AddRangeUserControlRequest request);

        Task<EditUserControlResponse> Remove(EditUserControlRequest request);

        Task<EditRangeUserControlResponse> RemoveRange(EditRangeUserControlRequest request);
    }
}
