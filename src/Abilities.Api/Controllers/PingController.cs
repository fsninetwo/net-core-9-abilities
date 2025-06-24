using Microsoft.AspNetCore.Mvc;

namespace Abilities.Api.Controllers;

[ApiController]
[Route("ping")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok(new { message = "pong" });
    }
} 