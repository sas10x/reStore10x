using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandsController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductBrand>>> GetBrands() 
        {
            var brands = await _brandRepository.GetBrandsAsync();

            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBrand>> GetBrand(int id) 
        {
            var brand = await _brandRepository.GetBrandByIdAsync(id);

            return Ok(brand);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ProductBrand>> AddBrand(ProductBrand productToAdd) 
        {
            var brand = await _brandRepository.AddBrandAsync(productToAdd);

            return Ok(brand);
        }
    }
}