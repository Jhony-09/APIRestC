using Microsoft.EntityFrameworkCore;
using projectef;
using projectef.Models;

namespace webApiTwo.Services;

public class TareasService : ITareasService
{
    TareasContext context;

    public TareasService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Tarea> ListarCategorias()
    {
        return context.tareas;
    }
    
}

public interface ITareasService
{
    IEnumerable<Tarea> ListarCategorias();
    
}