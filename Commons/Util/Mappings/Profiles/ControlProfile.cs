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
                   .ReverseMap();

            CreateMap<ControlCreateDto, Control>();
            CreateMap<ControlUpdateDto, Control>();

        }
    }
}
