using Application.DTOs.Histories;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Mercurio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController(IHistoryService historyService) : ControllerBase
    {
        private  IHistoryService _historyService { get; set; } = historyService;


        [HttpGet]
        public async Task<IEnumerable<HistoryDTO>> GetAll() => await _historyService.GetAll();

    }
}
