using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos.Risk;
using Util.Support.Requests.Risk;
using Util.Support.Responses.Risk;
using Xunit;

namespace Testing.RiskTests
{
    public class RiskServiceTest
    {
        private readonly RiskServiceStub _rService;

        public RiskServiceTest()
        {
            _rService = new RiskServiceStub();
        }

        [Fact]
        public async void AddRisk_withCorrectParameters_returnTheAddedRisk()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            var dto = new AddRiskDto()
            {
                Description = "Description risk 1..",
                RiskCategoryId = 1
            };

            var request = new AddRiskRequest() { Risk = dto };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _rService.Add(request);

            // Assert --> in this section we verify the result.
            Assert.NotNull(response);
            Assert.IsType<AddRiskResponse>(response);
            Assert.Equal(request.Risk.Description, response.Risk.Description);
            RiskServiceStub.clearDatabase();
        }

        [Fact]
        public async void GetRiskByCategory_ReturnAllTheRisksInsideACategory()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            insertFakesRisks();
            var request = new GetRiskByCategoryRequest() { RiskCategoryId = 1 };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _rService.GetRiskByCategory(request);

            // Assert --> in this section we verify the result.
            int expectedTotalOfRisks = 2;
            Assert.IsType<GetRiskByCategoryResponse>(response);
            Assert.NotNull(response);
            Assert.Equal(expectedTotalOfRisks, response.Risks.Count());
            RiskServiceStub.clearDatabase();

        }

        private void insertFakesRisks()
        {
            var risk1 = new Risk { Id = Guid.NewGuid(), Description = "Description risk 1..", RiskCategoryId = 2 };
            var risk2 = new Risk { Id = Guid.NewGuid(), Description = "Description risk 2.", RiskCategoryId = 1 };
            var risk3 = new Risk { Id = Guid.NewGuid(), Description = "Description risk 3..", RiskCategoryId = 1 };
            var risk4 = new Risk { Id = Guid.NewGuid(), Description = "Description risk 4..", RiskCategoryId = 3 };

            var list = new List<Risk> { risk1, risk2, risk3, risk4 };

            RiskServiceStub.AddRange(list);
        }
    }
}
