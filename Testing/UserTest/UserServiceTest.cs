using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Util.Dtos.User;
using Util.Support.Requests.User;
using Util.Support.Responses.User;
using Xunit;

namespace Testing.UserTest
{
    public class UserServiceTest
    {
        private readonly UserServiceStub _userService;
        public UserServiceTest()
        {
            _userService = new UserServiceStub();
        }

        // Arrange --> in this section you setup everything to be ready to executed the test 

        // Act --> in this section we call the method(Perform the action) that we are testing.

        // Assert --> in this section we verify the result.
        [Fact]
        public async void AddUser_withCorrectParameters_returnTheAddedUser()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            var addUserDto = new AddUserDto
            {
                Code = "EC001",
                DepartmentId = 1,
                Name = "Antonio",
                LastName = "Gomez",
                Username = "antgomez",
                Password = "12345678",
                RoleId = 1,
            };

            var request = new AddUserRequest { User = addUserDto };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _userService.Add(request);

            // Assert --> in this section we verify the result.
            int expectedId = 1;
            Assert.NotNull(response);
            Assert.IsType<AddUserResponse>(response);
            Assert.Equal(response.User.Code, request.User.Code);
            Assert.Equal(response.User.Name, request.User.Name);
            Assert.Equal(response.User.DepartmentId, request.User.DepartmentId);
            Assert.Equal(response.User.LastName, request.User.LastName);
            Assert.Equal(response.User.RoleId, request.User.RoleId);
            Assert.Equal(response.User.Username, request.User.Username);
            Assert.Equal(response.User.Id, expectedId);
            UserServiceStub.clearDatabase();
        }

        [Fact]
        public async void GetUserById_ReturnAnUserWhichIdMatchTheSenderId()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insertFakesUsers();
            var request = 2; //id

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _userService.GetById(request);

            // Assert --> in this section we verify the result.
            Assert.IsType<UserDto>(response);
            Assert.NotNull(response);
            Assert.Equal(request, response.Id);
            UserServiceStub.clearDatabase();
        }
        [Fact]
        public async void UpdateUserProfile_ReturnsUserProfileUpdated()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insertFakesUsers();
            var userUpdateDto = new UpdateUserProfileDto
            {
                Id = 2,
                Name = "Carlos",
                LastName = "Almanzar",
                DepartmentId = 1
            };
            var request = new EditUserProfileRequest() { User = userUpdateDto };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _userService.UpdateProfile(request);

            // Assert --> in this section we verify the result.
            int expectedId = 2;
            Assert.NotNull(response);
            Assert.IsType<EditUserProfileResponse>(response);
            Assert.Equal(response.User.Name, request.User.Name);
            Assert.Equal(response.User.DepartmentId, request.User.DepartmentId);
            Assert.Equal(response.User.LastName, request.User.LastName);
            Assert.Equal(expectedId, response.User.Id);
            UserServiceStub.clearDatabase();
        }
        [Fact]
        public async void UpdateUserPassword_ReturnsWasUserPasswordChanged()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            insertFakesUsers();
            var updatePassword = new UpdateUserPasswordDto() { Id = 2, Password = "87654321" };

            var request = new EditUserLoginRequest() { UserPassword = updatePassword };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _userService.UpdatePassword(request);

            // Assert --> in this section we verify the result.
            bool expectedResult = true;

            Assert.NotNull(response);
            Assert.IsType<EditUserLoginResponse>(response);
            Assert.Equal(response.WasPasswordChanged, expectedResult);
            UserServiceStub.clearDatabase();

        }
        [Fact]
        public async void GetUsersByDepartment_ReturnAllUsersInsideDepartment()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insertFakesUsers();
            var request = new UsersByDepartmentRequest() { DepartmentId = 1 };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _userService.GetUsersByDepartment(request);

            // Assert --> in this section we verify the result.
            int expectedTotalOfRisk = 2;
            Assert.NotNull(response);
            Assert.IsType<UsersByDepartmentResponse>(response);
            Assert.Equal(expectedTotalOfRisk, response.Users.Count());
            UserServiceStub.clearDatabase();
        }

        private void insertFakesUsers()
        {
            var user1 = new UserProfile
            {
                Id = 2,
                Code = "EC002",
                DepartmentId = 1,
                Name = "Carlos",
                LastName = "Almansar",
                User = new User
                {
                    Username = "carmaz",
                    Password = "12345678",
                    Id = new Guid(),
                    UserRoleId = 1,
                    Seq = 2,
                    Enabled = true,
                    UserRole = new MRole
                    {
                        Id = 1,
                        Title = "Administrador",
                        Description = "Administra el sistema"
                    },
                }
            };
            
            var user2 = new UserProfile
            {
                Id = 3,
                Code = "EC003",
                DepartmentId = 1,
                Name = "Lorenzo",
                LastName = "Lopez",
                User = new User
                {
                    Username = "lorpez",
                    Password = "12345678",
                    Id = new Guid(),
                    UserRoleId = 1,
                    Seq = 3,
                    Enabled = true,
                    UserRole = new MRole
                    {
                        Id = 1,
                        Title = "Administrador",
                        Description = "Administra el sistema"
                    },
                }
            };

            var user3 = new UserProfile
            {
                Id = 4,
                Code = "EC004",
                DepartmentId = 2,
                Name = "Alfredo",
                LastName = "Justo",
                User = new User
                {
                    Username = "alfsto",
                    Password = "12345678",
                    Id = new Guid(),
                    UserRoleId = 2,
                    Seq = 4,
                    Enabled = true,
                    UserRole = new MRole
                    {
                        Id = 2,
                        Title = "Analista de Riesgos",
                        Description = "Administra los riesgos y controles"
                    },
                }
            };

            var listOfUsers = new List<UserProfile> { user1, user2, user3 };

            UserServiceStub.AddRange(listOfUsers);
        }
    }
}
