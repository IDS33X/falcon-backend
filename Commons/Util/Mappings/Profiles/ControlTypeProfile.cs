using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos.ControlTypeDtos;

namespace Util.Mappings.Profiles
{
    public class ControlTypeProfile: Profile
    {
        public ControlTypeProfile()
        {
            CreateMap<MControlType, MControlTypeReadDto>().ReverseMap();
        }
    }
}
