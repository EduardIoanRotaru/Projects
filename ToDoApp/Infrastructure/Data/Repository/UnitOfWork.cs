using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repository;

namespace Infrastructure.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IAuthRepository AuthRepository => new AuthRepository(_context);

        public IProjectRepository<Project> ProjectRepository => new ProjectRepository(_context, _mapper);

        public ITaskRepository<Core.Entities.Task> TaskRepository => new TaskRepository(_context, _mapper);
        public ICommentRepository CommentRepository => new CommentsRepository(_context, _mapper);

        public IUpcomingTasksRepository<Core.Entities.Task> UpcomingTasksRepository => new UpcomingTasksRepository(_context, _mapper);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool HasChanges()
        {
            _context.ChangeTracker.DetectChanges();
            var changes = _context.ChangeTracker.HasChanges();

            return changes;
        }
    }
}