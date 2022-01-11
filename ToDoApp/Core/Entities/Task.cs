namespace Core.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
