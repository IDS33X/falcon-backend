using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.Risk;
using Util.Support.Responses.Risk;

namespace Service.Service.ServiceImpl
{
    public class RiskService : IRiskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RiskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddRiskResponse> Add(AddRiskRequest request)
        {
            var risk = _mapper.Map<Risk>(request.Risk);

            risk = await _unitOfWork.Risks.Add(risk);

            await _unitOfWork.CompleteAsync();

            risk = await _unitOfWork.Risks.GetById(risk.Id);

            var riskDto = _mapper.Map<RiskDto>(risk);

            return new AddRiskResponse { Risk = riskDto };
        }

        public async Task<EditRiskResponse> Update(EditRiskRequest request)
        {
            var risk = _mapper.Map<Risk>(request.Risk);

            var riskUpdated = await _unitOfWork.Risks.Update(risk);

            await _unitOfWork.CompleteAsync();

            riskUpdated = await _unitOfWork.Risks.GetById(riskUpdated.Id);

            var riskUpdatedDto = _mapper.Map<RiskDto>(riskUpdated);

            return new EditRiskResponse { Risk = riskUpdatedDto };
        }

        public async Task<GetRiskByCategoryResponse> GetRiskByCategory(GetRiskByCategoryRequest request)
        {
            var risks = await _unitOfWork.Risks.GetRisksByCategory(request.Page, request.ItemsPerPage, request.RiskCategoryId);

            List<RiskDto> riskDtos = new List<RiskDto>();

            foreach (Risk risk in risks)
            {
                var riskDto = _mapper.Map<RiskDto>(risk);

                riskDtos.Add(riskDto);
            }

            int riskByCategoryCount = await _unitOfWork.Risks.GetRiskByCategoryCount(request.RiskCategoryId);
            int pages = Convert.ToInt32(Math.Ceiling((double)riskByCategoryCount / request.ItemsPerPage));

            GetRiskByCategoryResponse response = new GetRiskByCategoryResponse
            {
                AmountOfPages = pages,
                CurrentPage = riskDtos.Count > 0 ? request.Page : 0,
                Risks = riskDtos
            };

            return response;
        }
        public async Task<GetRiskByCategoryAndCodeResponse> GetRiskByCategoryAndCode(GetRiskByCategoryAndCodeRequest request)
        {
            var risks = await _unitOfWork.Risks.GetRiskByCategoryAndCode(request.Filter, request.Page, request.ItemsPerPage, request.RiskCategoryId);

            List<RiskDto> riskDtos = new List<RiskDto>();

            foreach (Risk risk in risks)
            {
                var riskDto = _mapper.Map<RiskDto>(risk);

                riskDtos.Add(riskDto);
            }

            int riskByCategoryAndCodeCount = await _unitOfWork.Risks.GetRiskByCategoryAndCodeCount(request.Filter, request.RiskCategoryId);
            int pages = Convert.ToInt32(Math.Ceiling((double)riskByCategoryAndCodeCount / request.ItemsPerPage));

            GetRiskByCategoryAndCodeResponse response = new GetRiskByCategoryAndCodeResponse
            {
                AmountOfPages = pages,
                CurrentPage = riskDtos.Count > 0 ? request.Page : 0,
                Risks = riskDtos
            };

            return response;
        }
        
        public async Task<GetRiskByCategoryAndDescriptionResponse> GetRiskByCategoryAndDescription(GetRiskByCategoryAndDescriptionRequest request)
        {
            var risks = await _unitOfWork.Risks.GetRiskByCategoryAndDescription(request.Filter, request.Page, request.ItemsPerPage, request.RiskCategoryId);

            List<RiskDto> riskDtos = new List<RiskDto>();

            foreach (Risk risk in risks)
            {
                var riskDto = _mapper.Map<RiskDto>(risk);

                riskDtos.Add(riskDto);
            }

            int riskByCategoryAndDescriptionCount = await _unitOfWork.Risks.GetRiskByCategoryAndDescriptionCount(request.Filter, request.RiskCategoryId);
            int pages = Convert.ToInt32(Math.Ceiling((double)riskByCategoryAndDescriptionCount / request.ItemsPerPage));

            GetRiskByCategoryAndDescriptionResponse response = new GetRiskByCategoryAndDescriptionResponse
            {
                AmountOfPages = pages,
                CurrentPage = riskDtos.Count > 0 ? request.Page : 0,
                Risks = riskDtos
            };

            return response;
        }
    }
}
