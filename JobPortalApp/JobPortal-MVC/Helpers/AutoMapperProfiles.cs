using AutoMapper;
using Core.Entities;
using JobPortal_MVC.DTO;

namespace JobPortal_MVC.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<JobDto, JobDto>();
        }
    }
}
