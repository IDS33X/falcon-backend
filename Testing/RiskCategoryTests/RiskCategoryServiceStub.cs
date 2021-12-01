using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Service.Service;
using Util.Dtos.RiskCategory;
using Util.Mappings;
using Util.Support.Requests.RiskCategory;
using Util.Support.Responses.RiskCategory;

namespace Testing.RiskCategoryTests
{
    public class RiskCategoryServiceStub : IRiskCategoryService
    {

        private static List<RiskCategory> riskCategories = new List<RiskCategory>();
        private static int count = 0;

        private readonly IMapper _mapper;

        public RiskCategoryServiceStub()
        {
            _mapper = new Mapper(AutoMapperConfiguration.GetConfig());
            riskCategories.Clear();
        }

        public Task<AddRiskCategoryResponse> Add(AddRiskCategoryRequest request)
        {
            count++;
            var riskCategory = _mapper.Map<RiskCategory>(request.RiskCategory);
            riskCategory.Id = count;

            riskCategories.Add(riskCategory);

            var riskCategoryDto = _mapper.Map<RiskCategoryDto>(riskCategory);

            return Task.FromResult(new AddRiskCategoryResponse() { RiskCategory = riskCategoryDto });
        }

        public Task<GetRiskCategoriesByDepartmentResponse> GetRiskCategoriesByDepartment(GetRiskCategoriesByDepartmentRequest request)
        {
            var dtos = new List<RiskCategoryDto>();

            foreach (var rc in riskCategories)
            {
                if (rc.DepartmentId == request.DepartmentId)
                {
                    var dto = _mapper.Map<RiskCategoryDto>(rc);
                    dtos.Add(dto);
                }
            }

            return Task.FromResult(new GetRiskCategoriesByDepartmentResponse() { RiskCategories = dtos});
        }

        public Task<GetRiskCategoriesByDepartmentSearchResponse> GetDepartmentsByDivisionAndSearch(GetRiskCategoriesByDepartmentSearchRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<EditRiskCategoryResponse> Update(EditRiskCategoryRequest request)
        {
            throw new NotImplementedException();
        }

        //Static Methods
        public static void clearDatabase()
        {
            riskCategories.Clear();
            count = 0;
        }

        public static void AddRange(List<RiskCategory> fakesRiskCategories)
        {
            riskCategories.AddRange(fakesRiskCategories);
        }
    }
}
