using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() 
        {
            var products = await _productRepository.GetProductsAsync();

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReturnDto>> GetProduct(int id) 
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            return Ok(new ProductReturnDto {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                ProductType = product.ProductType.Name,
                ProductBrand = product.ProductBrand.Name,
            });
        }

        [HttpPost("add")]
        public async Task<ActionResult<Product>> AddProduct(Product productToAdd) 
        {
            var product = await _productRepository.AddProductsAsync(productToAdd);

            return Ok(product);
        }
    }
}