using AutoMapper;
using ExampleWebApi.CORE.Models;
using ExampleWebApi.CORE.Repository;
using ExampleWebApi.INFRASTRUCTURE.Data;
using ExampleWebApi.INFRASTRUCTURE.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApi.INFRASTRUCTURE.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsContext _productsContext;
        private readonly IMapper _mapper;
        public ProductRepository(ProductsContext productsContext, IMapper mapper)
        {
            _productsContext = productsContext;
            _mapper = mapper;
        }
        public async Task<Guid> AddProductAsync(AddProductDTO addProductDTO)
        {
            using var tran = _productsContext.Database.BeginTransaction();
            try
            {
                var product = _mapper.Map<Products>(addProductDTO);
                await _productsContext.Products.AddAsync(product);
                await _productsContext.SaveChangesAsync();
                await tran.CommitAsync();

                return product.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var result = await _productsContext.Products
                .Where(p => p.Id == id)
                .SingleOrDefaultAsync();

            if (result == null)
                return false;

            using var tran = _productsContext.Database.BeginTransaction();
            try
            {
                _productsContext.Products.Remove(result);
                await _productsContext.SaveChangesAsync();
                await tran.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            return _mapper.Map<List<ProductDTO>>(await _productsContext.Products
                .ToListAsync());
        }

        public async Task<ProductDTO> GetProductByIdAsync(Guid id)
        {
            return _mapper.Map<ProductDTO>(await _productsContext.Products
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync());
        }

        public async Task<ProductDTO> UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            var product = await _productsContext.Products
                .Where(x => x.Id == updateProductDTO.Id)
                .SingleOrDefaultAsync();

            if (product == null)
                return null;

            using var tran = _productsContext.Database.BeginTransaction();
            try
            {
                product.Description = updateProductDTO.Description;
                product.Quantity = updateProductDTO.Quantity;
                await _productsContext.SaveChangesAsync();
                await tran.CommitAsync();

                return _mapper.Map<ProductDTO>(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
