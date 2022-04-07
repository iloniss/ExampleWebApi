
namespace ExampleWebApi.CORE.Models
{
    public class UpdateProductDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
