using Core.Entities;
using Core.Interfaces.Repository;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthRepository AuthRepository {get;}
        IProjectRepository<Project> ProjectRepository {get;}
        ITaskRepository<Core.Entities.Task> TaskRepository {get;}
        ICommentRepository CommentRepository {get;}
        IUpcomingTasksRepository<Core.Entities.Task> UpcomingTasksRepository {get;}
        Task<bool> Complete();  
        bool HasChanges();
    }
}