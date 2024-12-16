using DotNetEnv;
using HelpDevs.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do CORS para permitir acesso ao frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Adicionar suporte aos Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Aplicar política de CORS
app.UseCors("AllowAll");

// Mapear os Controllers
app.MapControllers();

// Iniciar o aplicativo
app.Run();
