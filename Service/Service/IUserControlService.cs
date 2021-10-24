using System.Threading.Tasks;
using Util.Support.Requests.UserControl;
using Util.Support.Responses.UserControl;

namespace Service.Service
{
    public interface IUserControlService
    {
        Task<AddUserControlResponse> Add(AddUserControlRequest request);

        Task<AddRangeUserControlResponse> AddRange(AddRangeUserControlRequest request);

        Task<RemoveUserControlResponse> Remove(RemoveUserControlRequest request);

        Task<RemoveRangeUserControlResponse> RemoveRange(RemoveRangeUserControlRequest request);
    }
}
