using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Tareas.API.Data;
using Tareas.Shared.Models;

namespace Tareas.API.Helpers
{
    public class TareasHelper:ITareasHelper
    {
        private readonly DataContext _context;

        public TareasHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<Int64> ConsecutivoTarea(int idRubro, bool actualizar)
        {
            try
            {
                var rubro = await _context.Rubros.FirstOrDefaultAsync(r => r.Id == idRubro);
                Int64 consecutivo = rubro is null ? 0 : rubro.Folio;
                consecutivo = consecutivo + 1;

                if (actualizar)
                {
                    rubro!.Folio = consecutivo;
                    _context.Rubros.Update(rubro);
                    await _context.SaveChangesAsync();
                }
                
                return consecutivo;

            }catch (Exception ex)
            {
                return 0;
            }
        }
    }
}