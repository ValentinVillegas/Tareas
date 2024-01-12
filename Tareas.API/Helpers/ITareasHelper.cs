namespace Tareas.API.Helpers
{
    public interface ITareasHelper
    {
        Task<Int64> ConsecutivoTarea(int idRubro, bool actualizar);
    }
}