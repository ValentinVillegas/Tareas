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
        
        [HttpPost]
        public async Task<IActionResult> PostAsync(Rubro rubro)
        {
            _context.Rubros.Add(rubro);
            await _context.SaveChangesAsync();

            return Ok(rubro);
        }
    }
}
