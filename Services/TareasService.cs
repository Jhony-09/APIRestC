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

    public async Task InsertarCategoria(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task ActualizarCategoria(Guid id, Tarea tarea)
    {
        var tar = context.tareas.Find(id);
        if (tar != null)
        {
            tar.descripcionTar = tarea.descripcionTar;
            tar.categoriaTar = tarea.categoriaTar;
            tar.prioridadTar = tarea.prioridadTar;
            tar.fechaTar = tarea.fechaTar;
            tar.tituloTar = tarea.tituloTar;
            await context.SaveChangesAsync();
        }
    }

    public async Task ModificarCategoria(Guid id, Tarea tarea)
    {
        var tar = context.tareas.Find(id);
        if (tar != null)
        {
            tar.descripcionTar = tarea.descripcionTar;
            tar.categoriaTar = tarea.categoriaTar;
            tar.prioridadTar = tarea.prioridadTar;
            tar.fechaTar = tarea.fechaTar;
            tar.tituloTar = tarea.tituloTar;
            await context.SaveChangesAsync();
        }
    }
    
    public async Task EliminarCategoria(Guid id)
    {
        var tar = context.tareas.Find(id);
        if (tar != null)
        {
            context.Remove(tar);
            await context.SaveChangesAsync();
        }
    }
    
    
}

public interface ITareasService
{
    IEnumerable<Tarea> ListarCategorias();
    Task InsertarCategoria(Tarea tarea);
    Task ActualizarCategoria(Guid id, Tarea tarea);
    Task ModificarCategoria(Guid id, Tarea tarea);
    Task EliminarCategoria(Guid id);
    
    
}