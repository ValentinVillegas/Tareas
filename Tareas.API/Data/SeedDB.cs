using Tareas.Shared.Models;

namespace Tareas.API.Data
{
    public class SeedDB
    {
        private readonly DataContext _context;

        public SeedDB(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await LlenarDepartamentos();
            await LlenarEmpleados();
            await LlenarRubros();
        }

        private async Task LlenarDepartamentos()
        {
            if (!_context.Departamentos.Any())
            {
                List<Departamento> departamentos = new List<Departamento>
                {
                    new Departamento {Nombre = "Recepción"},
                    new Departamento {Nombre = "Calidad"},
                    new Departamento {Nombre = "Planeaciones"},
                    new Departamento {Nombre = "Publicidad"},
                    new Departamento {Nombre = "Ventas Digitales"},
                    new Departamento {Nombre = "Soporte"},
                    new Departamento {Nombre = "Sistemas"},
                    new Departamento {Nombre = "Asistencia"},
                    new Departamento {Nombre = "Horarios"},
                    new Departamento {Nombre = "Nominas"},
                    new Departamento {Nombre = "Cortes"},
                    new Departamento {Nombre = "Gerencia"}
                };

                _context.Departamentos.AddRange(departamentos);
                await _context.SaveChangesAsync();
            }
        }

        private async Task LlenarEmpleados()
        {
            if (!_context.Empleados.Any())
            {
                List<Empleado> empleados = new List<Empleado>
                {
                    new Empleado { CveEmpleado = "B6452", Nombre = "Valentín Villegas", DepartamentoId = 7},
                    new Empleado { CveEmpleado = "B1972", Nombre = "Filiberto Arredondo Martínez", DepartamentoId = 6},
                    new Empleado { CveEmpleado = "B4159", Nombre = "Francisco Javier Molina Ortiz", DepartamentoId = 6}
                };

                _context.Empleados.AddRange(empleados);
                await _context.SaveChangesAsync();
            }
        }

        private async Task LlenarRubros()
        {
            if (!_context.Rubros.Any())
            {
                List<Rubro> rubros = new List<Rubro>
                {
                    new Rubro{ Nombre = "Equipo computo", Cancelo = 0, Folio = 0, 
                        Encargados = new List<RubroEncargados>
                        {
                            new RubroEncargados {RubroId = 1, CveEmpleado = "B1972", Correo = "soporte@pasteleriasanjose.com", Password = "1234", EsJefe = true, EmpleadoId = 2 }
                        }
                    },

                    new Rubro{ Nombre = "Vehículos", Cancelo = 0, Folio = 0,
                        Encargados = new List<RubroEncargados>
                        {
                            new RubroEncargados {RubroId = 2, CveEmpleado = "B6452", Correo = "sistemaspv@pasteleriasanjose.com", Password = "1234", EsJefe = true, EmpleadoId = 1 },
                            new RubroEncargados {RubroId = 2, CveEmpleado = "B4159", Correo = "soporte@pasteleriasanjose.com", Password = "1234", EsJefe = false, EmpleadoId = 3 }
                        }
                    }
                };

                _context.Rubros.AddRange(rubros);
                await _context.SaveChangesAsync();
            }
        }
    }
}
