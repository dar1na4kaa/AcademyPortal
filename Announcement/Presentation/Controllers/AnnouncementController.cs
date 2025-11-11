using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AnnouncementController(IAnnouncementService service) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(AnnouncementDTO dto)
        {
            await service.CreateAsync(dto);

            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var results = await service.GetAnnouncements();

            return Ok(results);
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] AnnouncementFilterDto filter)
        {
            var results = await service.GetAnnouncementsByFilters(filter);

            return Ok(results);
        }
    }
}
