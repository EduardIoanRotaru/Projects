using System.Collections.Generic;

namespace Shop.API.DTO
{
    public class BasketDto
    {
        public int Id { get; set; }
        public decimal Total { get; set; }

        public ICollection<ProductDto> Products { get; set; }
    }
}
