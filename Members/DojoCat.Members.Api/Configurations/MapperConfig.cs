using AutoMapper;
using DojoCat.Members.Common.DataContracts;
using DojoCat.Members.Common.DataContracts.Requests;
using DojoCat.Members.Common.DataContracts.Responses;
using DojoCat.Members.Domain.Models;

namespace DojoCat.Members.Api.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {   
        CreateMap<MemberRequest, Member>();
        CreateMap<AddressDto, Address>().ReverseMap();
        CreateMap<ContactDetailsDto, ContactDetails>().ReverseMap();
        CreateMap<EmergencyContactDto, EmergencyContact>().ReverseMap();
        CreateMap<Member, Infrastructure.Models.Member>()
            .ForMember(dest => dest.Id, src => src.Ignore())
            .ForMember(dest => dest.UserReference, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToUniversalTime()))
            .ReverseMap();
        CreateMap<Member, MemberResponse>();
        CreateMap<Address, Infrastructure.Models.Address>();
        CreateMap<ContactDetails, Infrastructure.Models.ContactDetails>();
        CreateMap<EmergencyContact, Infrastructure.Models.EmergencyContact>();
        CreateMap<Infrastructure.Models.Member, MemberDetailsResponse>();
        CreateMap<Infrastructure.Models.ContactDetails, ContactDetailsDto>();
    }
}