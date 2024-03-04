using Application.DTOs.Category;
using Application.DTOs.ContactUs;
using Application.DTOs.Service;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Mercurio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpGet]
        public async Task<ContactUsDTO> Get() => await _contactUsService.Get();

        [HttpPost]
        public async Task<IActionResult> Create(ContactUsCreateDTO contactUsCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _contactUsService.Create(contactUsCreateDTO);
                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        
        [HttpPut]
        public async Task<IActionResult> Update(ContactUsUpdateDTO contactUsUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                await _contactUsService.Update(contactUsUpdateDTO);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }




    }
}
