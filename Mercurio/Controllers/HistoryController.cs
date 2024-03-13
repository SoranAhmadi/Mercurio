using Application.DTOs.Histories;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mercurio.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HistoryController(IHistoryService historyService) : ControllerBase
    {
        private  IHistoryService _historyService { get; set; } = historyService;

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<HistoryDTO>> GetAll() => await _historyService.GetAll();

    }
}
