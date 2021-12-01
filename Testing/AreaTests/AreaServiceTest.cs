using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Util.Dtos.AreaDtos;
using Util.Support.Requests.Area;
using Util.Support.Responses.Area;
using Domain.Models;

namespace Testing.AreaTests
{
    public class AreaServiceTest
    {
        private readonly AreaServiceStub _areaService;
        public AreaServiceTest()
        {
            _areaService = new AreaServiceStub();
        }

        // Arrange --> in this section you setup everything to be ready to executed the test 

        // Act --> in this section we call the method(Perform the action) that we are testing.

        // Assert --> in this section we verify the result.

        [Fact]
        public async void AddArea_withCorrectParameters_returnTheAddedArea()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            var areaCreateDto = new AreaCreateDto { Title = "Area de prueba", Description = "descripcion del area ..." };
            var request = new AddAreaRequest { Area = areaCreateDto };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _areaService.Add(request);

            // Assert --> in this section we verify the result.
            int expectedId = 1;
            Assert.NotNull(response);
            Assert.IsType<AddAreaResponse>(response);
            Assert.Equal(response.Area.Title,request.Area.Title);
            Assert.Equal(response.Area.Description, request.Area.Description);
            Assert.Equal(response.Area.Id, expectedId);
            AreaServiceStub.clearDatabase();
        }

        [Fact]
        public async void GetAllAreas_ReturnAllRegisteredAreas()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insetFakesAreas();
            var request = new GetAreasRequest() { Page = 1, ItemsPerPage = 10 }; //deafult values

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _areaService.GetAreas(request);

            // Assert --> in this section we verify the result.
            int expectedTotalOfAreas = 4;
            Assert.IsType<GetAreasResponse>(response);
            Assert.NotNull(response);
            Assert.Equal(expectedTotalOfAreas,response.Areas.Count());
            AreaServiceStub.clearDatabase();

        }

        [Fact]
        public async void GetAreasBySearch_ReturnAreasThatContainsTheFilterInTheTitle()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insetFakesAreas();
            var request = new GetAreasSearchRequest() { Filter = " Test", Page = 1, ItemsPerPage = 10 };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _areaService.GetAreasBySearch(request);

            // Assert --> in this section we verify the result.
            int expectedTotalOfAreas = 2;
            Assert.IsType<GetAreasSearchResponse>(response);
            Assert.NotNull(response);
            Assert.Equal(expectedTotalOfAreas, response.Areas.Count());
            AreaServiceStub.clearDatabase();
        }

        [Fact]
        public async void GetAreaById_ReturnAnAreaWhichIdMatchTheSendedId()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insetFakesAreas();
            var request = 2; //id

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _areaService.GetById(request);

            // Assert --> in this section we verify the result.
            Assert.IsType<AreaReadDto>(response);
            Assert.NotNull(response);
            Assert.Equal(request, response.Id);
            AreaServiceStub.clearDatabase();
        }

        [Fact]
        public async void DeleteAreaById_ReturnTrueIsAreaWasDeleted()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test 
            insetFakesAreas();
            var request = 2;

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _areaService.Removed(request);

            // Assert --> in this section we verify the result.
            bool expectedResponse = true;
            Assert.IsType<bool>(response);
            Assert.Equal(expectedResponse, response);
            AreaServiceStub.clearDatabase();
        }

        [Fact]
        public async void UpdateArea_ReturnsAreaUpdated()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            insetFakesAreas();
            var areaUpdateDto = new AreaUpdateDto() { Id = 1, Title = "Area de pruba 1 Actualizada", Description = "Descripcion actualizada..." };
            var request = new EditAreaRequest() { Area = areaUpdateDto };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _areaService.Update(request);

            // Assert --> in this section we verify the result.
            int expextedId = 1;
            Assert.NotNull(response);
            Assert.IsType<EditAreaResponse>(response);
            Assert.Equal(expextedId, response.Area.Id);
            Assert.Equal(areaUpdateDto.Title, response.Area.Title);
            Assert.Equal(areaUpdateDto.Description, response.Area.Description);
            AreaServiceStub.clearDatabase();
        }

        private void insetFakesAreas()
        {
            var area1 = new Area { Id=1,Title = "Area de prueba 1", Description = "descripcion del area 1..." };
            var area2 = new Area { Id=2,Title = "Area de prueba 2 Test", Description = "descripcion del area 2..." };
            var area3 = new Area { Id=3,Title = "Area de prueba 3", Description = "descripcion del area 3..." };
            var area4 = new Area { Id=4,Title = "Area de prueba 4 Test", Description = "descripcion del area 4..." };

            var listOfAreas = new List<Area> { area1, area2, area3, area4 };

            AreaServiceStub.AddRange(listOfAreas);
        }


    }
}
