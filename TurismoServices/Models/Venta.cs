using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TurismoServices.Enums;

namespace TurismoServices.Models
{
    public class Venta
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public DateTime FechaReservacion { get; set; }
        public EstadoReservacionEnum EstadoReservacion { get; set; }
        public MetodoPagoEnum MetodoPago { get; set; }
        public ConfirmacionPagoEnum ConfirmacionPago { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Total { get; set; }
        public bool Eliminado { get; set; } = false;

        // Relación con RegistroVenta
        public virtual List<RegistroVenta> Registros { get; set; } = new List<RegistroVenta>();
    }
}
