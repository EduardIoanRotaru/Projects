using AutoMapper;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class UpcomingTasksRepository : IUpcomingTasksRepository<Core.Entities.Task>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UpcomingTasksRepository(DataContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IReadOnlyList<Core.Entities.Task>> GetAllOrderedByDate()
        {
            return await _context.Tasks
                            .OrderBy(t => t.DateToComplete)
                            .ToListAsync();
        }

        public async Task<IReadOnlyList<Core.Entities.Task>> GetAllOrderedByDateAndNotcompleted()
        {
            return await _context.Tasks.Where(t => t.Completed != true)
                                    .OrderBy(t => t.DateToComplete)
                                    .ToListAsync();
        }

        public async Task<IReadOnlyList<Core.Entities.Task>> GetAllOrderedByLabel()
        {
            return await _context.Tasks
                            .OrderBy(l => (int)l.Label)
                            .ToListAsync();
        }
    }
}