
namespace Shop.API.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal Total { get; set; }

        public ICollection<ProductDto> ProductsDto { get; set; }
    }
}
