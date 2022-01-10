namespace ToDoAPI.DTO
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }

        public ICollection<CommentDto> Comments { get; set; }
    }
}
