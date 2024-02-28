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
            _serviceService= serviceService;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceDTO>> GetAll()=>await _serviceService.GetAll();

        [HttpPost]
        public async Task<int> Create(ServiceCreateDTO serviceCreateDTO) => await _serviceService.Create(serviceCreateDTO);

        [HttpPost]
        public async Task<ServiceUpdateDTO> GetById(ServiceByIdDTO serviceUpdateDTO) => await _serviceService.GetById(serviceUpdateDTO.Id);


        [HttpDelete]
        public async Task Delete(ServiceDeleteDTO serviceDeleteDTO) => await _serviceService.Delete(serviceDeleteDTO);
        
        [HttpPut]
        public async Task Update(ServiceDeleteDTO serviceDeleteDTO) => await _serviceService.Delete(serviceDeleteDTO);




    }
}
