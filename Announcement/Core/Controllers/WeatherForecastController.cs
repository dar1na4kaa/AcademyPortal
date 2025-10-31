using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [Route("/api/")]
    public class WeatherForecastController(IAnnouncementRepository announcementRepository): ControllerBase
    {

        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> Get()
        {
            await announcementRepository.GetByGuidAsync(Guid.NewGuid());
            return Ok();
        }
    }
}
