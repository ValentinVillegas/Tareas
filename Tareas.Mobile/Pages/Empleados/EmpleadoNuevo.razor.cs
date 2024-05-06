using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Tareas.Shared.Models;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile.Pages.Empleados
{
    public partial class EmpleadoNuevo
    {
        private Empleado empleado = new();
        private EmpleadoForm empleadoForm;

        [Inject] private IRepository Repositorio { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        private async Task Crear()
        {
            var responseHttp = await Repositorio.Post("/api/empleados", empleado);

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message);
                return;
            }

            empleadoForm.formularioEnviado = true;
            Regresar();
        }

        private void Regresar()
        {
            NavigationManager.NavigateTo("/empleados");
        }
    }
}