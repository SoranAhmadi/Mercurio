using Application.DTOs.Product;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Mercurio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productRepository;
        public ProductController(IProductService productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IEnumerable<ProductDTO>> GetAll(ProductFilterDTO? filter) => await _productRepository.GetAll(filter);

        [HttpPost]
        public async Task< ActionResult<IEnumerable<ProductSearchViewDTO>>>SearchProductTerm(ProductSearchDTO? filter)
        {
            var result =  await _productRepository.SearchProductTerm(filter);

            if(result  == null || !result.Any())
                return NotFound();
            return Ok(result);
        } 


        [HttpPost]
        public async Task<ProductUpdateDTO> GetById(ProductDeleteDTO filter) => await _productRepository.GetById(filter.Id);


        [HttpPost]
        public async Task<int> Create(ProductCreateDTO productCreateDTO) => await _productRepository.Create(productCreateDTO);

        [HttpPut]
        public async Task Update(ProductUpdateDTO productUpdateDTO) => await _productRepository.Update(productUpdateDTO);

        [HttpDelete]
        public async Task Delete(ProductDeleteDTO productDeleteDTO) => await _productRepository.Delete(productDeleteDTO);

        [HttpPost]
        public IActionResult Test() 
        {
            return Ok(true);
        }

    }
}
