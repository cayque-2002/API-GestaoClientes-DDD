using GestaoClientes.Application.Clientes.CriarCliente;
using GestaoClientes.Application.Clientes.ObterClientePorId;
using GestaoClientes.Application.Clientes.ObterTodosClientes;
using GestaoClientes.Application.Interfaces;
using GestaoClientes.Infrastructure.Repositorios;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<ObterTodosClientesQueryHandler>();
builder.Services.AddScoped<CriarClienteCommandHandler>();
builder.Services.AddScoped<ObterClientePorIdQueryHandler>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gestão de Clientes API",
        Version = "v1"
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
