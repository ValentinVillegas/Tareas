using Tareas.Shared.DTOs;

namespace Tareas.API.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacion)
        {
            return queryable.Skip((paginacion.Pagina - 1) * paginacion.RegistrosPorPagina).Take(paginacion.RegistrosPorPagina);
        }
    }
}
