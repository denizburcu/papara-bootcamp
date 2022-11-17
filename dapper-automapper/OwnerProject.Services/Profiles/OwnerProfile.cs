using AutoMapper;
using OwnerProject.Domain.Models;
using OwnerProject.Services.Contract;

namespace OwnerProject.Services.Profiles
{
    public class OwnerProfile : Profile
    {
        //OwnerProfile class creates the mapping between our Owner domain object and OwnerDto.
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerDto>()
            .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Surname))
            .ForMember(dest => dest.OwnerType, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ReverseMap();
        }
    }
}