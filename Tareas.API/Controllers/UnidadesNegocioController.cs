using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tareas.API.Data;
using Tareas.Shared.Models;

namespace Tareas.API.Controllers
{
    [ApiController]
    [Route("/api/UnidadesNegocio")]
    public class UnidadesNegocioController:ControllerBase
    {
        private readonly DataContext _context;

        public UnidadesNegocioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var responseHttp = await _context.UnidadesNegocio.ToListAsync();
            return Ok(responseHttp);
        }

        [HttpGet("{unidadNegocioId:int}")]
        public async Task<IActionResult> GetAsync(int unidadNegocioId)
        {
            var responseHttp = await _context.UnidadesNegocio.FirstOrDefaultAsync(un => un.Id == unidadNegocioId);
            if(responseHttp is null) return NotFound();
            return Ok(responseHttp);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(UnidadNegocio unidadNegocio)
        {
            try
            {
                
                _context.UnidadesNegocio.Add(unidadNegocio);
                await _context.SaveChangesAsync();
                return Ok(unidadNegocio);

            }catch(DbUpdateException dbUpdateException)
            {
                
                if (dbUpdateException.InnerException!.Message.Contains("duplicate")) return BadRequest("Ya existe una unidad de negocio con ese nombre");
                return BadRequest(dbUpdateException.Message);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(UnidadNegocio unidadNegocio)
        {
            try
            {
                
                _context.UnidadesNegocio.Update(unidadNegocio);
                await _context.SaveChangesAsync();
                return Ok(unidadNegocio);

            }catch(DbUpdateException dbUpdateException)
            {
                
                if (dbUpdateException.InnerException!.Message.Contains("duplicate")) return BadRequest("Ya existe una unidad de negocio con ese nombre");
                return BadRequest(dbUpdateException.Message);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/CambiarEstatus/{unidadNegocioId:Int}")]
        public async Task<IActionResult> CambiarEstatusAsync(int unidadNegocioId, bool cancelo = false)
        {
            var unidadNegocio = await _context.UnidadesNegocio.FirstOrDefaultAsync(un => un.Id == unidadNegocioId);

            if (unidadNegocio is null) return NotFound();

            try
            {
                unidadNegocio.Cancelo = cancelo ? '1' : '0';
                _context.UnidadesNegocio.Update(unidadNegocio);
                await _context.SaveChangesAsync();
                return Ok(unidadNegocio);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
