using ExamenFinalProgra3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFinalProgra3.Controllers
{
    public class EmpleadoController : Controller
    {
        private static List<Empleado> empleados = new List<Empleado>();

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Empleado empleado)
        {
            // Asignar salario según las reglas
            empleado.AsignarSalario();

            // Validar que la categoría sea válida
            if (empleado.CategoriaLaboral != "Administrador" && empleado.CategoriaLaboral != "Operario" && empleado.CategoriaLaboral != "Peón")
            {
                ModelState.AddModelError("CategoriaLaboral", "La categoría laboral debe ser Administrador, Operario o Peón.");
            }

            if (ModelState.IsValid)
            {
                empleados.Add(empleado);  // Aquí guardas el empleado en la base de datos o en la lista temporal
                return RedirectToAction("Index");  // Redirigir al listado de empleados
            }

            return View(empleado);  // Si hay errores de validación, volver a mostrar el formulario
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(empleados);  // Muestra la lista de empleados
        }
    }
}
