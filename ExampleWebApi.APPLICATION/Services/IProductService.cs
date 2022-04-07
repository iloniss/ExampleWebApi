using ExampleWebApi.APPLICATION.Models;

namespace ExampleWebApi.APPLICATION.Services
{
    public interface IProductService
    {
        Task<List<ProductAppDTO>> GetAllProductsAsync();
        Task<ProductAppDTO> GetProductByIdAsync(Guid id);
        Task<Guid> AddProductAsync(AddProductAppDTO addProductAppDTO);
        Task<ProductAppDTO> UpdateProductAsync(UpdateProductAppDTO updateProductAppDTO);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
