using Application.DTOs.Category;
using Application.DTOs.ContactComment;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mercurio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ContactCommentController : ControllerBase
    {
        private readonly IContactCommentService _contactCommentService;
        public ContactCommentController(IContactCommentService contactCommentService)
        {
            _contactCommentService = contactCommentService;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactCommentDTO>> GetAll() => await _contactCommentService.GetAll();
        [Authorize]
        [HttpPost]
        public async Task<ContactCommentUpdateDTO> GetById(CategoryDeleteDTO categoryDeleteDTO) => await _contactCommentService.GetById(categoryDeleteDTO.Id);
        
        [HttpPost]
        public async Task<IActionResult> Create(ContactCommentCreateDTO contactCommentCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _contactCommentService.Create(contactCommentCreateDTO);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(ContactCommentUpdateDTO contactCommentUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                await _contactCommentService.Update(contactCommentUpdateDTO);
            }
            return BadRequest(ModelState);
        }
        [Authorize]
        [HttpDelete]
        public async Task Delete(ContactCommentDeleteDTO contactCommentDeleteDTO) => await _contactCommentService.Delete(contactCommentDeleteDTO);


    }
}
