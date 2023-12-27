using Shipping.OrdersHub.Application;
using Shipping.OrdersHub.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
    .Services
    .AddApplication();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();