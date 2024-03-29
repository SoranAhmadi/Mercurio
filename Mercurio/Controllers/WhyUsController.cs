using Application.DTOs.Category;
using Application.DTOs.ContactComment;
using Application.DTOs.WhyUses;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mercurio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WhyUsController : ControllerBase
    {
        private readonly IWhyUsService _whyUsService;
        public WhyUsController(IWhyUsService whyUsService)
        {
            _whyUsService = whyUsService;
        }

        
        [HttpGet]
        public async Task<IEnumerable<WhyUsDTO>> GetAll() => await _whyUsService.GetAll();

        [Authorize]
        [HttpPost]
        public async Task<WhyUsUpdateDTO> GetById(WhyUsByIdDTO whyUsByIdDTO) => await _whyUsService.GetById(whyUsByIdDTO);
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(WhyUsCreateDTO whyUsCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _whyUsService.Create(whyUsCreateDTO);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(WhyUsUpdateDTO whyUsUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                await _whyUsService.Update(whyUsUpdateDTO);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]

        public async Task Delete(int id) => await _whyUsService.Delete(new WhyUsDeleteDTO() { Id = id });


    }
}
