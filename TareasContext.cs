using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace projectef
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Tarea> tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluen API CONFIGURACION DE LA BASE DE DATOS UTILIZANDO METODOS DE EXTENSION 
            //
            List<Categoria> categoriasInit = new List<Categoria>();
            
            categoriasInit.Add(new Categoria() { idCat = Guid.Parse("9b01084d-24a2-4d57-95f3-a4e36b83c821"), nombreCat = "Actividad una", pesoCat = 20});
            categoriasInit.Add(new Categoria() { idCat = Guid.Parse("cc0a7e60-b511-4bd2-9f92-47e09aa93399"), nombreCat = "Actividad dos", pesoCat = 5});
            categoriasInit.Add(new Categoria() { idCat = Guid.Parse("392b050f-ef5b-4d47-bd1c-045ba0896429"), nombreCat = "Actividad tres", pesoCat = 15});
            categoriasInit.Add(new Categoria() { idCat = Guid.Parse("4ac248e2-99c3-486c-ade3-7ce8550134aa"), nombreCat = "Actividad cuatro", pesoCat = 8});
            categoriasInit.Add(new Categoria() { idCat = Guid.Parse("632f1ab3-e035-4757-8e1c-c1a28064470f"), nombreCat = "Actividadv cinco", pesoCat = 10});
            
            
            
            // permite un tipo (categoria) se le dice que validaciones realizar
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(c => c.idCat);
                categoria.Property(c => c.nombreCat).HasMaxLength(150).IsRequired();
                categoria.Property(c => c.descripcionCat).HasMaxLength(250).IsRequired(false);
                categoria.HasMany(c => c.tareasCat).WithOne(t => t.categoriaTar).HasForeignKey(t => t.idCatTar);
                categoria.Property(c => c.pesoCat);
                
                categoria.HasData(categoriasInit);

            });
            
            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea(){idTar = Guid.Parse("bcabd8ea-eee9-404b-8c4f-76033b92936a"), idCatTar = Guid.Parse("9b01084d-24a2-4d57-95f3-a4e36b83c821"), resumenTar = "tarea de pintura" , fechaTar = DateTime.Now, tituloTar = "tarea de pintura", prioridadTar = Prioridad.Baja});
            tareasInit.Add(new Tarea(){idTar = Guid.Parse("e30dbed6-e771-40a4-b3e1-2e3ec6f2dc32"), idCatTar = Guid.Parse("cc0a7e60-b511-4bd2-9f92-47e09aa93399"), resumenTar = "tarea de cantar", fechaTar = DateTime.Now, tituloTar = "tarea de cantar", prioridadTar = Prioridad.Alta});
            tareasInit.Add(new Tarea(){idTar = Guid.Parse("8927e4ee-ebb9-44c1-96b0-e0ccdb84bec0"), idCatTar = Guid.Parse("392b050f-ef5b-4d47-bd1c-045ba0896429"), resumenTar = "tarea de jugar", fechaTar = DateTime.Now, tituloTar = "tarea de jugar", prioridadTar = Prioridad.Media});
            tareasInit.Add(new Tarea(){idTar = Guid.Parse("acbb4376-9312-4669-8630-be092fec2c7b"), idCatTar = Guid.Parse("4ac248e2-99c3-486c-ade3-7ce8550134aa"), resumenTar = "tarea de colocar" , fechaTar = DateTime.Now, tituloTar = "tarea de colocar", prioridadTar = Prioridad.Baja});
            tareasInit.Add(new Tarea(){idTar = Guid.Parse("92d653e7-38bf-4aaf-bec2-bd8b467a455b"), idCatTar = Guid.Parse("632f1ab3-e035-4757-8e1c-c1a28064470f"), resumenTar = "tarea de mision", fechaTar = DateTime.Now, tituloTar = "tarea de mision", prioridadTar = Prioridad.Alta});

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(t => t.idTar);
                tarea.HasOne(t => t.categoriaTar).WithMany(c => c.tareasCat).HasForeignKey(t => t.idCatTar);
                tarea.Property(t => t.tituloTar).HasMaxLength(150).IsRequired();
                tarea.Property(t => t.descripcionTar).HasMaxLength(250).IsRequired(false);
                tarea.Property(t => t.fechaTar).IsRequired();
                tarea.Property(t => t.prioridadTar).IsRequired();
                tarea.Ignore(t => t.resumenTar);
                tarea.HasOne(t => t.categoriaTar).WithMany(c => c.tareasCat).HasForeignKey(t => t.idCatTar);
                
                tarea.HasData(tareasInit);
            });
        }

    }
}
