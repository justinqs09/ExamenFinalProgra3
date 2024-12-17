using System;
using System.ComponentModel.DataAnnotations;

namespace ExamenFinalProgra3.Models
{
    public class Proyecto
    {
        public int Id { get; set; } // Código único del proyecto

        [Required]
        [StringLength(100, ErrorMessage = "El nombre del proyecto no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } // Nombre descriptivo del proyecto

        [Required]
        public DateTime FechaInicio { get; set; } // Fecha de inicio del proyecto

        public DateTime? FechaFinalizacion { get; set; } // Fecha de finalización (puede ser null)
    }
}
