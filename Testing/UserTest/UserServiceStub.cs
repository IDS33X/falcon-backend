using AutoMapper;
using Domain.Models;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Dtos.User;
using Util.Mappings;
using Util.Support.Requests.User;
using Util.Support.Responses.User;

namespace Testing.UserTest
{
    public class UserServiceStub : IUserService
    {
        private static List<UserProfile> users = new List<UserProfile>();
        private static int usersCount = 0;

        private readonly IMapper _mapper;

        public UserServiceStub()
        {
            _mapper = new Mapper(AutoMapperConfiguration.GetConfig());
            users.Clear();
        }

        public async Task<AddUserResponse> Add(AddUserRequest request)
        {
            usersCount++;
            var user = _mapper.Map<UserProfile>(request.User);
            user.Id = usersCount;

            await Task.Run(() => users.Add(user));

            var userDto = _mapper.Map<UserDto>(user);

            return new AddUserResponse { User = userDto };
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await Task.Run(() => users.Where(u => u.Id == id).FirstOrDefault());

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<UsersByDepartmentResponse> GetUsersByDepartment(UsersByDepartmentRequest request)
        {
            var dtos = new List<UserDto>();

            foreach (var u in users)
            {
                if (u.DepartmentId == request.DepartmentId)
                {
                    dtos.Add(_mapper.Map<UserDto>(u));
                }
            }

            return new UsersByDepartmentResponse { Users = dtos };
        }

        public Task<UsersByDepartmentSearchResponse> GetUsersByDepartmentAndSearch(UsersByDepartmentSearchRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<EditUserLoginResponse> UpdatePassword(EditUserLoginRequest request)
        {
            var userProfile = _mapper.Map<UserProfile>(users.Where(u => u.Id == request.UserPassword.Id).FirstOrDefault());

            userProfile.User.Password = request.UserPassword.Password;

            var userUpdated = _mapper.Map<UserDto>(userProfile);

            return new EditUserLoginResponse { WasPasswordChanged = userUpdated != null };
        }

        public async Task<EditUserProfileResponse> UpdateProfile(EditUserProfileRequest request)
        {
            var user = _mapper.Map<UserProfile>(request.User);

            var update = users.Where(u => u.Id == request.User.Id).FirstOrDefault();

            update = user;

            var updatedUser = _mapper.Map<UserDto>(update);

            return new EditUserProfileResponse { User = updatedUser };
        }

        public static void clearDatabase()
        {
            users.Clear();
            usersCount = 0;
        }

        public static void AddRange(List<UserProfile> fakesUsers)
        {
            users.AddRange(fakesUsers);
        }
    }
}
