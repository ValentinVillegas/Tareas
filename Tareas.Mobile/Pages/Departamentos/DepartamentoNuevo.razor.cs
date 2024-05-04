using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Tareas.Shared.Models;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile.Pages.Departamentos
{
    public partial class DepartamentoNuevo
    {
        private Departamento departamento = new();
        private DepartamentoForm departamentoForm;

        [Inject] private IRepository Repositorio { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        private async Task GuardarDepartamentoAsync()
        {
            var responseHttp = await Repositorio.Post("/api/departamentos", departamento);

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Proceso terminado",
                Text = "Departamento guardado correctamente",
                Icon = SweetAlertIcon.Success,
                Timer = 1500
            });

            departamentoForm.FormularioEnviado = true;
            Regresar();
        }

        private void Regresar()
        {
            NavigationManager.NavigateTo("/departamentos");
        }
    }
}
