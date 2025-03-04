using Microsoft.AspNetCore.Mvc;
using projectef.Models;
using webApiTwo.Services;

namespace webApiTwo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    ICategoriaService categoriaService;
    private readonly ILogger<CategoriaController> _logger;

    public CategoriaController(ICategoriaService service,ILogger<CategoriaController> logger)
    {
        _logger = logger;
        categoriaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoriaService.GetCategorias());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        categoriaService.InsertCategoria(categoria);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        categoriaService.EditarCategoria(id, categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoriaService.EliminarCategoria(id);
        return Ok();
    }
   
}