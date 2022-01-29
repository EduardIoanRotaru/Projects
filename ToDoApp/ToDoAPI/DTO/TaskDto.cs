namespace ToDoAPI.DTO
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateToComplete { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public Label Label {get;set;}
        public bool Completed { get; set; }
    }
}
