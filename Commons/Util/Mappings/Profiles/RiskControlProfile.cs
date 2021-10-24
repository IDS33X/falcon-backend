using AutoMapper;
using Domain.Models;
using Util.Dtos.RiskControl;

namespace Util.Mappings.Profiles
{
    public class RiskControlProfile : Profile
    {
        public RiskControlProfile()
        {
            CreateMap<RiskControl, RiskControlDto>().ReverseMap();

            CreateMap<AddRiskControlDto, RiskControl>()
                .ForMember(d => d.AssignDate, opt => opt.Ignore())
                .ForMember(d => d.Control, opt => opt.Ignore())
                .ForMember(d => d.DeallocatedDate, opt => opt.Ignore())
                .ForMember(d => d.Risk, opt => opt.Ignore());

            CreateMap<RemoveRiskControlDto, RiskControl>()
                .ForMember(d => d.AssignDate, opt => opt.Ignore())
                .ForMember(d => d.Control, opt => opt.Ignore())
                .ForMember(d => d.DeallocatedDate, opt => opt.Ignore())
                .ForMember(d => d.Risk, opt => opt.Ignore());

            CreateMap<RiskControl, RiskControlErrorDto>()
                .ForMember(dto => dto.ErrorMessage, opt => opt.Ignore());
        }
    }
}
