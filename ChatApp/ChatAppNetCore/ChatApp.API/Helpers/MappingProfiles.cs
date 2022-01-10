using AutoMapper;
using ChatApp.API.DTO;
using Core.Entities;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Message, MessageDto>();
    }
}