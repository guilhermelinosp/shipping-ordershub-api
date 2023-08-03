using Microsoft.OpenApi.Models;
using ShippingOrders.Application;
using ShippingOrders.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationModule();
builder.Services.AddInfrastructureModule();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("V1", new OpenApiInfo
    {
        Title = "Test API Swagger Documentation",
        Version = "V1",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt => { opt.SwaggerEndpoint("/swagger/V1/swagger.json", "Test API Swagger Documentation"); });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();