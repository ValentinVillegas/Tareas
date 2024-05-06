using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using System.Net;
using Tareas.Shared.Models;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile.Pages.Rubros
{
    public partial class RubroEditar
    {
        private Rubro? rubro;
        private RubroForm? rubroForm;

        [Inject] private IRepository Repositorio { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Parameter] public int IdRubro { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await Repositorio.Get<Rubro>($"/api/rubros/{IdRubro}");

            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/rubros");
                    return;
                }

                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            rubro = responseHttp.Response;
        }

        private async Task GuardarAsync()
        {
            var responseHttp = await Repositorio.Put("/api/rubros", rubro);

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
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