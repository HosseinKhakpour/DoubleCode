using DoubleCode.Application;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
