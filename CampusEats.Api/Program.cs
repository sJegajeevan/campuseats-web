var builder = WebApplication.CreateBuilder(args);

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",
                "https://campuseats-web-zeta.vercel.app"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("Frontend");

// Home API
app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        message = "CampusEats API is running successfully!"
    });
});

// Menu API
app.MapGet("/api/menu", () =>
{
    var menu = new[]
    {
        new { Id = 1, Name = "Chicken Rice", Price = 850 },
        new { Id = 2, Name = "Fried Rice", Price = 750 },
        new { Id = 3, Name = "Kottu", Price = 900 },
        new { Id = 4, Name = "Burger", Price = 650 }
    };

    return Results.Ok(menu);
});

app.Run();