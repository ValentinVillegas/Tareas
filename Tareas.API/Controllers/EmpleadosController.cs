using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tareas.API.Data;
using Tareas.Shared.Models;

namespace Tareas.API.Controllers
{
    [ApiController]
    [Route("/api/Empleados")]
    public class EmpleadosController:ControllerBase
    {
        private readonly DataContext _context;

        public EmpleadosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Empleados.Include(e => e.Departamento).ToListAsync());
        }

        [HttpGet("{idEmpleado:int}")]
        public async Task<IActionResult> GetAsync(int idEmpleado)
        {
            var empleado = await _context.Empleados.FirstOrDefaultAsync(emp => emp.Id == idEmpleado);
            if (empleado == null) return NotFound();
            return Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Empleado empleado)
        {
            try
            {
                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();
                return Ok(empleado);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Empleado empleado)
        {
            try
            {
                _context.Empleados.Update(empleado);
                await _context.SaveChangesAsync();
                return Ok(empleado);

            }catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{idEmpleado:int}")]
        public async Task<IActionResult> DeleteAsync(int idEmpleado)
        {
            var empleado = await _context.Empleados.FirstOrDefaultAsync(emp => emp.Id == idEmpleado);

            if(empleado == null) return NotFound();

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
