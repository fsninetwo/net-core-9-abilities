using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Abilities.Api.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetTest()
    {
        _logger.LogInformation("/test endpoint called");
        return Ok(new { message = "Endpoint is working" });
    }
} 