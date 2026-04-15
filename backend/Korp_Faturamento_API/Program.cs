using Korp.Faturamento.API.Data;
using Korp.Faturamento.API.Repositories;
using Korp.Faturamento.API.Service;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddOpenApi();
builder.Services.AddScoped<INotaFiscalRepository, SqlNotaFiscalRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpClient<IEstoqueService, EstoqueService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5015/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();
//if (app.Environment.IsDevelopment())
//{
//   app.MapOpenApi();
//    app.MapScalarApiReference();
//}
//app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();
app.Run();
