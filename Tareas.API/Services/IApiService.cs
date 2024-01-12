using Tareas.Shared.Responses;

namespace Tareas.API.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
    }
}
