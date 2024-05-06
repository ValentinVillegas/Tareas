using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Tareas.Shared.Models;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile.Pages.Rubros
{
    public partial class RubroNuevo
    {
        private Rubro rubro = new();
        private RubroForm rubroForm;

        [Inject] private IRepository Repositorio { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        private async Task Crear()
        {
            var responseHttp = await Repositorio.Post("/api/rubros", rubro);

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message);
                return;
            }

            rubroForm.formularioEnviado = true;
            Regresar();
        }

        private void Regresar()
        {
            NavigationManager.NavigateTo("/rubros");
        }
    }
}
