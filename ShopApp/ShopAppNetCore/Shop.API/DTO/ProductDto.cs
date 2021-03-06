namespace Shop.API.DTO
{
    public class ProductDto : BaseEntityDto
    {
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public ImageDto ImageDto { get; set; }
    }
}
