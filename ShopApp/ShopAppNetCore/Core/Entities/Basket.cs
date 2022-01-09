namespace Core.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public decimal Total { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
