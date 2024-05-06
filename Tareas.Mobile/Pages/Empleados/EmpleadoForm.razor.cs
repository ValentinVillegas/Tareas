using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Tareas.Shared.Models;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile.Pages.Empleados
{
    public partial class EmpleadoForm
    {
        private EditContext editContext = null;
        private List<Departamento> departamentos;

        [Inject] private IRepository Repositorio { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Parameter, EditorRequired] public Empleado Empleado { get; set; } = null!;
        [Parameter, EditorRequired] public EventCallback OnValidSubmit { get; set; }
        [Parameter, EditorRequired] public EventCallback ReturnAction { get; set; }
        public bool formularioEnviado { get; set; }

        protected override async Task OnInitializedAsync()
        {
            editContext = new(Empleado);
            await CargarDepartamentosAsync();
        }

        private async Task CargarDepartamentosAsync()
        {
            var responseHttp = await Repositorio.Get<List<Departamento>>("/api/departamentos");

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            departamentos = responseHttp.Response;
        }

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formularioModificado = editContext.IsModified();
            if (!formularioModificado || formularioEnviado) return;

            var confirmacion = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = "¿Deseas salir sin guardar los cambios?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                CancelButtonText = "No",
                ConfirmButtonText = "Si"
            });

            if (!string.IsNullOrEmpty(confirmacion.Value)) return;

            context.PreventNavigation();
        }
    }
}
