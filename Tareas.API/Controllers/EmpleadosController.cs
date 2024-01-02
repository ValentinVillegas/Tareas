using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Tareas.API.Data;
using Tareas.API.Helpers;
using Tareas.Shared.DTOs;
using Tareas.Shared.Models;

namespace Tareas.API.Controllers
{
    [ApiController]
    [Route("/api/Empleados")]
    public class EmpleadosController : ControllerBase
    {
        private readonly DataContext _context;

        public EmpleadosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginacionDTO paginacion)
        {
            var queryable =  _context.Empleados.Include(e => e.Departamento).AsQueryable();

            if (!string.IsNullOrWhiteSpace(paginacion.Filtro)) queryable = queryable.Where(e => e.Nombre.ToUpper().Contains(paginacion.Filtro!.ToUpper()));

            return Ok(await queryable.OrderBy(e => e.Nombre).Paginar(paginacion).ToListAsync());
        }

        [HttpGet("TotalPaginas")]
        public async Task<IActionResult> TotalPaginas([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _context.Empleados.AsQueryable();

            if (!string.IsNullOrWhiteSpace(paginacion.Filtro)) queryable = queryable.Where(e => e.Nombre.ToUpper().Contains(paginacion.Filtro.ToUpper()));

            double cantidadRegistros = await queryable.CountAsync();
            double totalPaginas = Math.Ceiling(cantidadRegistros / paginacion.RegistrosPorPagina);

            return Ok(totalPaginas);
        }

        [HttpGet("{idEmpleado:int}")]
        public async Task<IActionResult> GetAsync(int idEmpleado)
        {
            var empleado = await _context.Empleados.FirstOrDefaultAsync(emp => emp.Id == idEmpleado);
            if (empleado == null) return NotFound();
            return Ok(empleado);
        }

        [HttpGet("EmpleadosByDepto/{departamentoId:int}")]
        public async Task<IActionResult> GetEmpleadosByDeptoAsync(int departamentoId)
        {
            var empleados = await _context.Empleados.Where(e => e.DepartamentoId == departamentoId).ToListAsync();
            if(empleados is null) return NotFound();
            return Ok(empleados);
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