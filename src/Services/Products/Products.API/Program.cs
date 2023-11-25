using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Inveon.eCommerceExample.Products.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ProductContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var section = builder.Configuration.GetSection("ApiSettings");
var secret = section.GetValue<string>("Secret");
var issuer = section.GetValue<string>("Issuer");
var audience = section.GetValue<string>("Audience");

var key = Encoding.ASCII.GetBytes(secret);

builder.Services.AddAuthentication(authOpts =>
{
    authOpts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOpts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtBearerOpts =>
    {
        jwtBearerOpts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var _db = scope.ServiceProvider.GetRequiredService<ProductContext>();
    if (_db.Database.GetPendingMigrations().Count() > 0) {
        _db.Database.Migrate();
    }
}

app.Run();

