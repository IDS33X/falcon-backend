using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos.DepartmentDtos;
using Util.Support.Requests.Department;
using Util.Support.Responses.Department;
using Xunit;

namespace Testing.DepartmentTests
{
    public class DepartmentServiceTest
    {
        private readonly DepartmentServiceStub _departmentService;

        public DepartmentServiceTest()
        {
            _departmentService = new DepartmentServiceStub();
        }

        // Arrange --> in this section you setup everything to be ready to executed the test 

        // Act --> in this section we call the method(Perform the action) that we are testing.

        // Assert --> in this section we verify the result.

        [Fact]
        public async void AddDepartment_withCorrectParameters_returnTheAddedDepartment()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            var depCreateDto = new DepartmentCreateDto()
            {
                Title = "Department 1",
                Description = "Dep 1 description ..",
                DivisionId = 1
            };
            var request = new AddDepartmentRequest() { Department = depCreateDto };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _departmentService.Add(request);

            // Assert --> in this section we verify the result.
            int expectedId = 1;
            Assert.NotNull(response);
            Assert.IsType<AddDepartmentResponse>(response);
            Assert.Equal(expectedId, response.Department.Id);
            Assert.Equal(request.Department.Title, response.Department.Title);
            Assert.Equal(request.Department.Description, response.Department.Description);
            DepartmentServiceStub.clearDatabase();
        }

        [Fact]
        public async void GetDepartmentById_ReturnADepartmentnWhichIdMatchTheSendedId()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insertFakesDepartments();
            var request = 1; //id

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _departmentService.GetById(request);

            // Assert --> in this section we verify the result.
            Assert.IsType<DepartmentReadDto>(response);
            Assert.NotNull(response);
            Assert.Equal(request, response.Id);
            DepartmentServiceStub.clearDatabase();
        }

        [Fact]
        public async void GetDepartmentsByDivision_ReturnAllTheDepartmentsInsideADivision()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            insertFakesDepartments();
            var request = new DepartmentsByDivisionRequest() { DivisionId = 1};

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _departmentService.GetDepartmentsByDivision(request);

            // Assert --> in this section we verify the result.
            int expectedTotalOfDep = 2;
            Assert.IsType<DepartmentsByDivisionResponse>(response);
            Assert.NotNull(response);
            Assert.Equal(expectedTotalOfDep, response.Departments.Count());
            DepartmentServiceStub.clearDatabase();

        }

        [Fact]
        public async void GetDepartmentsByDivisionSearch_ReturnAllTheDepartmentsInsideADivisionThatContainsTheFilter()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            insertFakesDepartments();
            var request = new DepartmentsByDivisionSearchRequest() { DivisionId = 1, Filter="Test" };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _departmentService.GetDepartmentsByDivisionAndSearch(request);

            // Assert --> in this section we verify the result.
            int expectedTotalOfDep = 1;
            Assert.IsType<DepartmentsByDivisionSearchResponse>(response);
            Assert.NotNull(response);
            Assert.Equal(expectedTotalOfDep, response.Departments.Count());
            DepartmentServiceStub.clearDatabase();

        }

        [Fact]
        public async void DeleteDepartmentById_ReturnTrueIfTheDepartmentWasDeleted()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insertFakesDepartments();
            var request = 1;

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _departmentService.Removed(request);

            // Assert --> in this section we verify the result.
            bool expectedResponse = true;
            Assert.IsType<bool>(response);
            Assert.Equal(expectedResponse, response);
            DepartmentServiceStub.clearDatabase();

        }

        [Fact]
        public async void UpdateDepartment_ReturnsDepartmentUpdated()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insertFakesDepartments();
            var depUpdateDto = new DepartmentUpdateDto() { Id = 1, Title = "Dep actualizado", Description = "Descripcion Actualizada"};
            var request = new EditDepartmentRequest() { Department = depUpdateDto };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _departmentService.Update(request);


            // Assert --> in this section we verify the result.
            int expextedId = 1;
            Assert.NotNull(response);
            Assert.IsType<EditDepartmentResponse>(response);
            Assert.Equal(expextedId, response.Department.Id);
            Assert.Equal(request.Department.Title, response.Department.Title);
            Assert.Equal(request.Department.Description, response.Department.Description);
            DepartmentServiceStub.clearDatabase();
        }

        private void insertFakesDepartments()
        {
            var department1 = new Department() { Id=1,Title="Dep 1",Description="Description dep 1..",DivisionId=2};
            var department2 = new Department() { Id = 2, Title = "Dep 2 Test", Description = "Description dep 2 Test", DivisionId = 1 };
            var department3 = new Department() { Id = 3, Title = "Dep 3", Description = "Description dep 3..", DivisionId = 1 };
            var department4 = new Department() { Id = 4, Title = "Dep 4", Description = "Description dep 1 Test", DivisionId = 4 };

            var listOfDepartments = new List<Department> { department1, department2, department3, department4 };

            DepartmentServiceStub.AddRange(listOfDepartments);
        }
    }
}
