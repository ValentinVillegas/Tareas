using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tareas.API.Data;
using Tareas.Shared.Models;

namespace Tareas.API.Controllers
{
    [ApiController]
    [Route("/api/Equipos")]
    public class EquiposController:ControllerBase
    {
        private readonly DataContext _context;

        public EquiposController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var responseHttp = await _context.Equipos.ToListAsync();
            return Ok(responseHttp);
        }

        [HttpGet("{EquipoId:int}")]
        public async Task<IActionResult> GetAsync(int equipoId)
        {
            var responseHttp = await _context.Equipos.FirstOrDefaultAsync(e => e.Id == equipoId);
            if(responseHttp is null) return NotFound();
            return Ok(responseHttp);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Equipo equipo)
        {
            try
            {
                _context.Equipos.Add(equipo);
                await _context.SaveChangesAsync();
                return Ok(equipo);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if(dbUpdateException.InnerException!.Message.Contains("duplicate")) return BadRequest("Ya existe un equipo con esa descripción");
                return BadRequest(dbUpdateException.Message);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
