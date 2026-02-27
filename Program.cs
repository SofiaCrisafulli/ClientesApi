using ClientesApi.Services;
using ClientesApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ClienteService>();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestTimingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();