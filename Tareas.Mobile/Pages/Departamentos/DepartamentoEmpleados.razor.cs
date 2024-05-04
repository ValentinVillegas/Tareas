using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using System.Net;
using Tareas.Shared.Models;
using Tareas.SharedComponents.Repositorio;

namespace Tareas.Mobile.Pages.Departamentos
{
    public partial class DepartamentoEmpleados
    {
        private List<Empleado> empleados;
        private Departamento departamento;

        [Inject] private IRepository Repositorio { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Parameter] public int DepartamentoId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await BuscaDepartamento();
            if (departamento is not null) await BuscaTrabajadores();
        }

        private async Task BuscaDepartamento()
        {
            var responseHttp = await Repositorio.Get<Departamento>($"/api/departamentos/{DepartamentoId}");

            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    await SweetAlertService.FireAsync("Error", "No se encontró el departamento con el Id solicitado.", SweetAlertIcon.Error);
                    return;
                }

                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            departamento = responseHttp.Response;
        }

        private async Task BuscaTrabajadores()
        {
            var responseHttp = await Repositorio.Get<List<Empleado>>($"/api/empleados/empleadosByDepto/{DepartamentoId}");

            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    await SweetAlertService.FireAsync("Error", "No hay trabajadores asignados a este departamento", SweetAlertIcon.Error);
                    return;
                }

                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            empleados = responseHttp.Response;
        }
    }
}