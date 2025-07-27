using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TurismoServices.Models
{
    public class Actividad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? URL_Image { get; set; }
        public int Duracion { get; set; }
        public decimal Costo { get; set; }
        public string? Descripcion { get; set; }

        public int? IdDestino { get; set; }
        public virtual Destino? Destino { get; set; }
        public bool Eliminado { get; set; } = false;
    }
}
