using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Tareas.Shared.Models;

namespace Tareas.Mobile.Pages.Rubros
{
    public partial class RubroForm
    {
        private EditContext editContext = null;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Parameter, EditorRequired] public Rubro Rubro { get; set; } = null!;
        [Parameter, EditorRequired] public EventCallback OnValidSubmit { get; set; }
        [Parameter, EditorRequired] public EventCallback ReturnAction { get; set; }
        public bool formularioEnviado { get; set; }

        protected override void OnInitialized()
        {
            editContext = new(Rubro);
        }

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formularioModificado = editContext.IsModified();
            if (!formularioModificado || formularioEnviado) return;

            var confirmacion = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = "¿Deseas abandonar la página y perder los cambios?",
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
