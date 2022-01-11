namespace Core.Entities
{
    public class Order 
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public int ProductId {get;set;}
        public ICollection<Product> Products { get; set; }
    }
}
