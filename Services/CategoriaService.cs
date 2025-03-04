using projectef;
using projectef.Models;

namespace webApiTwo.Services;

public class CategoriaService : ICategoriaService
{
    TareasContext context;

    public CategoriaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Categoria> GetCategorias()
    {
        return context.categorias;
    }


    public async Task InsertCategoria(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }
    
    public async Task EditarCategoria(Guid id, Categoria categoria)
    {
        var cat =  context.categorias.Find(id);

        if (cat != null)
        {
            cat.nombreCat = categoria.nombreCat;
            cat.descripcionCat = categoria.descripcionCat;
            cat.pesoCat = categoria.pesoCat;
            await context.SaveChangesAsync();
        }

    }
    
    
    public async Task EliminarCategoria(Guid id)
    {
        var cat =  context.categorias.Find(id);

        if (cat != null)
        {
            context.Remove(cat);
            await context.SaveChangesAsync();
        }

    }
    
}

public interface ICategoriaService
{
    IEnumerable<Categoria> GetCategorias();
    Task InsertCategoria(Categoria categoria);
    Task EditarCategoria(Guid id, Categoria categoria);
    Task EliminarCategoria(Guid id);
    
}