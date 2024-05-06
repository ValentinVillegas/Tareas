using Microsoft.AspNetCore.Components;
using Tareas.Shared.Models;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile.Pages.Empleados
{
    public partial class EmpleadosIndex
    {
        [Inject] private IRepository Repositorio { get; set; }
        public List<Empleado> Empleados { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await Repositorio.Get<List<Empleado>>("/api/empleados");
            Empleados = responseHttp.Response;
        }
    }
}