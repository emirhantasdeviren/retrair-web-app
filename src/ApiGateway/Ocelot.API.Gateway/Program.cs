using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add configurations
builder
    .Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ReactCorsPolicy",
            policy =>
            {
                policy
                    .WithOrigins("http://localhost:5000")
                    .WithMethods("GET", "POST", "DELETE", "PUT", "PATCH")
                    .WithHeaders("Content-Type", "Authorization")
                    .AllowCredentials();
            });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOcelot();

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

app.UseCors("ReactCorsPolicy");
app.UseAuthorization();

app.MapControllers();
await app.UseOcelot();

app.Run();
