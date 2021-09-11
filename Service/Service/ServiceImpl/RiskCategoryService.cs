using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.RiskCategory;
using Util.Support.Responses.RiskCategory;

namespace Service.Service.ServiceImpl
{
    public class RiskCategoryService : IRiskCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public RiskCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddRiskCategoryResponse> Add(AddRiskCategoryRequest request)
        {
            var riskCategory = _mapper.Map<RiskCategory>(request.RiskCategory);

            riskCategory = await _unitOfWork.RiskCategories.Add(riskCategory);

            await _unitOfWork.CompleteAsync();

            var riskCategoryDto = _mapper.Map<RiskCategoryDto>(riskCategory);

            return new AddRiskCategoryResponse { RiskCategory = riskCategoryDto};
        }

        public async Task<EditRiskCategoryResponse> Update(EditRiskCategoryRequest request)
        {
            var riskCategory = _mapper.Map<RiskCategory>(request.RiskCategory);

            var riskCategoryUpdated = await _unitOfWork.RiskCategories.Update(riskCategory);
            var riskCategoryDto = _mapper.Map<RiskCategoryDto>(riskCategoryUpdated);
            await _unitOfWork.CompleteAsync();

            return new EditRiskCategoryResponse { RiskCategory = riskCategoryDto };
        }

        public async Task<GetRiskCategoriesByDepartmentResponse> GetRiskCategoriesByDepartment(GetRiskCategoriesByDepartmentRequest request)
        {
            var riskCategories = await _unitOfWork.RiskCategories.GetRiskCategoriesByDepartment(request.DepartmentId, request.Page, request.ItemsPerPage);

            List<RiskCategoryDto> riskCategoryDtos = new List<RiskCategoryDto>();

            foreach (RiskCategory riskCategory in riskCategories)
            {
                var riskCategoryDto = _mapper.Map<RiskCategoryDto>(riskCategory);

                riskCategoryDtos.Add(riskCategoryDto);
            }
            
            int riskCategoriesCountByDepartment = await _unitOfWork.RiskCategories.GetRiskCategoriesCountByDepartment(request.DepartmentId);
            int pages = Convert.ToInt32(Math.Ceiling((double)riskCategoriesCountByDepartment / request.ItemsPerPage));

            GetRiskCategoriesByDepartmentResponse response = new GetRiskCategoriesByDepartmentResponse
            {
                AmountOfPages = pages,
                CurrentPage = riskCategoryDtos.Count > 0 ? request.Page : 0,
                RiskCategories = riskCategoryDtos
            };

            return response;
        }
        public async Task<GetRiskCategoriesByDepartmentSearchResponse> GetDepartmentsByDivisionAndSearch(GetRiskCategoriesByDepartmentSearchRequest request)
        {
            var riskCategories = await _unitOfWork.RiskCategories.GetRiskCategoriesByDepartmentSearch(request.DepartmentId, request.Filter, request.Page, request.ItemsPerPage);

            List<RiskCategoryDto> riskCategoryDtos = new List<RiskCategoryDto>();

            foreach (RiskCategory riskCategory in riskCategories)
            {
                var riskCategoryDto = _mapper.Map<RiskCategoryDto>(riskCategory);

                riskCategoryDtos.Add(riskCategoryDto);
            }

            int riskCategoriesCountByDepartmentSearch = await _unitOfWork.RiskCategories.GetRiskCategoriesCountByDepartmentSearch(request.DepartmentId, request.Filter);
            int pages = Convert.ToInt32(Math.Ceiling((double)riskCategoriesCountByDepartmentSearch / request.ItemsPerPage));

            GetRiskCategoriesByDepartmentSearchResponse response = new GetRiskCategoriesByDepartmentSearchResponse
            {
                AmountOfPages = pages,
                CurrentPage = riskCategoryDtos.Count > 0 ? request.Page : 0,
                RiskCategories = riskCategoryDtos
            };

            return response;
        }
    }
}
