using Microsoft.AspNetCore.Mvc;
using projectef.Models;
using webApiTwo.Services;

namespace webApiTwo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareasController : ControllerBase
{
    ITareasService tareasService;
    
    private readonly ILogger<TareasController> logger;

    public TareasController(ITareasService service, ILogger<TareasController> logger)
    {
        this.tareasService = service;
        this.logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareasService.ListarCategorias());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        tareasService.InsertarCategoria(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id,[FromBody] Tarea tarea)
    {
        tareasService.ActualizarCategoria(id, tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareasService.EliminarCategoria(id);
        return Ok();
    }
}