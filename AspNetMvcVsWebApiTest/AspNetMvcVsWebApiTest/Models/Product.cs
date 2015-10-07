
namespace ProductsApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public class Json {
        public object Products1 { get; set; }
        public object Products2 { get; set; }
    }
}