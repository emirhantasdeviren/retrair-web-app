using Inveon.eCommerceExample.Order.API.BackgroundServices;
using Inveon.eCommerceExample.Order.API.Data;
using Inveon.eCommerceExample.Order.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrderContext>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddHostedService<EventConsumerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var _db = scope.ServiceProvider.GetRequiredService<OrderContext>();
    var pendingMigrations = await _db.Database.GetPendingMigrationsAsync();
    if (pendingMigrations.Any()) {
        await _db.Database.MigrateAsync();
    }
}

app.Run();
