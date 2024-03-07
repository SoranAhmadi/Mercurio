using Application.DTOs.AboutUsSections;
using Application.DTOs.WhyUses;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mercurio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AboutUsSectionController : ControllerBase
    {
        private readonly IAboutUsSectionService _aboutUsSectionService;
        public AboutUsSectionController(IAboutUsSectionService aboutUsSectionService)
        {
            _aboutUsSectionService = aboutUsSectionService;
        }

        [HttpGet]
        public async Task<AboutUsOnlyDTO> GetAboutUs() => await _aboutUsSectionService.GetAboutUs();
        /*[HttpGet]
        public async Task<IEnumerable< AboutUsDetailDTO>> GetAllWithDetail() => await _aboutUsSectionService.GetAllWithDetail();
        */
        [HttpGet]
        public async Task<OurCompanyDTO> GetOurCompany() => await _aboutUsSectionService.GetOurCompany();


        /*[HttpPost]
        public async Task<AboutUsSectionUpdateDTO> GetById(AboutUsSectionByIdDTO aboutUsSectionByIdDTO) => await _aboutUsSectionService.GetById(aboutUsSectionByIdDTO.Id);
*/
        /*[HttpPost]
        public async Task<IActionResult> Create(AboutUsSectionCreateDTO aboutUsSectionCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _aboutUsSectionService.Create(aboutUsSectionCreateDTO);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }*/

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateAboutUs(AboutUsInsertOrUpdateDTO aboutUsInsertOrUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                 await _aboutUsSectionService.InsertOrUpdateAboutUs(aboutUsInsertOrUpdateDTO);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateOurCompany(OurCompanyInsertOrUpdateDTO ourCompanyInsertOrUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                await _aboutUsSectionService.InsertOrUpdateOurCompany(ourCompanyInsertOrUpdateDTO);
                return Ok();
            }
            return BadRequest(ModelState);
        }


/*        [HttpPut]
        public async Task<IActionResult> Update(AboutUsSectionUpdateDTO aboutUsSectionUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                await _aboutUsSectionService.Update(aboutUsSectionUpdateDTO);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task Delete(AboutUsSectionDeleteDTO aboutUsSectionDeleteDTO) => await _aboutUsSectionService.Delete(aboutUsSectionDeleteDTO);
*/    }
}
