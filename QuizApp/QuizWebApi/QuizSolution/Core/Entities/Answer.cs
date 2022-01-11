using System.Collections.Generic;

namespace Core.Entities
{
    public class Answer 
    {
        public int Id { get; set; }
        public Dictionary<string, bool> Answers {get;set;}
        public Question Question { get; set; }
    }
}