
namespace ExampleWebApi.APPLICATION.Models
{
    public class ProductAppDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
