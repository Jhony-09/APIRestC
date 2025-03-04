using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projectef.Models
{
    public class Categoria
    {
        
        public Guid idCat { get; set; }

        public string nombreCat { get; set; }

        public string descripcionCat { get; set; }

        public int pesoCat { get; set; }

        // TRAER TODAS LAS TAREAS ASOCIADAS A UNA CATEGORIA CONSULTADA

        [JsonIgnore]
        public virtual ICollection<Tarea> tareasCat { get; set; }


    }
}
