using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Tareas.API.Data;
using Tareas.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=ConexionBD"));
builder.Services.AddScoped<ITareasHelper, TareasHelper>();
//builder.Services.AddTransient<SeedDB>();

var app = builder.Build();

//PrecargarDatos(app);

//void PrecargarDatos(WebApplication app)
//{
//    IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

//    using (IServiceScope? scope = scopedFactory!.CreateScope())
//    {
//        SeedDB? service = scope.ServiceProvider.GetService<SeedDB>();
//        service!.SeedAsync().Wait();
//    }
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
);

app.Run();
