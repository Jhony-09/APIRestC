using Microsoft.AspNetCore.Mvc;
using webApiTwo.Services;

namespace webApiTwo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly ILogger<HelloWorldController> _logger;
    
    IHelloWorldService helloWorldService;

    public HelloWorldController(IHelloWorldService helloWorldService, ILogger<HelloWorldController> logger)
    {
        this.helloWorldService = helloWorldService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogDebug("Retornando el saludo de bienvenida");
        return Ok(helloWorldService.GetHelloWorld());
    }
}