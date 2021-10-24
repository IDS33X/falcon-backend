using AutoMapper;
using Domain.Models;
using Util.Dtos.UserControl;

namespace Util.Mappings.Profiles
{
    public class UserControlProfile : Profile
    {
        public UserControlProfile()
        {
            CreateMap<UserControl, UserControlDto>().ReverseMap();

            CreateMap<AddUserControlDto, UserControl>()
                .ForMember(d => d.AssignDate, opt => opt.Ignore())
                .ForMember(d => d.Control, opt => opt.Ignore())
                .ForMember(d => d.DeallocatedDate, opt => opt.Ignore())
                .ForMember(d => d.User, opt => opt.Ignore());

            CreateMap<RemoveUserControlDto, UserControl>()
                .ForMember(d => d.AssignDate, opt => opt.Ignore())
                .ForMember(d => d.Control, opt => opt.Ignore())
                .ForMember(d => d.DeallocatedDate, opt => opt.Ignore())
                .ForMember(d => d.User, opt => opt.Ignore());

            CreateMap<UserControl, UserControlErrorDto>()
                .ForMember(dto => dto.ErrorMessage, opt => opt.Ignore());
        }
    }
}
