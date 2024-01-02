using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Tareas.API.Data;
using Tareas.API.Helpers;
using Tareas.Shared.DTOs;
using Tareas.Shared.Models;

namespace Tareas.API.Controllers
{
    [ApiController]
    [Route("/api/Departamentos")]
    public class DepartamentosController:ControllerBase
    {
        private readonly DataContext _context;

        public DepartamentosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _context.Departamentos.Include(d => d.Empleados).AsQueryable();

            if (!string.IsNullOrWhiteSpace(paginacion.Filtro)) queryable = queryable.Where(d => d.Nombre.ToUpper().Contains(paginacion.Filtro!.ToUpper()));

            return Ok(await queryable.OrderBy(d => d.Nombre).Paginar(paginacion).ToListAsync());
        }

        [HttpGet("TotalPaginas")]
        public async Task<IActionResult> TotalPaginas([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _context.Departamentos.AsQueryable();
            if (!string.IsNullOrWhiteSpace(paginacion.Filtro)) queryable = queryable.Where(d => d.Nombre.ToUpper().Contains(paginacion.Filtro!.ToUpper()));

            double cantidadRegistros = await queryable.CountAsync();
            double totalPaginas = Math.Ceiling(cantidadRegistros / paginacion.RegistrosPorPagina);

            return Ok(totalPaginas);
        }

        [HttpGet("{idDepartamento:int}")]
        public async Task<IActionResult> GetAsync(int idDepartamento)
        {
            var departamento = await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == idDepartamento);
            if (departamento == null) return NotFound();
            return Ok(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Departamento departamento)
        {
            try
            {
                _context.Departamentos.Add(departamento);
                await _context.SaveChangesAsync();
                return Ok(departamento);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate")) return BadRequest("Ya existe un departamento con el mismo nombre");

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Departamento departamento)
        {
            try
            {
                _context.Departamentos.Update(departamento);
                await _context.SaveChangesAsync();
                return Ok(departamento);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate")) return BadRequest("Ya existe un departamento con el mismo nombre");

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{idDepartamento:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var departamento = await _context.Departamentos.FirstOrDefaultAsync(d => d.Id == id);

            if (departamento == null) return NotFound();

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}