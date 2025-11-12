using Application.Dto;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;
using Presentation.Infrastructure;
using Shared.Result;

namespace Presentation.Controller;

[ApiController]
[Route("api/auth")]
public class AuthController(UserService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] UserAddDto dto)
    {
        var result = await service.AddAsync(dto);
        return Ok();
        return result.Match(user => Ok(user), CustomResults.Problem);
    }
}