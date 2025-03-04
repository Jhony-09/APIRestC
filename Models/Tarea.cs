using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectef.Models
{
    public class Tarea
    {

        public Guid idTar { get; set; }

        public Guid idCatTar { get; set; }

        public string tituloTar { get; set; }

        public string descripcionTar { get; set; }

        public Prioridad prioridadTar { get; set; }
        public DateTime fechaTar { get; set; }

        //TAER LA CATEGORIA ASOCIADA A UNA TAREA CONSULTADA
        public virtual Categoria categoriaTar { get; set; }
        
        public string resumenTar { get; set;}
}

    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }
}
