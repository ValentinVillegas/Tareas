using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Tareas.Shared.Models;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile.Pages.UnidadesNegocio
{
    public partial class UnidadesNegocioIndex
    {
        [Inject] private IRepository Repositorio { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        public List<UnidadNegocio> UnidadesNegocio { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargaUnidadesNegocio();
        }

        private async Task CargaUnidadesNegocio()
        {
            var responseHttp = await Repositorio.Get<List<UnidadNegocio>>("/api/UnidadesNegocio");

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            UnidadesNegocio = responseHttp.Response;
        }
    }
}
