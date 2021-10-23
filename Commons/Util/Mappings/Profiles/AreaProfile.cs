using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util.Dtos.AreaDtos;

namespace Util.Mappings.Profiles
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<Area, AreaReadDto>().ForMember(dto => dto.CountDivisions, opt => opt.Ignore()).ReverseMap();
            CreateMap<AreaCreateDto, Area>();
            CreateMap<AreaUpdateDto, Area>();
        }

    }
}
