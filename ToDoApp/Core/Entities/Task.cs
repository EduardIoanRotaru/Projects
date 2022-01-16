namespace Core.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateToComplete { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Label Label {get;set;}
    }
}
