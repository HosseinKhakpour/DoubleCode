using DoubleCode.Application;
using DoubleCode.Infrastructure;
using DoubleCode.Infrastructure.Persistence;
using DoubleCode.WebUI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices();
builder.Services.AddWebUIServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
