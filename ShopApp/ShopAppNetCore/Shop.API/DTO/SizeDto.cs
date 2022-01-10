namespace Shop.API.DTO
{
    public class SizeDto 
    {
        public int Id { get; set; }
        public decimal Total { get; set; }

        public ICollection<ProductDto> ProductsDto { get; set; }
    }
}
