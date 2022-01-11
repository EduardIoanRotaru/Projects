namespace Core.Entities
{
    public class Order 
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
<<<<<<< HEAD
        public int ProductId {get;set;}
=======

>>>>>>> ToDoApp
        public ICollection<Product> Products { get; set; }
    }
}
