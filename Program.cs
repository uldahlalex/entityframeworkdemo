using serversidevalidation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDbContext>();

builder.Services.AddScoped<IPetService, PetService>();

builder.Services.AddOpenApiDocument();

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<MyDbContext>().Database.EnsureCreated();
}

app.UseOpenApi();
app.UseSwaggerUi();
app.MapControllers();

app.Run();
