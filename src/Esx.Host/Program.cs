using Esx.Controllers;
using Esx.Integration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMvc()
    .AddApplicationPart(ControllersAssembly.Reference)
    .AddControllersAsServices();

builder.Services.AddIntegrationServices(
    builder.Environment.ContentRootPath,
    builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
