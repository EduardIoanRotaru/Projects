using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly DataContext _context;

        public TaskController(DataContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Task[]>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();

            return Ok(tasks);
        }
    }
}