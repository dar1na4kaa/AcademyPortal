using Application.Services;
using Infrastructure.DI;

var builder = WebApplication.CreateBuilder(args);
var confinguration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(confinguration);
builder.Services.AddScoped<UserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();