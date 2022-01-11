
using System;
using System.Collections.Generic;

namespace QuizApp.DTO
{
    public class QuestionDto : BaseEntityDto
    {
        public DateTime DateCreated { get; set; }
        public ICollection<AnswerDto> Answers { get; set; }
    }
}

// We serve a question with e.g: 4 Answers
// User checks one answer and sends the AnswerId to the server with QuestionId
// We check if Question Entity has that Answer and return boolean; IsCorrectAnswer

// When we create a Question, we also create 4 Answers and user checks one correct Answer 
// When we serve the Question we are ommiting the Answer in the Dto
