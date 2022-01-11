using AutoMapper;
using Core.Entities;

namespace JobPortal_MVC.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Job, JobDto>();
        }
    }
}
