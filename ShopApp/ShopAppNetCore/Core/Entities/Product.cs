namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Image Image { get; set; }
        public int CategoryId {get;set;}
        public Category Category{get;set;}
        public ICollection<Size> Sizes{ get; set; }
    }
}