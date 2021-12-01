using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos.RiskCategory;
using Util.Support.Requests.RiskCategory;
using Util.Support.Responses.RiskCategory;
using Xunit;

namespace Testing.RiskCategoryTests
{
    public class RiskCategoryServiceTest
    {
        private readonly RiskCategoryServiceStub _rcService;

        public RiskCategoryServiceTest()
        {
            _rcService = new RiskCategoryServiceStub();
        }

        [Fact]
        public async void AddRiskCategory_withCorrectParameters_returnTheAddedRiskCategory()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            var dto = new AddRiskCategoryDto()
            {
                Title = "Risk Category 1",
                Description = "Description ...",
                DepartmentId = 1
            };
            var request = new AddRiskCategoryRequest() { RiskCategory = dto };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _rcService.Add(request);

            // Assert --> in this section we verify the result.
            int expectedId = 1;
            Assert.NotNull(response);
            Assert.IsType<AddRiskCategoryResponse>(response);
            Assert.Equal(expectedId, response.RiskCategory.Id);
            Assert.Equal(request.RiskCategory.Title, response.RiskCategory.Title);
            Assert.Equal(request.RiskCategory.Description, response.RiskCategory.Description);
            RiskCategoryServiceStub.clearDatabase();
        }

        [Fact]
        public async void GetRiskCategoryByDepartment_ReturnAllTheRiskCategoriesInsideADepartment()
        {
            // Arrange --> in this section you setup everything to be ready to executed the test
            insertFakesRc();
            var request = new GetRiskCategoriesByDepartmentRequest() { DepartmentId = 1 };

            // Act --> in this section we call the method(Perform the action) that we are testing.
            var response = await _rcService.GetRiskCategoriesByDepartment(request);

            // Assert --> in this section we verify the result.
            int expectedTotalOfRc = 3;
            Assert.IsType<GetRiskCategoriesByDepartmentResponse>(response);
            Assert.NotNull(response);
            Assert.Equal(expectedTotalOfRc, response.RiskCategories.Count());
            RiskCategoryServiceStub.clearDatabase();

        }

        private void insertFakesRc()
        {
            var rc1 = new RiskCategory { Id = 1, Title = "Risk Category 1", Description = "Description 1 ...", DepartmentId = 2 };
            var rc2 = new RiskCategory { Id = 2, Title = "Risk Category 2", Description = "Description 2 ...", DepartmentId = 1 };
            var rc3 = new RiskCategory { Id = 3, Title = "Risk Category 3", Description = "Description 3 ...", DepartmentId = 1 };
            var rc4 = new RiskCategory { Id = 4, Title = "Risk Category 4", Description = "Description 4 ...", DepartmentId = 1 };

            var list = new List<RiskCategory> { rc1, rc2, rc3, rc4 };

            RiskCategoryServiceStub.AddRange(list);
        }
    }
}
