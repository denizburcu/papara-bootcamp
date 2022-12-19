using AutoMapper;
using FakeUserProject.Data.Models;
using FakeUserProject.Service.Models;

namespace FakeUserProject.Service.Profiles
{
    public class UserProfile : Profile
    {
        //OwnerProfile class creates the mapping between our Owner domain object and OwnerDto.
        public  UserProfile()
        {
            CreateMap<User, UserDto>()
            .ForMember(dest => dest.Guid, opt => opt.MapFrom(src =>src.id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.userId))
            .ForMember(dest => dest.UserTitle, opt =>opt.MapFrom(src => src.title))
            .ForMember(dest => dest.UserBody, opt => opt.MapFrom(src => src.body))
            .ReverseMap();

        }

    }
}