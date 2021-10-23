using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos.AutomationLevelDtos;

namespace Util.Mappings.Profiles
{
    public class AutomationLevelProfile: Profile
    {
        public AutomationLevelProfile()
        {
            CreateMap<MAutomationLevel, MAutomationLevelReadDto>().ReverseMap();
        }
    }
}
