using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos.DivisionDtos;
using Util.Support.Requests.Division;
using Util.Support.Responses.Division;
using Xunit;
using Domain.Models;

namespace Testing.DivisionTests
{
    public class DivisionServiceTest
    {
        private readonly DivisionServiceStub _divisionService;

        public DivisionServiceTest()
        {
            _divisionService = new DivisionServiceStub();
        }

        // Arrange --> in this section you setup everything to be ready to executed the test 

        // Act --> in this section we call the method(Perform the action) that we are testing.

        // Assert --> in this section we verify the result.
       
        [Fact]
        public async void AddDivision_withCorrectParameters_returnTheAddedDivision()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            var divCreateDto = new DivisionCreateDto() { Title = "Division de prueba 1",
                                                        Description = "Descripcion de la prueba 1", UserId = 1 };
            var request = new AddDivisionRequest() { Division = divCreateDto };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _divisionService.Add(request);

            // Assert --> in this section we verify the result.
            int expectedId = 1;
            Assert.NotNull(response);
            Assert.IsType<AddDivisionResponse>(response);
            Assert.Equal(expectedId, response.Division.Id);
            Assert.Equal(request.Division.Title, response.Division.Title);
            Assert.Equal(request.Division.Description, response.Division.Description);
            DivisionServiceStub.clearDatabase();
        }

        [Fact]
        public async void GetDivisionById_ReturnADivisionWhichIdMatchTheSendedId()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insertFakesDivisions();
            var request = 3; //id

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _divisionService.GetById(request);

            // Assert --> in this section we verify the result.
            Assert.IsType<DivisionReadDto>(response);
            Assert.NotNull(response);
            Assert.Equal(request, response.Id);
            DivisionServiceStub.clearDatabase();
        }

        [Fact]
        public async void GetDivisionsByArea_ReturnAllTheDivisionsInsideAnArea()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            insertFakesDivisions();
            var request = new DivisionsByAreaRequest() { AreaId=1};

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _divisionService.GetDivisionsByArea(request);

            // Assert --> in this section we verify the result.
            int expectedTotalOfDiv = 2;
            Assert.IsType<DivisionsByAreaResponse>(response);
            Assert.NotNull(response);
            Assert.Equal(expectedTotalOfDiv, response.Divisions.Count());
            DivisionServiceStub.clearDatabase();
            
        }

        [Fact]
        public async void GetDivisionsByAreaSearch_ReturnDivisionsInsideAnAreaThatContainsTheFilter()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            insertFakesDivisions();
            var request = new DivisionsByAreaSearchRequest() { AreaId = 1, Filter = "3" };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _divisionService.GetDivisionsByAreaAndSearch(request);

            // Assert --> in this section we verify the result.
            int expectedTotalOfDiv = 1;
            Assert.IsType<DivisionsByAreaSearchResponse>(response);
            Assert.NotNull(response);
            Assert.Equal(expectedTotalOfDiv, response.Divisions.Count());
            DivisionServiceStub.clearDatabase();

        }
        
        [Fact]
        public async void DeleteDivisionById_ReturnTrueIfTheDivisionWasDeleted()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insertFakesDivisions();
            var request = 1;

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _divisionService.Removed(request);

            // Assert --> in this section we verify the result.
            bool expectedResponse = true;
            Assert.IsType<bool>(response);
            Assert.Equal(expectedResponse, response);
            DivisionServiceStub.clearDatabase();
            
        }

        [Fact]
        public async void UpdateDivision_ReturnsDivisionUpdated()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insertFakesDivisions();
            var divUpdateDto = new DivisionUpdateDto() { Id = 1, Title = "Div de preuba 1 actualizada", Description = "Descripcion Actualizada" };
            var request = new EditDivisionRequest() { Division = divUpdateDto };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _divisionService.Update(request);


            // Assert --> in this section we verify the result.
            int expextedId = 1;
            Assert.NotNull(response);
            Assert.IsType<EditDivisionResponse>(response);
            Assert.Equal(expextedId, response.Division.Id);
            Assert.Equal(request.Division.Title, response.Division.Title);
            Assert.Equal(request.Division.Description, response.Division.Description);
            DivisionServiceStub.clearDatabase();
        }

        private void insertFakesDivisions()
        {
            var division1 = new Division { Id = 1, Title = "Division 1 Test", Description = "Des... division 1", AreaId=1 };
            var division2 = new Division { Id = 2, Title = "Division 2", Description = "Des... division 2", AreaId=4 };
            var division3 = new Division { Id = 3, Title = "Division 3 Test", Description = "Des... division 3" ,AreaId=1};
            var division4 = new Division { Id = 4, Title = "Division 4", Description = "Des... division 4" ,AreaId=2};

            var listOfDivisions = new List<Division> { division1,division2,division3,division4};

            DivisionServiceStub.AddRange(listOfDivisions);
        }
    }
}
