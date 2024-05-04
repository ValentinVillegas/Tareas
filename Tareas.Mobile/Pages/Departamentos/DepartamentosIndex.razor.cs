using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Tareas.Shared.Models;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile.Pages.Departamentos
{
    public partial class DepartamentosIndex
    {
        [Inject] private IRepository Repositorio { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        public List<Departamento> Departamentos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CargaDepartamentos();
        }

        private async Task CargaDepartamentos()
        {
            var responseHttp = await Repositorio.Get<List<Departamento>>("/api/departamentos");

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            Departamentos = responseHttp.Response;
        }
    }
}