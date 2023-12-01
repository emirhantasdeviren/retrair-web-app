using System.Text.Json.Serialization;
using Inveon.eCommerceExample.Payment.API.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
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

var buyer = new Buyer
{
    Id = Guid.NewGuid(),
    Name = "Emirhan",
    Surname = "Tasdeviren",
    City = "Izmir",
    Country = "Turkey",
    Email = "emirhantasdeviren@gmail.com",
    IdentityNumber = "13880321028",
    RegistrationAddress = "foo",
};

var paymentCard = new PaymentCard
{
    CardHolderName = buyer.Name + " " + buyer.Surname,
    CardNumber = "5528790000000008",
    ExpireYear = "2030",
    ExpireMonth = "12",
    Cvc = "123",
};

var shippingAddress = new Address
{
    ContactName = "Jane Doe",
    City = "Istanbul",
    Country = "Turkey",
    Details = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
};

var billingAddress = new Address
{
    ContactName = "Jane Doe",
    City = "Istanbul",
    Country = "Turkey",
    Details = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",

};

var item = new Item
{
    Name = "Air Jordan 1 Retro High OG \"Chicago Lost and Found\"",
    Category = "Sneaker",
    Id = Guid.NewGuid(),
    ItemType = ItemType.Physical,
    Price = 4790.90,
};

var cartItems = new List<Item>
{
    item
};

var payment = new PaymentDetails
{
    Buyer = buyer,
    BillingAddress = billingAddress,
    ShippingAddress = shippingAddress,
    PaymentCard = paymentCard,
    CartItems = cartItems,
    Price = 4790.90,
    PaidPrice = 4790.90,
};

Console.WriteLine(JsonConvert.SerializeObject(payment, Formatting.Indented));

app.Run();
