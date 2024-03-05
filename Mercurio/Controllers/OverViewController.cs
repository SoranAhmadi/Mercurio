using Application.DTOs.OVerViews;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Mercurio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OverViewController : ControllerBase
    {
        private readonly IOverViewService _overViewService;
        public OverViewController(IOverViewService overViewService)
        {
            _overViewService = overViewService;
        }

        [HttpGet]
        public async Task<OverViewDTO> Get() => await _overViewService.Get();

        [HttpPost]
        [RequestSizeLimit(500_000)]
        public async Task<IActionResult> Create(OverViewCreateDTO overViewCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _overViewService.Create(overViewCreateDTO);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        
        [HttpPut]
        [RequestSizeLimit(500_000)]
        public async Task<IActionResult> Update(OverViewUpdateDTO overViewUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                await _overViewService.Update(overViewUpdateDTO);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }




    }
}
