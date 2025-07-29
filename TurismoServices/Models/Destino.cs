using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TurismoServices.Models
{
    public class Destino
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string URL_image { get; set; }
        public string Categoria { get; set; }
        public string Pais { get; set; }

        public virtual ICollection<Itinerario> Itinerario { get; set; } = new List<Itinerario>();
        public virtual ICollection<Actividad> Actividad { get; set; } = new List<Actividad>();
        public bool Eliminado { get; set; } = false;
        public override string ToString()
        {
            return Nombre;
        }
        
        
    }


}
