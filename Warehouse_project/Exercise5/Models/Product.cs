namespace Exercise5.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }
    }
}
