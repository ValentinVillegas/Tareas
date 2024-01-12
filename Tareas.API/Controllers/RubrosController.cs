using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tareas.API.Data;
using Tareas.API.Helpers;
using Tareas.Shared.DTOs;
using Tareas.Shared.Models;

namespace Tareas.API.Controllers
{
    [ApiController]
    [Route("/api/Rubros")]
    public class RubrosController:ControllerBase
    {
        private readonly DataContext _context;

        public RubrosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _context.Rubros.Include(r => r.Encargados).AsQueryable();

            if (!string.IsNullOrWhiteSpace(paginacion.Filtro)) queryable = queryable.Where(r => r.Nombre.ToUpper().Contains(paginacion.Filtro.ToUpper()));

            return Ok(await queryable.OrderBy(r => r.Nombre).Paginar(paginacion).ToListAsync());
        }

        [HttpGet("TotalPaginas")]
        public async Task<IActionResult> TotalPaginas([FromQuery] PaginacionDTO paginacion)
        {
            var queryable = _context.Rubros.AsQueryable();

            if (!string.IsNullOrWhiteSpace(paginacion.Filtro)) queryable = queryable.Where(r => r.Nombre.ToUpper().Contains(paginacion.Filtro.ToUpper()));

            double cantidadRegistros = await queryable.CountAsync();
            double totalPaginas = Math.Ceiling(cantidadRegistros / paginacion.RegistrosPorPagina);

            return Ok(totalPaginas);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var rubro = await _context.Rubros.FirstOrDefaultAsync(x => x.Id == id);

            if (rubro == null) return NotFound();

            return Ok(rubro);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync(Rubro rubro)
        {
            try
            {
                _context.Rubros.Add(rubro);
                await _context.SaveChangesAsync();
                return Ok(rubro);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate")) return BadRequest("Ya existe un rubro con el mismo nombre");

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Rubro rubro)
        {
            try
            {
                _context.Rubros.Update(rubro);
                await _context.SaveChangesAsync();
                return Ok(rubro);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate")) return BadRequest("Ya existe un rubro con el mismo nombre");

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletAsync(int id)
        {
            var rubro = await _context.Rubros.FirstOrDefaultAsync(x => x.Id == id);

            if (rubro == null) return NotFound();

            _context.Remove(rubro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}