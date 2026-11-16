using Microsoft.Extensions.Logging.Abstractions;
using Unimar.ProjetoAcademico.ApplicationService;
using Unimar.ProjetoAcademico.Domain;
using Unimar.ProjetoAcademico.Infra.CrossCutting.FluentValidation;
using Unimar.ProjetoAcademico.Infra.CrossCutting.IoC;
using Unimar.ProjetoAcademico.Infra.CrossCutting.MediatoR;
using Unimar.ProjetoAcademico.Infra.CrossCutting.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InitApplicationService();
builder.Services.InitDomain();

var assemblies = AppDomain.CurrentDomain.GetAssemblies();

//builder.Services
//    .AddMediator(assemblies)
//    .AddIoC(builder.Configuration)
//    .AddSwagger()
//    .AddControllers();

builder.Services.AddFluentValitationAutoValidation(assemblies);

builder.Services.AddMediator(assemblies);

builder.Services.AddIoC(builder.Configuration);

builder.Services.AddSwagger();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
