using AutoMapper;
using Domain.Models;
using Util.Dtos.RiskImpact;

namespace Util.Mappings.Profiles
{
    public class RiskImpactProfile : Profile
    {
        public RiskImpactProfile()
        {
            CreateMap<RiskImpact, RiskImpactDto>()
                     .ForMember(dto => dto.Title, opt => opt.MapFrom(domain => domain.ImpactType.Title))
                     .ForMember(dto => dto.Description, opt => opt.MapFrom(domain => domain.ImpactType.Description))
                     .ReverseMap();
        }
    }
}
