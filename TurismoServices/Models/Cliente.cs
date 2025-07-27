using System.ComponentModel.DataAnnotations;
using TurismoServices.Enums;

namespace TurismoServices.Models
{
    public class Cliente
    {

        //Information Basic

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo apellido es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo DNI es obligatorio")]
        public string Documento { get; set; }

        public DateTime FechaNac { get; set; }

        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }

        public PreferenciaTransporteEnum  Transporte { get; set; }
        public int? IdDestino { get; set; }
        public virtual Destino? Destino { get; set; }

        public int? IdActividad { get; set; }
        public virtual Actividad? Actividad { get; set; }

        public int NumPersona { get; set; }
        public DateTime FechaReservacion { get; set; }
        public EstadoReservacionEnum EstadoReservacion { get; set; }

        public int? IdItinerario { get; set; }
        public virtual Itinerario? Itinerario { get; set; }

        public MetodoPagoEnum MetodoPago { get; set; }
        public ConfirmacionPagoEnum ConfirmacionPago { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Total { get; set; }

        public bool Eliminado { get; set; } = false;
    }

}
