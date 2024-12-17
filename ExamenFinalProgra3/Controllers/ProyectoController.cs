using Microsoft.AspNetCore.Mvc;
using ExamenFinalProgra3.Models;  // Asegúrate de importar el espacio de nombres de tu modelo
using System.Linq;  // Necesario para LINQ

namespace ExamenFinalProgra3.Controllers
{
    public class ProyectoController : Controller
    {
        // Aquí podrías tener algún servicio o repositorio que gestione los proyectos,
        // pero por ahora usaremos una lista estática solo para ejemplificar.

        private static List<Proyecto> proyectos = new List<Proyecto>
        {
            new Proyecto { Id = 1, Nombre = "Proyecto A", FechaInicio = DateTime.Now.AddMonths(-1) },
            new Proyecto { Id = 2, Nombre = "Proyecto B", FechaInicio = DateTime.Now.AddMonths(-2), FechaFinalizacion = DateTime.Now }
        };

        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View(proyectos); // Pasamos la lista de proyectos a la vista
        }
    }
}

