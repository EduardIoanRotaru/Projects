using System.Collections.Generic;

namespace QuizApp.Entities
{
    public class Answer 
    {
        public int Id { get; set; }

        public bool IsCorrectAnswer {get;set;}

        public Question Question { get; set; }
    }
}