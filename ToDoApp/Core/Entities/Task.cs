namespace Core.Entities
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateToComplete { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Project Project { get; set; }
        public int? ProjectId { get; set; }
        public Label Label {get;set;}
        public bool Completed { get; set; }
    }
}
