using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class ProjectRepository : GenericRepository<Project>, 
                                     IProjectRepository<Project>
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ProjectRepository(DataContext context, IMapper mapper) 
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Project> GetProjectWithTasks(int id) 
        {
            return await _context.Projects
                            .Include(t => t.Tasks)
                            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}