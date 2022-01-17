using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateToComplete { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public Label Label {get;set;}
    }
}
