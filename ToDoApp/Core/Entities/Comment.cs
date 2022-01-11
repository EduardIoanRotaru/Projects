namespace Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public Task Task{ get; set; }
    }
}
