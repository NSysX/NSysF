using NSysF.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AgregaSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AgregaNSwag();
builder.Services.AgregaPersistencia(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();
app.Run();
