using AutoMapper;
using Domain.Models;
using Util.Dtos.RiskCategory;

namespace Util.Mappings.Profiles
{
    public class RiskCategoryProfile : Profile
    {
        public RiskCategoryProfile()
        {
            CreateMap<RiskCategory, RiskCategoryDto>().ReverseMap();

            CreateMap<AddRiskCategoryDto, RiskCategory>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatedDate, opt => opt.Ignore())
                .ForMember(d => d.Enabled, opt => opt.Ignore())
                .ForMember(d => d.Department, opt => opt.Ignore())
                .ForMember(d => d.Risks, opt => opt.Ignore())
                .ForMember(d => d.Controls, opt => opt.Ignore());

            CreateMap<UpdateRiskCategoryDto, RiskCategory>()
                .ForMember(d => d.DepartmentId, opt => opt.Ignore())
                .ForMember(d => d.CreatedDate, opt => opt.Ignore())
                .ForMember(d => d.Enabled, opt => opt.Ignore())
                .ForMember(d => d.Department, opt => opt.Ignore())
                .ForMember(d => d.Risks, opt => opt.Ignore())
                .ForMember(d => d.Controls, opt => opt.Ignore());
        }
    }
}
