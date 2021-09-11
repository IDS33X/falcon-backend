using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests;

namespace Service.Service
{
    public interface ISessionService
    {
        Task<UserDto> Login(LogInRequest login);
    }
}