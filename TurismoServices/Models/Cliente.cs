using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TurismoServices.Models
{
    public class Cliente
    {
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
        public bool Eliminado { get; set; } = false;

        // Relación con Ventas
        public virtual List<Venta> Ventas { get; set; } = new List<Venta>();

        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }
    }
}
