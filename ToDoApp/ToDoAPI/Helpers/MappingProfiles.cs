using AutoMapper;
using Core.Entities;
using ToDoAPI.DTO;

namespace ToDoAPI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TaskDto, Core.Entities.Task>();
            CreateMap<Core.Entities.Task, TaskDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>()
                .ForMember(c => c.CommentText, o => o.MapFrom(x => x.CommentText))
                .ForMember(c => c.TaskId, o => o.MapFrom(x => x.TaskId));
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();
        }
    }
}