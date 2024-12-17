using System;
using System.ComponentModel.DataAnnotations;

namespace ExamenFinalProgra3.Models
{
    public class AsignacionDeProyecto
    {
        public int Id { get; set; } // ID de la asignación

        [Required]
        public int ProyectoId { get; set; } // ID del proyecto

        [Required]
        public int EmpleadoId { get; set; } // ID del empleado

        [Required]
        public DateTime FechaAsignacion { get; set; } // Fecha de asignación

        // Propiedades de navegación
        public Proyecto Proyecto { get; set; } // Relación con el proyecto
        public Empleado Empleado { get; set; } // Relación con el empleado
    }
}

