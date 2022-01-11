using QuizApp.DAL;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuizWebApi.Controllers
{
    public class QuizController : ApiController
    {
        private readonly DataContext _dataContext = new DataContext();

        public QuizController()
        {
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetQuestions()
        {
            var questions = await _dataContext.Questions.ToListAsync();

            return Ok(questions);
        }
    }
}