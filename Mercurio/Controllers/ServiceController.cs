using Application.DTOs.Category;
using Application.DTOs.Service;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public async Task<IEnumerable<ServiceSummaryDTO>> GetAllSummary() => await _serviceService.GetAllSummary();

        [Authorize]
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
        [Authorize]
        [HttpPost]
        public async Task<ServiceUpdateDTO> GetById(ServiceByIdDTO serviceUpdateDTO) => await _serviceService.GetById(serviceUpdateDTO.Id);

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(int id ) => await _serviceService.Delete(new ServiceDeleteDTO() {Id = id });
        
        [Authorize]
        [HttpPut]
        [RequestSizeLimit(500_000)]
        public async Task<IActionResult> Update(ServiceUpdateDTO serviceDeleteDTO)
        {
            if (ModelState.IsValid)
            {
                await _serviceService.Update(serviceDeleteDTO);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }




    }
}
