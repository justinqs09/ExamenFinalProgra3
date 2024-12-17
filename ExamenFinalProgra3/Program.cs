using ExamenFinalProgra3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configurar rutas para los controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ruta para Empleado
app.MapControllerRoute(
    name: "empleado",
    pattern: "Empleado/{action=Index}/{id?}",
    defaults: new { controller = "Empleado" });

// Ruta para Proyecto
app.MapControllerRoute(
    name: "proyecto",
    pattern: "Proyecto/{action=Index}/{id?}",
    defaults: new { controller = "Proyecto" });

// Ruta para Asignación de Proyectos (si la tienes)
app.MapControllerRoute(
    name: "asignacion",
    pattern: "Asignacion/{action=Index}/{id?}",
    defaults: new { controller = "AsignacionDeProyectos" });

app.Run();
