using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using System.Net;
using Tareas.Shared.Models;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile.Pages.Departamentos
{
    public partial class DepartamentoEditar
    {
        private Departamento? departamento;

        [Inject] private IRepository Repositorio { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Parameter] public int DepartamentoId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await BuscarDepartamento();
        }

        private async Task BuscarDepartamento()
        {
            var responseHttp = await Repositorio.Get<Departamento>($"/api/Departamentos/{DepartamentoId}");

            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/departamentos");
                    return;
                }

                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            departamento = responseHttp.Response;
        }

        private void GuardarDepartamentoAsync()
        {
            Regresar();
        }

        private void Regresar()
        {
            NavigationManager.NavigateTo("/departamentos");
        }
    }
}
