using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypesController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public TypesController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() 
        {
            var products = await _productRepository. GetProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) 
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            return Ok(product);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Product>> AddProduct(Product productToAdd) 
        {
            var product = await _productRepository.AddProductsAsync(productToAdd);

            return Ok(product);
        }
    }
}