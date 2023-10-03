using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tareas.API.Data;
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
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Rubros.Include(r => r.Encargados).ToListAsync());
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
            _context.Rubros.Add(rubro);
            await _context.SaveChangesAsync();

            return Ok(rubro);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Rubro rubro)
        {
            _context.Rubros.Update(rubro);
            await _context.SaveChangesAsync();
            return Ok(rubro);
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
