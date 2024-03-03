using Application.DTOs.Category;
using Application.DTOs.Service;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Mercurio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceDTO>> GetAll() => await _serviceService.GetAll();

        [HttpPost]
        [RequestSizeLimit(500_000)]
        public async Task<IActionResult> Create(ServiceCreateDTO serviceCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _serviceService.Create(serviceCreateDTO);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        public async Task<ServiceUpdateDTO> GetById(ServiceByIdDTO serviceUpdateDTO) => await _serviceService.GetById(serviceUpdateDTO.Id);


        [HttpDelete]
        public async Task Delete(ServiceDeleteDTO serviceDeleteDTO) => await _serviceService.Delete(serviceDeleteDTO);

        [HttpPut]
        [RequestSizeLimit(500_000)]
        public async Task<IActionResult> Update(ServiceDeleteDTO serviceDeleteDTO)
        {
            if (ModelState.IsValid)
            {
                await _serviceService.Delete(serviceDeleteDTO);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }




    }
}
