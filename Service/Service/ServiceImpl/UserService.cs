using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.User;
using Util.Support.Responses.User;

namespace Service.Service.ServiceImpl
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddUserResponse> Add(AddUserRequest request)
        {
            var user = _mapper.Map<UserProfile>(request.User);

            user = await _unitOfWork.UserProfiles.Add(user);
            await _unitOfWork.CompleteAsync();

            var userDto = _mapper.Map<UserDto>(user);

            return new AddUserResponse { User = userDto };
        }

        public async Task<UsersByDepartmentResponse> GetUsersByDepartment(UsersByDepartmentRequest request)
        {
            var users = await _unitOfWork.UserProfiles.GetUsersByDepartment(request.DepartmentId, request.Page, request.ItemsPerPage);

            List<UserDto> userDtos = new List<UserDto>();

            foreach (UserProfile user in users)
            {
                var userDto = _mapper.Map<UserDto>(user);

                userDtos.Add(userDto);
            }

            int usersByDepartmentCount = await _unitOfWork.UserProfiles.GetUsersByDepartmentCount(request.DepartmentId);
            int pages = Convert.ToInt32(Math.Ceiling((double)usersByDepartmentCount / request.ItemsPerPage));

            UsersByDepartmentResponse response = new UsersByDepartmentResponse
            {
                AmountOfPages = pages,
                CurrentPage = userDtos.Count > 0 ? request.Page : 0,
                Users = userDtos,
                TotalOfItems = usersByDepartmentCount
            };

            return response;
        }
        public async Task<UsersByDepartmentSearchResponse> GetUsersByDepartmentAndSearch(UsersByDepartmentSearchRequest request)
        {
            var users = await _unitOfWork.UserProfiles.GetUsersByDepartmentSearch(request.DepartmentId, request.Filter, request.Page, request.ItemsPerPage);

            List<UserDto> userDtos = new List<UserDto>();

            foreach (UserProfile user in users)
            {
                var userDto = _mapper.Map<UserDto>(user);

                userDtos.Add(userDto);
            }

            int usersByDepartmentAndSearchCount = await _unitOfWork.UserProfiles.GetUsersByDepartmentSearchCount(request.DepartmentId, request.Filter);
            int pages = Convert.ToInt32(Math.Ceiling((double)usersByDepartmentAndSearchCount / request.ItemsPerPage));

            UsersByDepartmentSearchResponse response = new UsersByDepartmentSearchResponse
            {
                AmountOfPages = pages,
                CurrentPage = userDtos.Count > 0 ? request.Page : 0,
                Users = userDtos,
                TotalOfItems = usersByDepartmentAndSearchCount
            };

            return response;
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _unitOfWork.UserProfiles.GetById(id);

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        //public async Task<bool> Removed(int id)
        //{
        //    var isRemoved = await _unitOfWork.Employees.Removed(id);
        //    await _unitOfWork.CompleteAsync();

        //    return isRemoved;
        //}

        public async Task<EditUserProfileResponse> UpdateProfile(EditUserProfileRequest request)
        {
            var userProfile = _mapper.Map<UserProfile>(request.User);

            userProfile.User = null;

            var userUpdated = await _unitOfWork.UserProfiles.Update(userProfile);
            var userUpdatedDto = _mapper.Map<UserDto>(userUpdated);
            await _unitOfWork.CompleteAsync();
            userUpdatedDto.Password = null;

            return new EditUserProfileResponse { User = userUpdatedDto };
        }

        public async Task<EditUserLoginResponse> UpdateLogin(EditUserLoginRequest request)
        {
            var user = await _unitOfWork.Users.GetById(request.Id);

            user.Username = request.Username;

            user.Password = !string.IsNullOrWhiteSpace(request.Password) ? request.Password : user.Password;

            var userUpdated = await _unitOfWork.Users.Update(user);

            await _unitOfWork.CompleteAsync();

            return new EditUserLoginResponse { Id = userUpdated.Id, WasUserUpdated = userUpdated != null };
        }
    }
}
