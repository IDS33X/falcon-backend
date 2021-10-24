using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using Service.Service;
using Util.Dtos.User;
using Util.Support.Requests;

namespace Service.ServiceImpl
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SessionService(IUnitOfWork unitOfWork,IMapper mapper){
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserDto> Login(LogInRequest login)
        {
            UserProfile userProfile = await _unitOfWork.UserProfiles.Login(login.Username, login.Password);

            UserDto dto = _mapper.Map<UserDto>(userProfile);
            return dto;

        }
    }
}