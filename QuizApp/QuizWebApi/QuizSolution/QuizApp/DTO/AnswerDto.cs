using System.Collections.Generic;

namespace QuizApp.DTO
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public Dictionary<string, bool> Answers {get;set;}
        public QuestionDto Question { get; set; }
    }
}