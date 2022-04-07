using ExampleWebApi.CORE.Models;

namespace ExampleWebApi.CORE.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(Guid id);
        Task<Guid> AddProductAsync(AddProductDTO addProductDTO);
        Task<ProductDTO> UpdateProductAsync(UpdateProductDTO updateProductDTO);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
