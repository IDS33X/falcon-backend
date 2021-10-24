using AutoMapper;
using Domain.Models;
using Util.Dtos.User;

namespace Util.Mappings.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserProfile, UserDto>()
                .ForMember(dto => dto.Username, opt => opt.MapFrom(des => des.User.Username))
                .ForMember(dto => dto.Id, opt => opt.MapFrom(des => des.Id))
                .ForMember(dto => dto.RoleId, opt => opt.MapFrom(domain => domain.User.UserRoleId))
                .ForMember(dto => dto.Role, opt => opt.MapFrom(domain => domain.User.UserRole))
                .ReverseMap();

            CreateMap<AddUserDto, UserProfile>()
                .ForMember(d => d.User, opt => opt.MapFrom(dto => new User { Password = dto.Password, UserRoleId = dto.RoleId ?? 0, Username = dto.Username}))
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Department, opt => opt.Ignore())
                .ForMember(d => d.UserId, opt => opt.Ignore())
                .ForMember(d => d.Division, opt => opt.Ignore())
                .ForMember(d => d.Risks, opt => opt.Ignore())
                .ForMember(d => d.Controls, opt => opt.Ignore());

            CreateMap<UpdateUserProfileDto, UserProfile>()
                .ForMember(d => d.Code, opt => opt.Ignore())
                .ForMember(d => d.Department, opt => opt.Ignore())
                .ForMember(d => d.UserId, opt => opt.Ignore())
                .ForMember(d => d.User, opt => opt.Ignore())
                .ForMember(d => d.Division, opt => opt.Ignore())
                .ForMember(d => d.Risks, opt => opt.Ignore())
                .ForMember(d => d.Controls, opt => opt.Ignore());
        }
    }
}
