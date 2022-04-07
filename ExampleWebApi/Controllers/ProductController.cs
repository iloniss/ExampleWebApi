using ExampleWebApi.APPLICATION.Models;
using ExampleWebApi.APPLICATION.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApi.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductAppDTO>>> GetAllProducts()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductAppDTO>> GetProductById(Guid id)
        {
            return Ok(await _productService.GetProductByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddProduct(AddProductAppDTO addProductAppDTO)
        {
            var result = await _productService.AddProductAsync(addProductAppDTO);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (result)
                return StatusCode(StatusCodes.Status200OK);
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<ProductAppDTO>> UpdateProduct(UpdateProductAppDTO updateProductAppDTO)
        {
            var updateProduct = await _productService.UpdateProductAsync(updateProductAppDTO);
            if (updateProduct is null)
                return NotFound();
            return Ok(updateProduct);
        }
    }
}
