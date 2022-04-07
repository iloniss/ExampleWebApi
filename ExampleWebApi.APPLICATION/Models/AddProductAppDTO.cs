using System.ComponentModel.DataAnnotations;

namespace ExampleWebApi.APPLICATION.Models
{
    public class AddProductAppDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int? Number { get; set; }
        public int? Quantity { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
