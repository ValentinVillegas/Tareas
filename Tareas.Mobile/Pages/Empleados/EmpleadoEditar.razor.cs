using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using System.Net;
using Tareas.Shared.Models;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile.Pages.Empleados
{
    public partial class EmpleadoEditar
    {
        private EmpleadoForm empleadoForm;
        private Empleado empleado;

        [Inject] private IRepository Repositorio { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Parameter] public int EmpleadoId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await BuscaEmpleado();
        }

        private async Task BuscaEmpleado()
        {
            try
            {
                var responseHttp = await Repositorio.Get<Empleado>($"/api/empleados/{EmpleadoId}");

                if (responseHttp.Error)
                {
                    //NO SE ENCONTRÓ AL EMPLEADO CON EL ID PROPORCIONADO, SE REDIRIGE AL INDEX
                    if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                    {
                        NavigationManager.NavigateTo("/empleados");
                        return;
                    }

                    //OCURRIÓ ALGÚN ERROR, SE MUESTRA EN PANTALLA
                    var message = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                    return;
                }

                empleado = responseHttp.Response;
            }catch (Exception ex)
            {
                var message = ex.Message;
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
        }

        private async void GuardarAsync()
        {
            var responseHttp = await Repositorio.Put<Empleado>($"/api/empleados", empleado);

            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Proceso terminado",
                Text = "Datos guardados correctamente",
                Icon = SweetAlertIcon.Success,
                Timer = 1500
            });

            empleadoForm.formularioEnviado = true;
            Regresar();
        }

        private void Regresar()
        {
            NavigationManager.NavigateTo("/empleados");
        }
    }
}
