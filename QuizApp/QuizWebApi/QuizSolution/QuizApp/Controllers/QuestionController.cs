using Infrastructure.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace QuizApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuestionController : ApiController
    {
        private DataContext _context = new DataContext(); 

        public QuestionController()
        {
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetQuestions()
        {
            var questions = await _context.Questions.ToListAsync();

            return Ok(questions);
        }
    }
}