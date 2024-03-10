using AutoMapper;
using DojoCat.Members.Common.DataContracts.Requests;
using DojoCat.Members.Domain.Models;

namespace DojoCat.Members.Api.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {   
        CreateMap<MemberRequest, Member>();
           
    }
}
