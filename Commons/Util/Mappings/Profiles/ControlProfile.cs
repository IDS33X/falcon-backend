using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos.ControlDtos;

namespace Util.Mappings.Profiles
{
    public class ControlProfile : Profile
    {
        public ControlProfile()
        {
            CreateMap<Control, ControlReadDto>().ForMember(dto => dto.AutomationLevel, opt => opt.MapFrom(ent => ent.AutomationLevel.Title))
                   .ForMember(dto => dto.ControlState, opt => opt.MapFrom(ent => ent.ControlState.Title))
                   .ForMember(dto => dto.ControlType, opt => opt.MapFrom(ent => ent.ControlType.Title))
                   .ForMember(dto => dto.RiskCategory, opt => opt.MapFrom(ent => ent.RiskCategory.Title))
                   .ReverseMap();

            CreateMap<ControlCreateDto, Control>().ForMember(c => c.Id, opt => opt.Ignore())
                                                  .ForMember(c => c.CreationDate, opt => opt.Ignore())
                                                  .ForMember(c => c.LastUpdateDate, opt => opt.Ignore())
                                                  .ForMember(c => c.RiskCategory, opt => opt.Ignore())
                                                  .ForMember(c => c.AutomationLevel, opt => opt.Ignore())
                                                  .ForMember(c => c.ControlState, opt => opt.Ignore())
                                                  .ForMember(c => c.ControlType, opt => opt.Ignore())
                                                  .ForMember(c => c.User, opt => opt.Ignore())
                                                  .ForMember(c => c.Users, opt => opt.Ignore())
                                                  .ForMember(c => c.Risks, opt => opt.Ignore());

            CreateMap<ControlUpdateDto, Control>().ForMember(c => c.CreationDate, opt => opt.Ignore())
                                                  .ForMember(c => c.LastUpdateDate, opt => opt.Ignore())
                                                  .ForMember(c => c.RiskCategoryId, opt => opt.Ignore())
                                                  .ForMember(c => c.RiskCategory, opt => opt.Ignore())
                                                  .ForMember(c => c.AutomationLevel, opt => opt.Ignore())
                                                  .ForMember(c => c.ControlState, opt => opt.Ignore())
                                                  .ForMember(c => c.ControlType, opt => opt.Ignore())
                                                  .ForMember(c => c.User, opt => opt.Ignore())
                                                  .ForMember(c => c.Users, opt => opt.Ignore())
                                                  .ForMember(c => c.Risks, opt => opt.Ignore());

        }
    }
}
