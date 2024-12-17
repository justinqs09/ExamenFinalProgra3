using System;
using System.ComponentModel.DataAnnotations;

namespace ExamenFinalProgra3.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        [Range(250000, 500000, ErrorMessage = "El salario debe estar entre 250,000 y 500,000.")]
        public decimal Salario { get; set; }

        [Required]
        public string CategoriaLaboral { get; set; }
        public string Nombre { get; internal set; }

        // Método que asigna salario por defecto si no se proporciona
        public void AsignarSalario()
        {
            if (Salario == 0)
            {
                Salario = 250000;  // Asignar salario mínimo si no se proporciona
            }
            else if (Salario > 500000)
            {
                Salario = 500000;  // Asegurarse de que no se supere el salario máximo
            }
        }
    }
}
