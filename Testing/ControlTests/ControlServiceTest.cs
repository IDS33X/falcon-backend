using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos.ControlDtos;
using Util.Support.Requests.Control;
using Util.Support.Responses.Control;
using Xunit;

namespace Testing.ControlTests
{
    public class ControlServiceTest
    {
        private readonly ControlServiceStub _cService;

        public ControlServiceTest()
        {
            _cService = new ControlServiceStub();
        }

        // Arrange --> in this section you setup everything to be ready to executed the test 

        // Act --> in this section we call the method(Perform the action) that we are testing.

        // Assert --> in this section we verify the result.

        [Fact]
        public async void AddControl_withCorrectParameters_returnTheAddedControl()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            var conCreateDto = new ControlCreateDto()
            {
                Code="C0001",
                Evidence="Evidence control 1",
                Policy="Control Policies"
            };
            var request = new AddControlRequest() { Control = conCreateDto };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _cService.Add(request);

            // Assert --> in this section we verify the result.
            Assert.NotNull(response);
            Assert.IsType<AddControlResponse>(response);
            Assert.Equal(request.Control.Code, response.Control.Code);
            Assert.Equal(request.Control.Evidence, response.Control.Evidence);
            ControlServiceStub.clearDatabase();
        }

        [Fact]
        public async void GetControlByRisk_ReturnAllTheControlsInsideArisk()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            insertFakesControls();
            var request = new GetControlsByRiskRequest() { RiskId = Guid.NewGuid()};

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _cService.GetControlsByRisk(request);

            // Assert --> in this section we verify the result.
            Assert.IsType<GetControlsByRiskResponse>(response);
            ControlServiceStub.clearDatabase();

        }

        [Fact]
        public async void GetDepartmentsByDivision_ReturnAllTheDepartmentsInsideADivision()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            insertFakesControls();
            var request = new GetControlsByRiskCategoryRequest() { RiskCategoryId = 1 };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _cService.GetControlsByRiskCategory(request);

            // Assert --> in this section we verify the result.
            int expectedTotalOfDep = 2;
            Assert.IsType<GetControlsByRiskCategoryResponse>(response);
            Assert.NotNull(response);
            Assert.Equal(expectedTotalOfDep, response.Controls.Count());
            ControlServiceStub.clearDatabase();

        }

        private void insertFakesControls()
        {
            var control1 = new Control() { Id = Guid.NewGuid(), Code = "C0001", Evidence = "Evidence 1", Policy = "Policy 1", RiskCategoryId =1 };
            var control2 = new Control() { Id = Guid.NewGuid(), Code = "C0002", Evidence = "Evidence 2", Policy = "Policy 2" ,RiskCategoryId = 1};
            var control3 = new Control() { Id = Guid.NewGuid(), Code = "C0003", Evidence = "Evidence 3", Policy = "Policy 3" , RiskCategoryId =2};
            var control4 = new Control() { Id = Guid.NewGuid(), Code = "C0004", Evidence = "Evidence 4", Policy = "Policy 4" , RiskCategoryId =2};

            var list = new List<Control>() {control1,control2,control3,control4 };

            ControlServiceStub.AddRange(list);
            
        }
    }
}
