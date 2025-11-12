using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AnnouncementController(IAnnouncementService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(AnnouncementDTO dto)
        {
            await service.CreateAsync(dto);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AnnouncementFilterDto filter)
        {
            var results = await service.GetAnnouncementsByFilters(filter);

            return Ok(results);
        }
    }
}
