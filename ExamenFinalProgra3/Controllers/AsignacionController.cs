using Microsoft.AspNetCore.Mvc;
using ExamenFinalProgra3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamenFinalProgra3.Controllers
{
    public class AsignacionController : Controller
    {
        private static List<AsignacionDeProyecto> asignaciones = new List<AsignacionDeProyecto>();
        private static List<Proyecto> proyectos = new List<Proyecto>
        {
            new Proyecto { Id = 1, Nombre = "Proyecto A", FechaInicio = DateTime.Now.AddMonths(-1) },
            new Proyecto { Id = 2, Nombre = "Proyecto B", FechaInicio = DateTime.Now.AddMonths(-2), FechaFinalizacion = DateTime.Now }
        };
        private static List<Empleado> empleados = new List<Empleado>
        {
            new Empleado { Id = 1, Nombre = "Empleado 1" },
            new Empleado { Id = 2, Nombre = "Empleado 2" }
        };

        // Acción para asignar empleados a proyectos
        public IActionResult Asignar()
        {
            // Pasamos los proyectos y empleados disponibles a la vista
            ViewBag.Proyectos = proyectos;
            ViewBag.Empleados = empleados;
            return View();
        }

        [HttpPost]
        public IActionResult Asignar(int empleadoId, int proyectoId, DateTime? fechaAsignacion)
        {
            if (!fechaAsignacion.HasValue)
            {
                fechaAsignacion = DateTime.Now; // Si no se especifica la fecha, usamos la fecha actual
            }

            // Crear la asignación
            var asignacion = new AsignacionDeProyecto
            {
                Id = asignaciones.Count + 1,
                EmpleadoId = empleadoId,
                ProyectoId = proyectoId,
                FechaAsignacion = fechaAsignacion.Value
            };

            asignaciones.Add(asignacion);
            return RedirectToAction("VerAsignaciones"); // Redirigir a la lista de asignaciones
        }

        // Acción para ver las asignaciones
        public IActionResult VerAsignaciones()
        {
            var asignacionesConDetalles = asignaciones.Select(a => new
            {
                a.Id,
                Empleado = empleados.FirstOrDefault(e => e.Id == a.EmpleadoId)?.Nombre,
                Proyecto = proyectos.FirstOrDefault(p => p.Id == a.ProyectoId)?.Nombre,
                a.FechaAsignacion
            }).ToList();

            return View(asignacionesConDetalles); // Pasamos la lista de asignaciones a la vista
        }
    }
}
