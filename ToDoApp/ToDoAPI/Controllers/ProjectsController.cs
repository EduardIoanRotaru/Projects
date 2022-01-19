namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProjectsController(DataContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Task[]>> GetProjects()
        {
            var projects = await _context.Projects.ToListAsync();

            return Ok(projects);
        }
    }
}