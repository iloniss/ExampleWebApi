using ExampleWebApi.APPLICATION.Models;
using ExampleWebApi.CORE.Models;
using ExampleWebApi.CORE.Repository;
using Mapster;

namespace ExampleWebApi.APPLICATION.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Guid> AddProductAsync(AddProductAppDTO addProductAppDTO)
        {
            return await _productRepository.AddProductAsync(addProductAppDTO.Adapt<AddProductDTO>());
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }

        public async Task<List<ProductAppDTO>> GetAllProductsAsync()
        {
            return (await _productRepository.GetAllProductsAsync()).Adapt<List<ProductAppDTO>>();
        }

        public async Task<ProductAppDTO> GetProductByIdAsync(Guid id)
        {
            return (await _productRepository.GetProductByIdAsync(id)).Adapt<ProductAppDTO>();
        }

        public async Task<ProductAppDTO> UpdateProductAsync(UpdateProductAppDTO updateProductAppDTO)
        {
            return (await _productRepository.UpdateProductAsync(updateProductAppDTO.Adapt<UpdateProductDTO>())).Adapt<ProductAppDTO>();
        }
    }
}
