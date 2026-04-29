using GithubActionsAula.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IShippingService, ShippingService>();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Shipping API - CI/CD with GiHub Actions");
app.MapGet("/shipping", (decimal weight, IShippingService shippingService) =>
{
    var value = shippingService.Calculate(weight);

    return Results.Ok(new
    {
        Value = value,
        Weight = weight,
    });
});

app.Run();