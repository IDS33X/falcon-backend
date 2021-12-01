using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Service.Service;
using Util.Dtos.Risk;
using Util.Mappings;
using Util.Support.Requests.Risk;
using Util.Support.Responses.Risk;

namespace Testing.RiskTests
{
    public class RiskServiceStub : IRiskService
    {
        private static List<Risk> risks = new List<Risk>();
        private static Guid count;

        private readonly IMapper _mapper;

        public RiskServiceStub()
        {
            _mapper = new Mapper(AutoMapperConfiguration.GetConfig());
            risks.Clear();
        }

        public Task<AddRiskResponse> Add(AddRiskRequest request)
        {
            var risk = _mapper.Map<Risk>(request.Risk);
            count = Guid.NewGuid();
            risk.Id = count;

            risks.Add(risk);

            var dto = _mapper.Map<RiskDto>(risk);

            return Task.FromResult(new AddRiskResponse() { Risk = dto });
        }

        public Task<GetRiskByCategoryResponse> GetRiskByCategory(GetRiskByCategoryRequest request)
        {
            var dtos = new List<RiskDto>();

            foreach (var r in risks)
            {
                if (r.RiskCategoryId == request.RiskCategoryId)
                {
                    var dto = _mapper.Map<RiskDto>(r);
                    dtos.Add(dto);
                }
            }

            return Task.FromResult(new GetRiskByCategoryResponse() { Risks = dtos });
        }

        public Task<GetRiskByCategoryAndCodeResponse> GetRiskByCategoryAndCode(GetRiskByCategoryAndCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetRiskByCategoryAndDescriptionResponse> GetRiskByCategoryAndDescription(GetRiskByCategoryAndDescriptionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<EditRiskResponse> Update(EditRiskRequest request)
        {
            throw new NotImplementedException();
        }

        //Static Methods
        public static void clearDatabase()
        {
            risks.Clear();
        }

        public static void AddRange(List<Risk> fakesRisks)
        {
            risks.AddRange(fakesRisks);
        }
    }
}
