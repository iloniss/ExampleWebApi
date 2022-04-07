using System.ComponentModel.DataAnnotations;

namespace ExampleWebApi.APPLICATION.Models
{
    public class UpdateProductAppDTO
    {
        [Required]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
