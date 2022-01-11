namespace Core.Entities
{
    public class Size : BaseEntity
    {   
        public ICollection<Product> Product { get; set; }
    }
}
