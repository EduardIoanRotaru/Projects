using AutoMapper;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class TaskRepository : GenericRepository<Core.Entities.Task>, 
                                  ITaskRepository<Core.Entities.Task>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TaskRepository(DataContext context, IMapper mapper) :base(context, mapper)
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Core.Entities.Task>> GetTaskByProjectIdAndPK(int projectId, int[] taskId)
        {
            var tasks = new List<Core.Entities.Task>();

            foreach(var item in taskId)
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(x => x.ProjectId == projectId && x.Id == item);
                tasks.Add(task);
            }

            return tasks;
        }

        public async Task<Core.Entities.Task> GetTasksWithComments(int id)
        {
           return await _context.Tasks
                            .Include(t => t.Comments)
                            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}