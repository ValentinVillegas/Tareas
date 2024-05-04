using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Tareas.Shared.Models;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile.Pages.Departamentos
{
    public partial class DepartamentoForm
    {
        private EditContext editContext = null;

        [Inject] private IRepository Repositorio { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Parameter, EditorRequired] public Departamento Departamento { get; set; } = null!;
        [Parameter, EditorRequired] public EventCallback OnValidSubmit { get; set; }
        [Parameter, EditorRequired] public EventCallback ReturnAction { get; set; }
        public bool FormularioEnviado { get; set; }

        protected override void OnInitialized()
        {
            editContext = new(Departamento);
        }

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formularioModificado = editContext.IsModified();

            if (!formularioModificado || FormularioEnviado) return;

            var confirm = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = "¿Deseas salir sin guardar los cambios?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                CancelButtonText = "No",
                ConfirmButtonText = "Si"
            });

            if (!string.IsNullOrEmpty(confirm.Value)) return;

            context.PreventNavigation();
        }
    }
}
