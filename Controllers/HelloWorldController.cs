using Microsoft.AspNetCore.Mvc;
using projectef;
using webApiTwo.Services;

namespace webApiTwo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly ILogger<HelloWorldController> _logger;
    
   // IHelloWorldService helloWorldService;
    TareasContext dbcontext;

    public HelloWorldController( ILogger<HelloWorldController> logger, TareasContext db)
    {
       // this.helloWorldService = helloWorldService;
        
        _logger = logger;
        dbcontext = db;
    }

   /* [HttpGet]
    public IActionResult Get()
    {
        _logger.LogDebug("Retornando el saludo de bienvenida");
        return Ok(helloWorldService.GetHelloWorld());
    }*/

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}