using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos.ControlStateDtos;

namespace Util.Mappings.Profiles
{
    public class ControlStateProfile :Profile
    {
        public ControlStateProfile()
        {
            CreateMap<MControlState, MControlStateReadDto>().ReverseMap();
        }
    }
}
