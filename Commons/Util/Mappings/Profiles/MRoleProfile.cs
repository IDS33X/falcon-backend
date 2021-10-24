using AutoMapper;
using Domain.Models;
using Util.Dtos.MRole;

namespace Util.Mappings.Profiles
{
    public class MRoleProfile : Profile
    {
        public MRoleProfile()
        {
            CreateMap<MRole, MRoleDto>().ReverseMap();
        }
    }
}
