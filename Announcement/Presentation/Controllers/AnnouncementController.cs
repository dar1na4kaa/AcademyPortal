using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Application;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/")]
    public class AnnouncementController(IAnnouncementService service) : ControllerBase
    {
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Create(AnnouncementDTO dto)
        {
            await service.CreateAsync(dto);
            return Ok();
        }
    }
}
