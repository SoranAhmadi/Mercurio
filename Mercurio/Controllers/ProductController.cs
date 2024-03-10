using Application.DTOs.Product;
using Application.IServices;

using FluentValidation;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<IEnumerable<ProductSearchViewDTO>>> SearchProductTerm(ProductSearchDTO? filter)
        {
            var result = await _productRepository.SearchProductTerm(filter);

            if (result == null || !result.Any())
                return NotFound();
            return Ok(result);
        }

        
        [HttpPost]
        public async Task<ProductUpdateDTO> GetById(ProductDeleteDTO filter) => await _productRepository.GetById(filter.Id);

        [Authorize]
        [HttpPost]
        [RequestSizeLimit(500_000)]
        public async Task<IActionResult> Create(ProductCreateDTO productCreateDTO)
        {
            if (ModelState.IsValid)
            {
                
                   var result =  await _productRepository.Create(productCreateDTO);
              return Ok(result);
            }
            return BadRequest(ModelState);
        }
        [Authorize]
        [HttpPut]
        [RequestSizeLimit(500_000)]
        public async Task <IActionResult>  Update(ProductUpdateDTO productUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.Update(productUpdateDTO);
                return Ok();
            }
            else
                return BadRequest(ModelState);
            
        }
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(int id) => await _productRepository.Delete(new ProductDeleteDTO() { Id=id});

        [HttpPost]
        public IActionResult Test()
        {
            return Ok(true);
        }

    }
}
