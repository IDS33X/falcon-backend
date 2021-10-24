using AutoMapper;
using Domain.Models;
using Util.Dtos.Risk;

namespace Util.Mappings.Profiles
{
    public class RiskProfile : Profile
    {
        public RiskProfile()
        {
            CreateMap<Risk, RiskDto>().ReverseMap();

            CreateMap<AddRiskDto, Risk>()
                .ForMember(d => d.ControlledRisk, opt => opt.Ignore())
                .ForMember(d => d.Controls, opt => opt.Ignore())
                .ForMember(d => d.CreationDate, opt => opt.Ignore())
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.InherentRisk, opt => opt.Ignore())
                .ForMember(d => d.RiskCategory, opt => opt.Ignore())
                .ForMember(d => d.User, opt => opt.Ignore());

            CreateMap<UpdateRiskDto, Risk>()
                .ForMember(d => d.ControlledRisk, opt => opt.Ignore())
                .ForMember(d => d.RiskCategoryId, opt => opt.Ignore())
                .ForMember(d => d.Controls, opt => opt.Ignore())
                .ForMember(d => d.CreationDate, opt => opt.Ignore())
                .ForMember(d => d.Code, opt => opt.Ignore())
                .ForMember(d => d.InherentRisk, opt => opt.Ignore())
                .ForMember(d => d.RiskCategory, opt => opt.Ignore())
                .ForMember(d => d.User, opt => opt.Ignore())
                .ForMember(d => d.UserId, opt => opt.Ignore());
        }
    }
}
