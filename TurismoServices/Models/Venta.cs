using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TurismoServices.Enums;

namespace TurismoServices.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public DateTime FechaReservacion { get; set; }
        public MetodoPagoEnum MetodoPago { get; set; }
        public PreferenciaTransporteEnum Transporte { get; set; }
        public DateTime FechaPago { get; set; }
        public int NumPersona { get; set; }
        public decimal Total { get; set; }
        public bool Eliminado { get; set; } = false;
        public int IdItinerario { get; set; }
        public Itinerario Itinerario { get; set; }
        public int IdActividad { get; set; }
        public Actividad Actividad { get; set; }


        public ICollection<DetalleVenta> DetallesVenta { get; set; }

        public Venta()
        {
            DetallesVenta = new List<DetalleVenta>();
        }

    }
}
