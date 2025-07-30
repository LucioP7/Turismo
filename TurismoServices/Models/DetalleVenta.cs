using TurismoServices.Enums;

namespace TurismoServices.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }

        public int IdVenta { get; set; }
        public virtual Venta Venta { get; set; }

        public int? IdDestino { get; set; }
        public virtual Destino Destino { get; set; }

        public int? IdActividad { get; set; }
        public virtual Actividad Actividad { get; set; }

        public int? IdItinerario { get; set; }
        public virtual Itinerario Itinerario { get; set; }


    }
}
