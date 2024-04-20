using System.Security.Cryptography;
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
        CreateMap<MemberRequest, Member>()
            .ForMember(m => m.EmergencyContact, mr => mr.MapFrom(e => e.EmergencyContact));
        CreateMap<AddressDto, Address>().ReverseMap();
        CreateMap<ContactDetailsDto, ContactDetails>().ReverseMap();
        CreateMap<EmergencyContactDto, EmergencyContact>().ReverseMap();
        CreateMap<Member, Infrastructure.Models.Member>()
            ///.ForMember(dest => dest.Id, src => src.Ignore())
            //.ForMember(dest => dest.UserReference, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToUniversalTime()))
            .ForMember(m => m.EmergencyContact, mr => mr.MapFrom(e => e.EmergencyContact))
            .ReverseMap();
        CreateMap<Member, MemberResponse>();
        CreateMap<Address, Infrastructure.Models.Address>().ReverseMap();
        CreateMap<ContactDetails, Infrastructure.Models.ContactDetails>().ReverseMap();
        CreateMap<EmergencyContact, Infrastructure.Models.EmergencyContact>().ReverseMap();
        CreateMap<Infrastructure.Models.Member, MemberDetailsResponse>()
            .ForMember(mdr => mdr.EmergencyContacts, m => m.MapFrom(ec => ec.EmergencyContact));
        CreateMap<Infrastructure.Models.ContactDetails, ContactDetailsDto>();
        CreateMap<Infrastructure.Models.Address, AddressDto>();
        CreateMap<Infrastructure.Models.EmergencyContact, EmergencyContactDto>();

        CreateMap<NewParentRequest, Parent>();
        CreateMap<ChildClaim, Member>();
        CreateMap<Parent, Infrastructure.Models.Parent>()
            //.ForMember(dest => dest.Id, src => src.Ignore())
            //.ForMember(dest => dest.ParentReference, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();
        CreateMap<Parent, NewParentResponse>();
    }    
}